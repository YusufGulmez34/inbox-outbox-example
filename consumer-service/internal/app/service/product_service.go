package service

import (
	"consumer-service/internal/app/repository"
	"consumer-service/internal/model"

	"encoding/json"

	"github.com/jinzhu/copier"
	"go.mongodb.org/mongo-driver/bson"
)

type ProductService struct {
	mongoStorage repository.CollectionManager
	pgStorage    repository.EntityRepository
}

func NewProductService(mongoStorage repository.CollectionManager, pgs repository.EntityRepository) *ProductService {
	return &ProductService{mongoStorage: mongoStorage, pgStorage: pgs}
}
func (p *ProductService) CheckInbox(productOutbox model.ProductOutbox) {
	var productInbox model.ProductInbox
	if err := copier.Copy(&productInbox, productOutbox); err != nil {
		return
	}

	productInboxRepo := p.pgStorage.ProductInboxes()
	if _, err := productInboxRepo.FindById(productInbox.Guid.String()); err != nil {
		productInbox.Proceed = false
		if err := productInboxRepo.Add(&productInbox); err != nil {
			return
		}
	}

}
func (b *ProductService) CreateProduct(productOutbox model.ProductOutbox) {
	b.CheckInbox(productOutbox)
	productInboxRepo := b.pgStorage.ProductInboxes()

	productInboxList, err := productInboxRepo.FindByProceed()
	if err != nil {
		return
	}
	for _, productInbox := range *productInboxList {
		if productInbox.Type == "ProductCreated" {
			var product model.Product
			json.Unmarshal([]byte(productInbox.Payload), &product)
			if err := b.mongoStorage.Products().Add(product); err != nil {
				continue
			}
			productInbox.Proceed = true
			if err := productInboxRepo.Update(&productInbox); err != nil {
				return
			}
		}
	}
}

func (b *ProductService) DeleteProduct(productOutbox model.ProductOutbox) {
	b.CheckInbox(productOutbox)
	productInboxRepo := b.pgStorage.ProductInboxes()
	productInboxList, err := productInboxRepo.FindByProceed()
	if err != nil {
		return
	}

	for _, productInbox := range *productInboxList {
		if productInbox.Type == "ProductDeleted" {
			var product model.Product
			json.Unmarshal([]byte(productInbox.Payload), &product)
			if err := b.mongoStorage.Products().Delete(product.Id); err != nil {
				continue
			}
			productInbox.Proceed = true
			if err := productInboxRepo.Update(&productInbox); err != nil {
				return
			}
		}
	}
}

func (b *ProductService) UpdateProduct(productOutbox model.ProductOutbox) {
	b.CheckInbox(productOutbox)
	productInboxRepo := b.pgStorage.ProductInboxes()
	productInboxList, err := productInboxRepo.FindByProceed()
	if err != nil {
		return
	}
	for _, productInbox := range *productInboxList {
		if productInbox.Type == "ProductUpdated" {
			var product model.Product
			json.Unmarshal([]byte(productInbox.Payload), &product)

			var doc bson.D
			data, _ := bson.Marshal(product)
			bson.Unmarshal(data, &doc)
			if err := b.mongoStorage.Products().Update(doc, product.Id); err != nil {
				continue
			}
			productInbox.Proceed = true
			if err := productInboxRepo.Update(&productInbox); err != nil {
				return
			}
		}

	}
}
