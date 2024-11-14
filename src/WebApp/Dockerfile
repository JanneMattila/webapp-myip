# https://hub.docker.com/r/microsoft/dotnet
# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0.0-alpine3.20-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0.100-alpine3.20-amd64 AS build
WORKDIR /src
COPY ["src/WebApp/WebApp.csproj", "src/WebApp/"]
RUN dotnet restore "src/WebApp/WebApp.csproj"
COPY . .
WORKDIR "/src/src/WebApp"
RUN dotnet build "WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApp.dll"]
