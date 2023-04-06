#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/identity/host/Project1.IdentityService.HttpApi.Host/Project1.IdentityService.HttpApi.Host.csproj", "services/identity/host/Project1.IdentityService.HttpApi.Host/"]
COPY ["shared/Project1.Hosting.Shared/Project1.Hosting.Shared.csproj", "shared/Project1.Hosting.Shared/"]
COPY ["services/administration/src/Project1.Administration.EntityFrameworkCore/Project1.Administration.EntityFrameworkCore.csproj", "services/administration/src/Project1.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/Project1.Administration.Domain/Project1.Administration.Domain.csproj", "services/administration/src/Project1.Administration.Domain/"]
COPY ["services/administration/src/Project1.Administration.Domain.Shared/Project1.Administration.Domain.Shared.csproj", "services/administration/src/Project1.Administration.Domain.Shared/"]
COPY ["services/saas/src/Project1.SaaS.EntityFrameworkCore/Project1.SaaS.EntityFrameworkCore.csproj", "services/saas/src/Project1.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/Project1.SaaS.Domain/Project1.SaaS.Domain.csproj", "services/saas/src/Project1.SaaS.Domain/"]
COPY ["services/saas/src/Project1.SaaS.Domain.Shared/Project1.SaaS.Domain.Shared.csproj", "services/saas/src/Project1.SaaS.Domain.Shared/"]
COPY ["services/identity/src/Project1.IdentityService.HttpApi/Project1.IdentityService.HttpApi.csproj", "services/identity/src/Project1.IdentityService.HttpApi/"]
COPY ["services/identity/src/Project1.IdentityService.Application.Contracts/Project1.IdentityService.Application.Contracts.csproj", "services/identity/src/Project1.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/Project1.IdentityService.Domain.Shared/Project1.IdentityService.Domain.Shared.csproj", "services/identity/src/Project1.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/Project1.IdentityService.Application/Project1.IdentityService.Application.csproj", "services/identity/src/Project1.IdentityService.Application/"]
COPY ["services/identity/src/Project1.IdentityService.Domain/Project1.IdentityService.Domain.csproj", "services/identity/src/Project1.IdentityService.Domain/"]
COPY ["services/identity/src/Project1.IdentityService.EntityFrameworkCore/Project1.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Project1.IdentityService.EntityFrameworkCore/"]
RUN dotnet restore "services/identity/host/Project1.IdentityService.HttpApi.Host/Project1.IdentityService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/identity/host/Project1.IdentityService.HttpApi.Host"
RUN dotnet build "Project1.IdentityService.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project1.IdentityService.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project1.IdentityService.HttpApi.Host.dll"]