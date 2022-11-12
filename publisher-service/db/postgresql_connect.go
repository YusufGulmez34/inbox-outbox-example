package db

import (
	"fmt"
	"publisher-service/config"
	"publisher-service/constant"

	"gorm.io/driver/postgres"
	"gorm.io/gorm"
)

func PGConnect(config config.PostgreSQLConfig) *gorm.DB {
	dsn := fmt.Sprintf(constant.PgConnectionString, config.Host, config.User, config.Password, config.Database, config.Port)
	db, err := gorm.Open(postgres.Open(dsn), &gorm.Config{})
	if err != nil {
		panic(err.Error())
	}
	return db
}
