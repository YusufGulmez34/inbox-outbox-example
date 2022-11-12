package config

import (
	"consumer-service/constant"

	"github.com/spf13/viper"
)

var (
	appConfig    AppConfiguration
	queuesConfig QueuesConfig
)

func init() {
	viper.AddConfigPath(constant.ConfigPath)
	viper.SetConfigType(constant.ConfigType)
	appConfig = readApplicationConfig()
	queuesConfig = readQueuesConfig()
}

type ConfigurationManager struct {
	appConfig    AppConfiguration
	queuesConfig QueuesConfig
}

func NewConfigurationManager() *ConfigurationManager {
	return &ConfigurationManager{appConfig: appConfig, queuesConfig: queuesConfig}
}

func (c *ConfigurationManager) GetPostgreSQLConfig() PostgreSQLConfig {
	return c.appConfig.Postgres
}

func (c *ConfigurationManager) GetRabbitMQConfig() RabbitMQConfig {
	return c.appConfig.RabbitMQ
}
func (c *ConfigurationManager) GetMongoDbConfig() MongoDbConfig {
	return c.appConfig.MongoDb
}
func (c *ConfigurationManager) GetQueuesConfig() QueuesConfig {
	return c.queuesConfig
}

func readQueuesConfig() QueuesConfig {
	viper.SetConfigName("queue")
	if err := viper.ReadInConfig(); err != nil {
		panic(err.Error())
	}
	var queuesConfig QueuesConfig
	if err := viper.Unmarshal(&queuesConfig); err != nil {
		panic(err.Error())
	}
	return queuesConfig
}

func readApplicationConfig() AppConfiguration {
	viper.SetConfigName("config")
	if err := viper.ReadInConfig(); err != nil {
		panic(err.Error())
	}
	var appConfig AppConfiguration
	if err := viper.Unmarshal(&appConfig); err != nil {
		panic(err.Error())
	}
	return appConfig
}
