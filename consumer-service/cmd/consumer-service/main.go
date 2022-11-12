package main

import (
	"consumer-service/config"
	"consumer-service/db"
	"consumer-service/internal/app/consumer"
	"consumer-service/internal/app/repository"
	"consumer-service/internal/app/service"
	"consumer-service/internal/rabbitmq"
)

func main() {

	configManager := config.NewConfigurationManager()

	rabbitmqConfig := configManager.GetRabbitMQConfig()
	queuesConfig := configManager.GetQueuesConfig()

	mongoDbConnection := db.ConnectMongoDb(configManager.GetMongoDbConfig())
	postgresConnection := db.PGConnect(configManager.GetPostgreSQLConfig())

	entitiyRepository := repository.NewEntityManager(postgresConnection)
	collectionManager := repository.NewCollectionManager(mongoDbConnection)

	productService := service.NewProductService(*collectionManager, *entitiyRepository)
	productConsumer := consumer.NewProductConsumer(*productService)

	client := rabbitmq.NewRabbitMqClient(rabbitmqConfig, queuesConfig, *productConsumer).Connect()
	client.GenerateConsumerMap()

	var forever chan struct{}
	client.GenerateConsumers()

	<-forever

}
