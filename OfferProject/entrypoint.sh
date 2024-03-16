#!/bin/bash


# Wait for MySQL to be ready
/usr/local/bin/wait-for-it.sh mysqldb:3306 --timeout=30 --strict -- echo "MySQL is ready"
/root/.dotnet/tools/dotnet-ef database update --project API 

# Start your .NET API service
dotnet out/API.dll
