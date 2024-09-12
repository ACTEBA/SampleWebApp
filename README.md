# Sample Web App 

A simple open source .NET Web Application implementing rudimentary product management

# Features

This application demonstrates key .NET features including:

* ASP.NET Core Identity (individual accounts)
* Role based access to resources (only users with Administrator role can create, edit or delete products)
* Seeding initial data with migrations
* Sample Razor pages UI
* Sample REST APIs (controllers and services)
* Sample front-end (using APIs) using [RESTool](https://github.com/dsternlicht/RESTool)
* Unit tests with DI (database context)

# Build and deploy


To run locally, first run database migrations:

```
dotnet ef database update                
```

This will create local database, schema and seed default user with Administrator role (admin@website.test/Password!123). 

You will also need to update the baseUrl property in the config.json file under the wwwroot folder in order to test API frontend.

Additional users can register using default Razer UI or [IdenityAPI endpoints](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity-api-authorization?view=aspnetcore-8.0).
