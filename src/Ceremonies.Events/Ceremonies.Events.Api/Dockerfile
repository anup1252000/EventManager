#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ceremonies.Events.Api/Ceremonies.Events.Api.csproj", "Ceremonies.Events.Api/"]
COPY ["Ceremonies.Events.Infrastructure/Ceremonies.Events.Infrastructure.csproj", "Ceremonies.Events.Infrastructure/"]
COPY ["Ceremonies.Events.Core/Ceremonies.Events.Core.csproj", "Ceremonies.Events.Core/"]
RUN dotnet restore "Ceremonies.Events.Api/Ceremonies.Events.Api.csproj"
COPY . .
WORKDIR "/src/Ceremonies.Events.Api"
RUN dotnet build "Ceremonies.Events.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ceremonies.Events.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ceremonies.Events.Api.dll"]