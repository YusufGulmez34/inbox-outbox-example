package repository

import (
	"publisher-service/internal/model"

	"gorm.io/gorm"
)

type ProductOutboxRepository struct {
	PGRepositoryBase[model.ProductOutbox]
}

func NewProductOutboxRepository(db *gorm.DB) *ProductOutboxRepository {
	repo := &ProductOutboxRepository{}
	repo.GeneratePGRepository(db)
	return repo
}

func (r *ProductOutboxRepository) Update(model *model.ProductOutbox) error {
	return r.db.Where("id = ?", model.Id).Save(&model).Error
}
