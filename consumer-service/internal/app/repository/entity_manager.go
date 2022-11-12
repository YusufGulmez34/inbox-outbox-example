package repository

import (
	"consumer-service/internal/app/repository/inboxrepository"

	"gorm.io/gorm"
)

type EntityRepository struct {
	productInboxes *inboxrepository.ProductInboxRepository
}

func NewEntityManager(db *gorm.DB) *EntityRepository {
	return &EntityRepository{
		productInboxes: inboxrepository.NewProductInboxRepository(db),
	}
}

func (e *EntityRepository) ProductInboxes() *inboxrepository.ProductInboxRepository {
	return e.productInboxes
}
