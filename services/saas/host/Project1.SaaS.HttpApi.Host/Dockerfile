#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/host/Project1.SaaS.HttpApi.Host/Project1.SaaS.HttpApi.Host.csproj", "services/saas/host/Project1.SaaS.HttpApi.Host/"]
COPY ["shared/Project1.Hosting.Shared/Project1.Hosting.Shared.csproj", "shared/Project1.Hosting.Shared/"]
COPY ["services/administration/src/Project1.Administration.EntityFrameworkCore/Project1.Administration.EntityFrameworkCore.csproj", "services/administration/src/Project1.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/Project1.Administration.Domain/Project1.Administration.Domain.csproj", "services/administration/src/Project1.Administration.Domain/"]
COPY ["services/administration/src/Project1.Administration.Domain.Shared/Project1.Administration.Domain.Shared.csproj", "services/administration/src/Project1.Administration.Domain.Shared/"]
COPY ["services/saas/src/Project1.SaaS.HttpApi/Project1.SaaS.HttpApi.csproj", "services/saas/src/Project1.SaaS.HttpApi/"]
COPY ["services/saas/src/Project1.SaaS.Application.Contracts/Project1.SaaS.Application.Contracts.csproj", "services/saas/src/Project1.SaaS.Application.Contracts/"]
COPY ["services/saas/src/Project1.SaaS.Domain.Shared/Project1.SaaS.Domain.Shared.csproj", "services/saas/src/Project1.SaaS.Domain.Shared/"]
COPY ["services/saas/src/Project1.SaaS.Application/Project1.SaaS.Application.csproj", "services/saas/src/Project1.SaaS.Application/"]
COPY ["services/saas/src/Project1.SaaS.Domain/Project1.SaaS.Domain.csproj", "services/saas/src/Project1.SaaS.Domain/"]
COPY ["services/saas/src/Project1.SaaS.EntityFrameworkCore/Project1.SaaS.EntityFrameworkCore.csproj", "services/saas/src/Project1.SaaS.EntityFrameworkCore/"]
RUN dotnet restore "services/saas/host/Project1.SaaS.HttpApi.Host/Project1.SaaS.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/saas/host/Project1.SaaS.HttpApi.Host"
RUN dotnet build "Project1.SaaS.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project1.SaaS.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project1.SaaS.HttpApi.Host.dll"]