#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/projects/NuGet.Config", "services/projects/"]
COPY ["services/projects/host/Project1.Projects.HttpApi.Host/Project1.Projects.HttpApi.Host.csproj", "services/projects/host/Project1.Projects.HttpApi.Host/"]
COPY ["services/projects/src/Project1.Projects.HttpApi/Project1.Projects.HttpApi.csproj", "services/projects/src/Project1.Projects.HttpApi/"]
COPY ["services/projects/src/Project1.Projects.Application.Contracts/Project1.Projects.Application.Contracts.csproj", "services/projects/src/Project1.Projects.Application.Contracts/"]
COPY ["services/projects/src/Project1.Projects.Domain.Shared/Project1.Projects.Domain.Shared.csproj", "services/projects/src/Project1.Projects.Domain.Shared/"]
COPY ["services/projects/src/Project1.Projects.Application/Project1.Projects.Application.csproj", "services/projects/src/Project1.Projects.Application/"]
COPY ["services/projects/src/Project1.Projects.Domain/Project1.Projects.Domain.csproj", "services/projects/src/Project1.Projects.Domain/"]
COPY ["services/projects/src/Project1.Projects.EntityFrameworkCore/Project1.Projects.EntityFrameworkCore.csproj", "services/projects/src/Project1.Projects.EntityFrameworkCore/"]
RUN dotnet restore "services/projects/host/Project1.Projects.HttpApi.Host/Project1.Projects.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/projects/host/Project1.Projects.HttpApi.Host"
RUN dotnet build "Project1.Projects.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project1.Projects.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project1.Projects.HttpApi.Host.dll"]