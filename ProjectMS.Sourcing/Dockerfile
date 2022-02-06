#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProjectMS.Sourcing/ProjectMS.Sourcing.csproj", "ProjectMS.Sourcing/"]
COPY ["EventBusRabbitMQ/EventBusRabbitMQ.csproj", "EventBusRabbitMQ/"]
RUN dotnet restore "ProjectMS.Sourcing/ProjectMS.Sourcing.csproj"
COPY . .
WORKDIR "/src/ProjectMS.Sourcing"
RUN dotnet build "ProjectMS.Sourcing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectMS.Sourcing.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectMS.Sourcing.dll"]