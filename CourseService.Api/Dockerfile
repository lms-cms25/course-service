# Bygger applikationen
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Kopierar projektfil
COPY *.csproj .

# Installerar paket
RUN dotnet restore

# Kopierar resten av projektet
COPY . .

# Publicerar projektet
RUN dotnet publish -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

# Kopierar publicerad app
COPY --from=build /app/publish .

# Öppnar port
EXPOSE 8080

# Startar applikationen
ENTRYPOINT ["dotnet", "CourseService.Api.dll"]