FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine3.13 AS build

WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet build
RUN dotnet publish src/Vulder.Search.Api -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine3.13

WORKDIR /app

COPY --from=build /app .

ENTRYPOINT [ "dotnet", "Vulder.Search.Api.dll" ]