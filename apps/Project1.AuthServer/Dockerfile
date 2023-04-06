#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["apps/Project1.AuthServer/Project1.AuthServer.csproj", "apps/Project1.AuthServer/"]
COPY ["services/administration/src/Project1.Administration.EntityFrameworkCore/Project1.Administration.EntityFrameworkCore.csproj", "services/administration/src/Project1.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/Project1.Administration.Domain/Project1.Administration.Domain.csproj", "services/administration/src/Project1.Administration.Domain/"]
COPY ["services/administration/src/Project1.Administration.Domain.Shared/Project1.Administration.Domain.Shared.csproj", "services/administration/src/Project1.Administration.Domain.Shared/"]
COPY ["services/identity/src/Project1.IdentityService.EntityFrameworkCore/Project1.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Project1.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/Project1.IdentityService.Domain/Project1.IdentityService.Domain.csproj", "services/identity/src/Project1.IdentityService.Domain/"]
COPY ["services/identity/src/Project1.IdentityService.Domain.Shared/Project1.IdentityService.Domain.Shared.csproj", "services/identity/src/Project1.IdentityService.Domain.Shared/"]
COPY ["services/saas/src/Project1.SaaS.EntityFrameworkCore/Project1.SaaS.EntityFrameworkCore.csproj", "services/saas/src/Project1.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/Project1.SaaS.Domain/Project1.SaaS.Domain.csproj", "services/saas/src/Project1.SaaS.Domain/"]
COPY ["services/saas/src/Project1.SaaS.Domain.Shared/Project1.SaaS.Domain.Shared.csproj", "services/saas/src/Project1.SaaS.Domain.Shared/"]
COPY ["shared/Project1.Microservice.Shared/Project1.Microservice.Shared.csproj", "shared/Project1.Microservice.Shared/"]
COPY ["shared/Project1.Hosting.Shared/Project1.Hosting.Shared.csproj", "shared/Project1.Hosting.Shared/"]
RUN dotnet restore "apps/Project1.AuthServer/Project1.AuthServer.csproj"
COPY . .
WORKDIR "/src/apps/Project1.AuthServer"
RUN dotnet build "Project1.AuthServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project1.AuthServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project1.AuthServer.dll"]