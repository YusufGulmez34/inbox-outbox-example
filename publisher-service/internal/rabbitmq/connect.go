package rabbitmq

import (
	"fmt"
	"publisher-service/config"
	"publisher-service/constant"

	amqp "github.com/rabbitmq/amqp091-go"
)

func RabbitMqConnect(cfg config.RabbitMQConfig) *amqp.Connection {
	connectionString := fmt.Sprintf(constant.RabbitMqConnectionString, cfg.User, cfg.Password, cfg.Host, cfg.Port)
	conn, err := amqp.Dial(connectionString)

	if err != nil {
		panic(err.Error())
	}
	return conn
}
