# Syriatech.org
Welcome to the Syriatech.org Community Source Code.

The mission of the Syria Tech Community is to represent, inspire, support, and help lead the Syrian technology community and ecosystem to create a better future for all. Led by group of tech companies and expert syrian influencers, the Syria Tech Community focus on issues important to the technology sector and Syria.

Visit: [Syriatech.org](http://syriatech.org)

Project Source Page: [https://waleedchayeb.github.io/Syriatech.org/](https://waleedchayeb.github.io/Syriatech.org/)

![Syriatech Logo](http://syriatech.org/img/bak.png)


## Syriatech.org Tech Stack and Features
* .Net Core 2.2
* Code First
* Clean Architecture
* MS SQL Database
* Hosted on Windows Azure
* ASP.NET Identity
* MVC
* API enabled for certain operations
* Razor view Engine, Razor Pages
* Html, Css, Javascript
* Bootstrap 4

## Syriatech.org Software Architecture
I used the Clean Architecture or what it used to be called Hexagonal Architecture, Onion Architecture or DDD. 

As descriped in Microsoft's Official documentation:
> Clean architecture puts the business logic and application model at the center of the application. Instead of having business logic depend on data access or other infrastructure concerns, this dependency is inverted: infrastructure and implementation details depend on the Application Core.


![Clean Architecture](https://docs.microsoft.com/en-us/dotnet/standard/modern-web-apps-azure-architecture/media/image5-7.png)


### Project Layers
* Core
  * Syriatech.Application: Contains all logical operations
  * Syriatech.Domain: Contains the basic entities.
* Infrastructure
  * Syriatech.Persistence: The data Layer
* Presentation 
  * Syriatech.WebUI: Contains the Web.API and the .Core MVC Website
  

## Syriatech.org Open API
If you are interested in building an application on top of Syriatech.org you can use the following open APIs:
  
### Events 
``` 
/api/activities/
/api/activities/{id}
```
  
### Profiles
``` 
/api/users
/api/users/{username}
```
  
### Projects
``` 
/api/projects
/api/projects/{id}
```

## Contributing
Syriatech.org is under MIT License, you can fork it to develop any new feature, then if its working fine I will publish it to the running website. The credit of the new feature will be for the developer and it will hold his/her name as a feature title.

You can also replicate this project to build another community, like: Lebtech, Egytech, Iraqtech ... etc Please reach out if you have any related question: 

**Waleed Chayeb**: waleedchayeb2@gmail.com

Follow the project changes log here:
[Syriatech.org/log](http://syriatech.org/log)

  
  
  
  
  
  
