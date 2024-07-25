FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Defina permissões para o diretório /app e o arquivo tempkey.jwk
RUN chmod -R 755 /app && chown -R root:root /app

# Defina o usuário para root
USER root

ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Authenticate.API/Authenticate.API.csproj", "src/Authenticate.API/"]
RUN dotnet restore "src/Authenticate.API/Authenticate.API.csproj"
COPY . .
WORKDIR "/src/src/Authenticate.API"
RUN dotnet build "Authenticate.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Authenticate.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authenticate.API.dll"]