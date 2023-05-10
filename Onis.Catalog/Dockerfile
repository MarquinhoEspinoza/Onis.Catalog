#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Onis.Catalog/Onis.Catalog.csproj", "Onis.Catalog/"]
RUN dotnet restore "Onis.Catalog/Onis.Catalog.csproj"
COPY . .
WORKDIR "/src/Onis.Catalog"
RUN dotnet build "Onis.Catalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onis.Catalog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onis.Catalog.dll"]