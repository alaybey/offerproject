# Offer Case 

This project is a sample application demonstrating the integration of a .NET Core Web API and an Angular application using Docker Compose. It also includes MySQL as a database service.

## Prerequisites

Before running the project, ensure that you have the following installed:

- Docker
- Docker Compose

## Getting Started

1. Clone this repository to your local machine:
    
    `git clone https://github.com/alaybey/offerproject.git`

2. Navigate to the root directory of the project:

    `cd offerproject`

3. Build and run the Docker containers using Docker Compose:

    `docker-compose up --build`

4. Once the containers are up and running, you can access the .NET Core Web API at:

   http://localhost:5212

   and the Angular application at:

   http://localhost:4200

## Project Structure

- `api/`: Contains the .NET Core Web API project with its Dockerfile.
- `angular/`: Contains the Angular application with its Dockerfile.
- `docker-compose.yml`: Defines the Docker services and their configurations.

## Docker Compose Services

- **api**: Runs the .NET Core Web API container, accessible at `http://localhost:5212`.
- **angular**: Runs the Angular application container, accessible at `http://localhost:4200`.
- **mysql**: Runs the MySQL database container, accessible at `localhost:3306`. The default credentials are:
  - Username: root
  - Password: my_secret_password
  - Database: tempdb

## Usage

- To stop the containers, press `Ctrl + C` in the terminal where Docker Compose is running.
- To remove the containers and associated resources, run:

## Without docker
If you want to install and use without docker, run these commands when inside cloned repository. 

A MySQL Database running with able to this connection string:  `database=tempdb;user=root;password=my-secret-pw` or you can change your configs.

#### Dotnet
Please use dotnet sdk 8.0.1 version:
    
    cd OfferProject

    dotnet tool install --global dotnet-ef --version 8.0.1

    dotnet-ef migrations add Initial --project API

    dotnet-ef database update --project API

    dotnet build
    
    dotnet run --project API

And edit `appsettings.json` to replace ConnectionString key with this: `"server=localhost;database=tempdb;user=root;password=my-secret-pw;sslmode=Required"`  

Purpose: `mysqldb` renamed to `localhost` 

You can reach from `http://localhost:5212`

#### Angular

NodeJs(suggest version 20) must be installed:

    cd OfferCaseUI
    npm install -g @angular/cli
    npm install 
    npm run start

You can reach to UI app from `http://localhost:4200`

### Additional Note
You can set angular environment values from `./OfferCaseUI/src/environment/environment.ts`

I did not use environment variables for dotnet web api because it will require extra configs for github action(CI/CD pipelines). You can edit `launchSettings.json` and `appsettings.json`

