# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./services/BTG.Ecommerce.API/BTG.Ecommerce.API.csproj", "services/BTG.Ecommerce.API/"]
COPY ["./building blocks/BTG.Core/BTG.Core.csproj", "building blocks/BTG.Core/"]
COPY ["./building blocks/BTG.MessageBus/BTG.MessageBus.csproj", "building blocks/BTG.MessageBus/"]
COPY ["./building blocks/BTG.WebAPI.Core/BTG.WebAPI.Core.csproj", "building blocks/BTG.WebAPI.Core/"]
COPY ["./services/BTG.Ecommerce.Application/BTG.Ecommerce.Application.csproj", "services/BTG.Ecommerce.Application/"]
COPY ["./services/BTG.Ecommerce.Domain/BTG.Ecommerce.Domain.csproj", "services/BTG.Ecommerce.Domain/"]
COPY ["./services/BTG.Ecommerce.Infra/BTG.Ecommerce.Infra.csproj", "services/BTG.Ecommerce.Infra/"]
RUN dotnet restore "services/BTG.Ecommerce.API/BTG.Ecommerce.API.csproj"
COPY . .
WORKDIR "./services/BTG.Ecommerce.API"
RUN dotnet build "./BTG.Ecommerce.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BTG.Ecommerce.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BTG.Ecommerce.API.dll"]