package config

type AppConfiguration struct {
	Postgres PostgreSQLConfig `yaml:"postgres" mapstructure:"postgres"`
	RabbitMQ RabbitMQConfig   `yaml:"rabbitmq" mapstructure:"rabbitmq"`
	MongoDb  MongoDbConfig    `yaml:"mongodb" mapstructure:"mongodb"`
}

type PostgreSQLConfig struct {
	Port     int    `yaml:"port"`
	Host     string `yaml:"host"`
	User     string `yaml:"user"`
	Database string `yaml:"database"`
	Password string `yaml:"password"`
}

type RabbitMQConfig struct {
	Port     int    `yaml:"port"`
	Host     string `yaml:"host"`
	User     string `yaml:"user"`
	Password string `yaml:"password"`
}
type MongoDbConfig struct {
	Port     int    `yaml:"port"`
	Host     string `yaml:"host"`
	Database string `yaml:"database"`
}

type QueuesConfig struct {
	Product ProductQueueConfig `yaml:"product" mapstructure:"product"`
}

type ProductQueueConfig struct {
	ProductCreated QueueConfig `yaml:"productCreated" mapstructure:"productCreated"`
	ProductDeleted QueueConfig `yaml:"productDeleted" mapstructure:"productDeleted"`
	ProductUpdated QueueConfig `yaml:"productUpdated" mapstructure:"productUpdated"`
}

type QueueConfig struct {
	Exchange     string `yaml:"exchange"`
	ExchangeType string `yaml:"exchangeType"`
	RoutingKey   string `yaml:"routingKey"`
	Queue        string `yaml:"queue"`
}
