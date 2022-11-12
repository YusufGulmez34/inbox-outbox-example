package repository

import (
	"gorm.io/gorm"
)

type PGRepositoryBase[TModel any] struct {
	db *gorm.DB
}

func (r *PGRepositoryBase[TModel]) GeneratePGRepository(db *gorm.DB) {
	r.db = db
}

func (r *PGRepositoryBase[TModel]) Add(model *TModel) error {
	return r.db.Create(&model).Error
}
func (r *PGRepositoryBase[TModel]) AddRange(model *[]TModel) error {
	return r.db.Create(&model).Error
}

func (r *PGRepositoryBase[TModel]) Delete(id int) error {
	var model TModel
	return r.db.Delete(&model, id).Error
}

func (r *PGRepositoryBase[TModel]) FindById(guid string) (*TModel, error) {
	var model TModel
	if err := r.db.First(&model, "guid", guid).Error; err != nil {
		return nil, err
	}
	return &model, nil
}
func (r *PGRepositoryBase[TModel]) FindByProceed() (*[]TModel, error) {
	var model *[]TModel
	if err := r.db.Debug().Where("process_date is NULL").Find(&model).Error; err != nil {
		return nil, err
	}
	return model, nil
}
func (r *PGRepositoryBase[TModel]) DB() *gorm.DB {
	return r.db
}
