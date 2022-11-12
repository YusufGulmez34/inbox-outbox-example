package config

import (
	"publisher-service/constant"

	"github.com/spf13/viper"
)

var (
	appConfig AppConfiguration
)

func init() {
	viper.AddConfigPath(constant.ConfigPath)
	viper.SetConfigType(constant.ConfigType)
	appConfig = readApplicationConfig()
}

type ConfigurationManager struct {
	appConfig AppConfiguration
}

func NewConfigurationManager() *ConfigurationManager {
	return &ConfigurationManager{appConfig: appConfig}
}

func (c *ConfigurationManager) GetPostgreSQLConfig() PostgreSQLConfig {
	return c.appConfig.Postgres
}

func (c *ConfigurationManager) GetRabbitMQConfig() RabbitMQConfig {
	return c.appConfig.RabbitMQ
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
