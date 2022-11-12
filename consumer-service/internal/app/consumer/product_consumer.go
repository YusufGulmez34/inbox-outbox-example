package consumer

import (
	"consumer-service/internal/app/service"
	"consumer-service/internal/model"
	"encoding/json"

	amqp "github.com/rabbitmq/amqp091-go"
)

type ProductConsumer struct {
	productService service.ProductService
}

func NewProductConsumer(ps service.ProductService) *ProductConsumer {
	return &ProductConsumer{
		productService: ps,
	}
}

func (p *ProductConsumer) ProductCreatedConsume(delivery amqp.Delivery) {
	var productOutbox model.ProductOutbox
	json.Unmarshal(delivery.Body, &productOutbox)
	p.productService.CreateProduct(productOutbox)
	delivery.Ack(false)
}

func (p *ProductConsumer) ProductDeletedConsume(delivery amqp.Delivery) {
	var productOutbox model.ProductOutbox
	json.Unmarshal(delivery.Body, &productOutbox)
	p.productService.DeleteProduct(productOutbox)
	delivery.Ack(false)
}

func (p *ProductConsumer) ProductUpdatedConsume(delivery amqp.Delivery) {
	var productOutbox model.ProductOutbox
	json.Unmarshal(delivery.Body, &productOutbox)
	p.productService.UpdateProduct(productOutbox)
	delivery.Ack(false)

}
