# Usa la imagen base de ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Usa la imagen base de SDK para construir el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ProveedoresAPI/ProveedoresAPI.csproj", "ProveedoresAPI/"]
RUN dotnet restore "ProveedoresAPI/ProveedoresAPI.csproj"
COPY . .
WORKDIR "/src/ProveedoresAPI"
RUN dotnet build "ProveedoresAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProveedoresAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProveedoresAPI.dll"]
