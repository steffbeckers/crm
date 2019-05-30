FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CRM.API.csproj", "CRM.API/"]
RUN dotnet restore "CRM.API/CRM.API.csproj"
COPY . "CRM.API/"
WORKDIR "/src/CRM.API"
RUN dotnet build "CRM.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CRM.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CRM.API.dll"]