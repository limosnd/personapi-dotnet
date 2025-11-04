# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Instalar curl (la imagen aspnet usa Debian)
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

# Forzar la aplicación a escuchar en el puerto80 dentro del contenedor
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "personapi-dotnet.dll"]