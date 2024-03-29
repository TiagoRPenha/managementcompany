#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Management.Api/Management.Api.csproj", "src/Management.Api/"]
COPY ["src/Management.Infrastructure/Management.Infrastructure.csproj", "src/Management.Infrastructure/"]
COPY ["src/Management.Core/Management.Core.csproj", "src/Management.Core/"]
COPY ["src/Management.Application/Management.Application.csproj", "src/Management.Application/"]
RUN dotnet restore "./src/Management.Api/Management.Api.csproj"
COPY . .
WORKDIR "/src/src/Management.Api"
RUN dotnet build "./Management.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Management.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Management.Api.dll"]