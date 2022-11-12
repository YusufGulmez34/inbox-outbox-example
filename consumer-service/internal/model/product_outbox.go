package model

import (
	"time"

	"github.com/google/uuid"
)

type ProductOutbox struct {
	Id          int `gorm:"primarykey"`
	Guid        uuid.UUID
	Payload     string
	Type        string
	ProcessDate time.Time
}
