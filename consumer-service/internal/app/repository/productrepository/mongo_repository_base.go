package productrepository

import (
	"context"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

type MongoRepositoryBase[TModel any] struct {
	collection *mongo.Collection
}

func (r *MongoRepositoryBase[TModel]) GenerateRepository(c *mongo.Collection) {
	r.collection = c
}

func (r *MongoRepositoryBase[TModel]) Add(model TModel) error {
	_, err := r.collection.InsertOne(context.TODO(), model)
	return err
}

func (r *MongoRepositoryBase[TModel]) Update(model bson.D, id int) error {
	return r.collection.FindOneAndUpdate(context.TODO(), bson.D{{"id", id}}, bson.D{{"$set", model}}).Err()
}

func (r *MongoRepositoryBase[TModel]) Delete(id int) error {
	return r.collection.FindOneAndDelete(context.TODO(), bson.D{{"id", id}}).Err()

}
