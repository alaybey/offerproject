# Use the base SDK image from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Set the runtime environment
ENV ASPNETCORE_URLS=http://+:5212

# Copy the wait-for-it.sh script and make it executable
ADD https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh /usr/local/bin/wait-for-it.sh
RUN chmod +x /usr/local/bin/wait-for-it.sh

# Install dotnet-ef tool
RUN dotnet tool install --global dotnet-ef --version 8.0.1
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copy entrypoint script
COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh
EXPOSE 5212
# Set the entrypoint
ENTRYPOINT ["/entrypoint.sh"]
