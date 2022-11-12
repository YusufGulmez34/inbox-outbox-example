package model

import "time"

type Product struct {
	Id          int       `gorm:"primarykey" bson:"id"`
	CreatedDate time.Time `bson:"createddate"`
	UpdatedDate time.Time `bson:"updateddate"`
	Name        string    `bson:"name"`
	Brand       string    `bson:"brand"`
	Category    string    `bson:"category"`
	Description string    `bson:"description"`
	Price       int       `bson:"price"`
}
