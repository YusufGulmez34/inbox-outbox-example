package rabbitmq

import (
	"consumer-service/config"
	"consumer-service/constant"
	"consumer-service/internal/app/consumer"
	"fmt"
	"os"

	amqp "github.com/rabbitmq/amqp091-go"
)

type Client struct {
	connection      *amqp.Connection
	config          config.RabbitMQConfig
	queues          config.QueuesConfig
	consumerMap     map[config.QueueConfig]func(delivery amqp.Delivery)
	productConsumer consumer.ProductConsumer
}

func NewRabbitMqClient(cfg config.RabbitMQConfig, queuesConfig config.QueuesConfig, productConsumer consumer.ProductConsumer) *Client {
	return &Client{
		config:          cfg,
		queues:          queuesConfig,
		productConsumer: productConsumer,
		consumerMap:     make(map[config.QueueConfig]func(delivery amqp.Delivery)),
	}
}

func (c *Client) Connect() *Client {
	connectionString := fmt.Sprintf(constant.RabbitMqConnectionString, c.config.User, c.config.Password, c.config.Host, c.config.Port)
	var err error
	c.connection, err = amqp.Dial(connectionString)
	if err != nil {
		os.Exit(1)
	}
	go func() {
		<-c.connection.NotifyClose(make(chan *amqp.Error))
		os.Exit(1)
	}()
	return c
}

func (c *Client) GenerateConsumerMap() {
	c.consumerMap[c.queues.Product.ProductCreated] = c.productConsumer.ProductCreatedConsume
	c.consumerMap[c.queues.Product.ProductDeleted] = c.productConsumer.ProductDeletedConsume
	c.consumerMap[c.queues.Product.ProductUpdated] = c.productConsumer.ProductUpdatedConsume
}

func queueDeclare(channel *amqp.Channel, queueConfig config.QueueConfig) {
	if _, err := channel.QueueDeclare(queueConfig.Queue, true, false, false, false, nil); err != nil {
		panic(err.Error())
	}
}
func exchangeDeclare(channel *amqp.Channel, queueConfig config.QueueConfig) {
	if err := channel.ExchangeDeclare(queueConfig.Exchange, queueConfig.ExchangeType, true, false, false, false, nil); err != nil {
		panic(err.Error())
	}
}
func queueBindingDeclare(channel *amqp.Channel, queueConfig config.QueueConfig) {
	if err := channel.QueueBind(queueConfig.Queue, queueConfig.RoutingKey, queueConfig.Exchange, false, nil); err != nil {
		panic(err.Error())
	}
}

func (c *Client) GenerateConsumers() {
	for key, consumer := range c.consumerMap {
		ch, _ := c.connection.Channel()
		queueDeclare(ch, key)
		exchangeDeclare(ch, key)
		queueBindingDeclare(ch, key)
		delivery, _ := ch.Consume(key.Queue, key.Queue, false, false, false, false, nil)
		go messageHandler(delivery, consumer)
	}
}

func messageHandler(delivery <-chan amqp.Delivery, consume func(delivery amqp.Delivery)) {
	for d := range delivery {
		consume(d)
	}
}
