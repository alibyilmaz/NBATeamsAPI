#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Alfabe.API/Alfabe.API.csproj", "Alfabe.API/"]
COPY ["Alfabe.Core/Alfabe.Core.csproj", "Alfabe.Core/"]
RUN dotnet restore "Alfabe.API/Alfabe.API.csproj"
COPY . .
WORKDIR "/src/Alfabe.API"
RUN dotnet build "Alfabe.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Alfabe.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Alfabe.API.dll"]