# Create aplication REST with .NET Core 5 in Visual Studio Code, Docker and Ubuntu.

## Create solution
dotnet new sln -o net-core-5-vscode

## Create a new webapi project within the solution
dotnet new webapi -o restWebApiBooks

## Add project to solution
dotnet sln add ./restWebApiBooks/restWebApiBooks.csproj

## Run project
dotnet run --project restWebApiBooks

## Install SQL SERVER in docker
docker run --name mssqlexpress -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=pwd!SA_Express' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu

## Create Database
CREATE DATABASE netcore5;

## Install pakages
dotnet add package Evolve 
dotnet add package Microsoft.AspNetCore.Mvc.Versioning
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Serilog
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Swashbuckle.AspNetCore

## Configure debug
In my localhost debug is not run, i needed to change the configuration:
In tasks.json change value from tasks.command = "dotnet" to folder path dotnet, in my localhost "/home/daniel/dotnet/dotnet"