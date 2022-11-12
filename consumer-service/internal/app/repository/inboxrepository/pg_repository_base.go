package inboxrepository

import "gorm.io/gorm"

type PGRepositoryBase[TModel any] struct {
	db *gorm.DB
}

func (r *PGRepositoryBase[TModel]) GeneratePGRepository(gormDb *gorm.DB) {
	r.db = gormDb
}

func (r *PGRepositoryBase[TModel]) Add(model *TModel) error {
	return r.db.Create(&model).Error
}

func (r *PGRepositoryBase[TModel]) Update(model *TModel) error {
	return r.db.Save(&model).Error
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
	if err := r.db.Where("proceed=?", false).Find(&model).Error; err != nil {
		return nil, err
	}
	return model, nil
}
