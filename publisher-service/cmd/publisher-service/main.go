package main

import (
	"publisher-service/config"
	"publisher-service/db"
	"publisher-service/internal/app/repository"
	"publisher-service/internal/app/service"
	"publisher-service/internal/rabbitmq"

	"github.com/robfig/cron/v3"
)

func main() {
	config := config.NewConfigurationManager()

	gormDb := db.PGConnect(config.GetPostgreSQLConfig())
	rabbitmqConn := rabbitmq.RabbitMqConnect(config.GetRabbitMQConfig())
	entityManager := repository.NewProductOutboxRepository(gormDb)
	productService := service.NewProductOutboxService(entityManager, rabbitmqConn)

	c := cron.New()
	c.AddFunc("@every 10s", productService.CheckOutbox)
	c.Run()

}
