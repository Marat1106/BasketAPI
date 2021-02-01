#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Catalog3.API/Catalog3.API.csproj", "Catalog3.API/"]
RUN dotnet restore "Catalog3.API/Catalog3.API.csproj"
COPY . .
WORKDIR "/src/Catalog3.API"
RUN dotnet build "Catalog3.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog3.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog3.API.dll"]
