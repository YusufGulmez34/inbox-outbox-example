package productrepository

import (
	"consumer-service/internal/model"

	"go.mongodb.org/mongo-driver/mongo"
)

type MongoProductRepository struct {
	MongoRepositoryBase[model.Product]
}

func NewMongoProductRepository(collection *mongo.Collection) *MongoProductRepository {
	productRepository := &MongoProductRepository{}
	productRepository.GenerateRepository(collection)
	return productRepository
}
