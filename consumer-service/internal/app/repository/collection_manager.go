package repository

import (
	"consumer-service/internal/app/repository/productrepository"

	"go.mongodb.org/mongo-driver/mongo"
)

type CollectionManager struct {
	products *productrepository.MongoProductRepository
}

func NewCollectionManager(db *mongo.Database) *CollectionManager {
	return &CollectionManager{
		products: productrepository.NewMongoProductRepository(db.Collection("products")),
	}
}

func (c *CollectionManager) Products() *productrepository.MongoProductRepository {
	return c.products
}
