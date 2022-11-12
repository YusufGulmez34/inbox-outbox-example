package constant

const (
	PgConnectionString       = "host=%s user=%s password=%s dbname=%s port=%d sslmode=disable"
	RabbitMqConnectionString = "amqp://%s:%s@%s:%d/"
	MongoDbConnectionString  = "mongodb://%s:%d"
	ConfigPath               = "./"
	ConfigType               = "yaml"
)
