# Calendar

[![Postgres](https://img.shields.io/badge/Postgres-%23316192.svg?logo=postgresql&logoColor=white)](#)
[![Docker](https://img.shields.io/badge/Docker-2496ED?logo=docker&logoColor=fff)](#)
[![.Net 9](https://img.shields.io/badge/.NET%209-5C2D91?logo=.net&logoColor=white)](#)


Calendar is a simple Web API project written in c#. The application follows the RESTful API convention and implements the CQRS pattern along with basic principles of DDD.

## Tech Stack

**Database:** PostgreSQL

**ORM:** Entity Framework Core

**Conternerization:** Docker (automatic database setup from Dockerfile)

## Lessons Learned

During the development of this project, I learned basics of several key technologies and architectural principles:

**Docker:** Configuring and automating the setup of a PostgreSQL database via Dockerfile, ensuring seamless environment replication

**PostgreSQL:** Acquiring a foundational understanding of relational database management

**EF Core:** Gaining experience in implementing Entity Framework Core, including database migrations, entity configuration and utilizing it as an Object-Relational Mapper (ORM) to streamline data operations

**Swagger & ReDoc:** Learned to use Swagger and ReDoc for automatic API documentation, enabling interactive and up-to-date documentation for smooth API consumption and testing

**Architecture:** Deepening my understanding of modern software architecture principles, including CQRS, DDD and SOLID