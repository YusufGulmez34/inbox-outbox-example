package inboxrepository

import (
	"consumer-service/internal/model"

	"gorm.io/gorm"
)

type ProductInboxRepository struct {
	PGRepositoryBase[model.ProductInbox]
}

func NewProductInboxRepository(db *gorm.DB) *ProductInboxRepository {
	db.AutoMigrate(&model.ProductInbox{}, &model.ProductOutbox{}, &model.Product{})
	productRepository := &ProductInboxRepository{}
	productRepository.GeneratePGRepository(db)
	return productRepository
}
