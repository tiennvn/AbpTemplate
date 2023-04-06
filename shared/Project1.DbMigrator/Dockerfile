#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["shared/Project1.DbMigrator/Project1.DbMigrator.csproj", "shared/Project1.DbMigrator/"]
COPY ["services/saas/src/Project1.SaaS.Application.Contracts/Project1.SaaS.Application.Contracts.csproj", "services/saas/src/Project1.SaaS.Application.Contracts/"]
COPY ["services/saas/src/Project1.SaaS.Domain.Shared/Project1.SaaS.Domain.Shared.csproj", "services/saas/src/Project1.SaaS.Domain.Shared/"]
COPY ["shared/Project1.Microservice.Shared/Project1.Microservice.Shared.csproj", "shared/Project1.Microservice.Shared/"]
COPY ["services/administration/src/Project1.Administration.EntityFrameworkCore/Project1.Administration.EntityFrameworkCore.csproj", "services/administration/src/Project1.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/Project1.Administration.Domain/Project1.Administration.Domain.csproj", "services/administration/src/Project1.Administration.Domain/"]
COPY ["services/administration/src/Project1.Administration.Domain.Shared/Project1.Administration.Domain.Shared.csproj", "services/administration/src/Project1.Administration.Domain.Shared/"]
COPY ["shared/Project1.Hosting.Shared/Project1.Hosting.Shared.csproj", "shared/Project1.Hosting.Shared/"]
COPY ["services/identity/src/Project1.IdentityService.Application.Contracts/Project1.IdentityService.Application.Contracts.csproj", "services/identity/src/Project1.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/Project1.IdentityService.Domain.Shared/Project1.IdentityService.Domain.Shared.csproj", "services/identity/src/Project1.IdentityService.Domain.Shared/"]
COPY ["services/saas/src/Project1.SaaS.EntityFrameworkCore/Project1.SaaS.EntityFrameworkCore.csproj", "services/saas/src/Project1.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/Project1.SaaS.Domain/Project1.SaaS.Domain.csproj", "services/saas/src/Project1.SaaS.Domain/"]
COPY ["services/identity/src/Project1.IdentityService.EntityFrameworkCore/Project1.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Project1.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/Project1.IdentityService.Domain/Project1.IdentityService.Domain.csproj", "services/identity/src/Project1.IdentityService.Domain/"]
COPY ["services/administration/src/Project1.Administration.Application.Contracts/Project1.Administration.Application.Contracts.csproj", "services/administration/src/Project1.Administration.Application.Contracts/"]
RUN dotnet restore "shared/Project1.DbMigrator/Project1.DbMigrator.csproj"
COPY . .
WORKDIR "/src/shared/Project1.DbMigrator"
RUN dotnet build "Project1.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project1.DbMigrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project1.DbMigrator.dll"]