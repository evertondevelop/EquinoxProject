# This Dockerfile is used to build a container image for an ASP.NET Core 5.0 web application.
# It uses a multi-stage build process to separate the build and runtime environments.

# The first stage (base) sets up the runtime environment for the application.
# It is based on the official ASP.NET Core 5.0 runtime image from Microsoft.
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
# The working directory is set to /app.
WORKDIR /app
# The container listens on ports 80 and 443.
EXPOSE 80
EXPOSE 4
