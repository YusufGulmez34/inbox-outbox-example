package model

import "github.com/google/uuid"

type ProductInbox struct {
	Guid    uuid.UUID `gorm:"primarykey"`
	Payload string
	Type    string
	Proceed bool
}
