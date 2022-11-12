package service

import (
	"context"
	"encoding/json"
	"log"
	"publisher-service/internal/app/repository"
	"time"

	"github.com/iancoleman/strcase"
	amqp "github.com/rabbitmq/amqp091-go"
)

type ProductOutboxService struct {
	repo         *repository.ProductOutboxRepository
	rabbitmqConn *amqp.Connection
}

func NewProductOutboxService(r *repository.ProductOutboxRepository, c *amqp.Connection) *ProductOutboxService {
	return &ProductOutboxService{repo: r, rabbitmqConn: c}
}
func CheckError(err error) {
	if err != nil {
		panic(err.Error())
	}
}

func (p *ProductOutboxService) CheckOutbox() {
	ch, _ := p.rabbitmqConn.Channel()
	outboxes, err := p.repo.FindByProceed()
	if err != nil {
		log.Fatal(err)
	}
	for _, outbox := range *outboxes {
		ctx, cancel := context.WithTimeout(context.Background(), 5*time.Second)
		defer cancel()
		body, _ := json.Marshal(outbox)
		routingKey := strcase.ToLowerCamel(outbox.Type)
		if err := ch.PublishWithContext(ctx, "product.events", routingKey, false, false, amqp.Publishing{ContentType: "application/json", Body: body}); err != nil {
			log.Fatal(err)
			continue
		}
		outbox.ProcessDate = time.Now()
		p.repo.Update(&outbox)
	}
}
