#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/IdestAltoGiroApp.Api/IdestAltoGiroApp.Api.csproj", "src/IdestAltoGiroApp.Api/"]
COPY ["src/IdestAltoGiroApp.Application/IdestAltoGiroApp.Application.csproj", "src/IdestAltoGiroApp.Application/"]
COPY ["src/IdestAltoGiroApp.Domain/IdestAltoGiroApp.Domain.csproj", "src/IdestAltoGiroApp.Domain/"]
COPY ["src/IdestAltoGiroApp.Infra/IdestAltoGiroApp.Infra.csproj", "src/IdestAltoGiroApp.Infra/"]
COPY ["src/IdestAltoGiroApp.IoC/IdestAltoGiroApp.IoC.csproj", "src/IdestAltoGiroApp.IoC/"]
RUN dotnet restore "src/IdestAltoGiroApp.Api/IdestAltoGiroApp.Api.csproj"
COPY . .
WORKDIR "/src/src/IdestAltoGiroApp.Api"
RUN dotnet build "IdestAltoGiroApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdestAltoGiroApp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdestAltoGiroApp.Api.dll"]