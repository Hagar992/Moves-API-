# Moves(API)

## Description

The Movie Management API is a RESTful service built using ASP.NET Core that enables you to manage a movie database. This API provides CRUD (Create, Read, Update, Delete) operations for movies and genres, along with JWT-based authentication to secure the endpoints. The project also includes Swagger for API documentation and Postman for testing the API endpoints.
_____________________________
## Features

- **CRUD Operations** for movies and genres
- **Swagger** for easy API exploration
- **Postman Collection** for easy testing of the endpoints
- **Entity Framework Core** with SQL Server for database interactions
_______________________________
## Tools & Technologies

- **ASP.NET Core Web API**: Framework used to build the API
- **Entity Framework Core**: ORM for data access with SQL Server
- **Swagger**: Auto-generated API documentation for testing and exploring the API
- **Postman**: Tool used for testing the API endpoints

______________________________________

## API Endpoints

### Movies

- **GET /api/movies**: Get all movies
- **GET /api/movies/{id}**: Get a specific movie by ID
- **POST /api/movies**: Create a new movie
- **PUT /api/movies/{id}**: Update an existing movie
- **DELETE /api/movies/{id}**: Delete a movie

### Genres

- **GET /api/genres**: Get all genres
- **GET /api/genres/{id}**: Get a specific genre by ID
- **POST /api/genres**: Create a new genre
- **PUT /api/genres/{id}**: Update an existing genre
- **DELETE /api/genres/{id}**: Delete a genre
__________________________________
## Testing

You can test the API using **Postman**. A Postman collection has been included to simplify testing of all available endpoints.

