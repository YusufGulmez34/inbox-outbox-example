package db

import (
	"consumer-service/config"
	"consumer-service/constant"
	"context"
	"fmt"

	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

func ConnectMongoDb(cfg config.MongoDbConfig) *mongo.Database {
	connectionString := fmt.Sprintf(constant.MongoDbConnectionString, cfg.Host, cfg.Port)
	client, err := mongo.Connect(context.TODO(), options.Client().ApplyURI(connectionString))
	if err != nil {
		panic(err.Error())
	}
	return client.Database(cfg.Database)
}
