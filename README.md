## Features

In a project where the write and read databases are separated using the CQRS model, a Product object has been managed. The frequently applied in-outbox pattern is used to prevent possible data loss.

## Architecture
![Alt text](https://user-images.githubusercontent.com/64227421/201480413-a51689d8-6a89-4451-be8e-2fe8e50f43f4.png)

As seen here, a message is sent to rabbitmq after the change is made. Publisher service runs at certain time intervals, checks the Outbox table and sends the changes to RabbitMQ. The Consumer service listens to rabbitmq and sends the changes to the inbox table and mongodb database.

## Run
This command is run in the project directory to run the project on docker.
```bash
docker-compose up -d
```
