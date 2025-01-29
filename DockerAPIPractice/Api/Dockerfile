# First stage: base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Second stage: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy only the .csproj first (adjust name/folder as needed)
COPY ["DockerAPIPractice.csproj", "./"]

# Restore dependencies
RUN dotnet restore "DockerAPIPractice.csproj"

# Copy the rest of your source
COPY . .

# Build your project
RUN dotnet build "DockerAPIPractice.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Third stage: publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DockerAPIPractice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage: runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerAPIPractice.dll"]
