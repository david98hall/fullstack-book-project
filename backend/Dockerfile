# -- 1. Set up base environment for .NET application --
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
# The backend will serve HTTP web requests on this port
EXPOSE 5000

# -- 2. Compiling the backend application --
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
# Copy the backend.csproj file to the container's /src directory
COPY ["backend.csproj", "./"]
# Restore dependencies, etc, in order to be able to build
RUN dotnet restore "./backend.csproj"
# Copy all files from the host's current directory to the container's /src directory
COPY . .
# Compile the application to a release-optimized build
RUN dotnet build "backend.csproj" -c Release -o /app/build

# -- 3. Create and publish a version of the application that is ready for deployment --
FROM build AS publish
RUN dotnet publish "backend.csproj" -c Release -o /app/publish

# -- 4. Create the final, deployable, container image based on the application build
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend.dll"]