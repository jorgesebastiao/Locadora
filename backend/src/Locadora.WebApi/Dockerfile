FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

WORKDIR /src
COPY ["./Locadora.WebApi/Locadora.WebApi.csproj", "Locadora.WebApi/"]
COPY ["./Locadora.Application/Locadora.Application.csproj", "Locadora.Application/"]
COPY ["./Locadora.Domain/Locadora.Domain.csproj", "Locadora.Domain/"]
COPY ["./Locadora.Infra.Data/Locadora.Infra.Data.csproj", "Locadora.Infra.Data/"]
COPY ["./Locadora.Core/Locadora.Core.csproj", "Locadora.Core/"]

RUN dotnet restore "Locadora.WebApi/Locadora.WebApi.csproj"
COPY . .
WORKDIR "/src/Locadora.WebApi"
RUN dotnet build "Locadora.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Locadora.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Locadora.WebApi.dll"]