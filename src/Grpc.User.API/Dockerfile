FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Grpc.User.API/Grpc.Users.API.csproj", "src/Grpc.User.API/"]
RUN dotnet restore "src/Grpc.User.API/Grpc.Users.API.csproj"
COPY . .
WORKDIR "/src/src/Grpc.User.API"
RUN dotnet build "Grpc.Users.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Grpc.Users.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Grpc.Users.API.dll"]