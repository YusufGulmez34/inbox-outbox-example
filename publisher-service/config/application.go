package config

type AppConfiguration struct {
	Postgres PostgreSQLConfig `yaml:"postgres" mapstructure:"postgres"`
	RabbitMQ RabbitMQConfig   `yaml:"rabbitmq" mapstructure:"rabbitmq"`
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
