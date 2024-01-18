#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/steambird.client/nuget.config", "src/steambird.client/"]
COPY ["src/Steambird.Server/Steambird.Server.csproj", "src/Steambird.Server/"]
COPY ["src/steambird.client/steambird.client.esproj", "src/steambird.client/"]
COPY ["src/Steambird.ImageGeneration/Steambird.ImageGeneration.csproj", "src/Steambird.ImageGeneration/"]
COPY ["src/Steambird.Logging/Steambird.Logging.csproj", "src/Steambird.Logging/"]
RUN dotnet restore "./src/Steambird.Server/./Steambird.Server.csproj"
COPY . .
WORKDIR "/src/src/Steambird.Server"
RUN dotnet build "./Steambird.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Steambird.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Steambird.Server.dll"]