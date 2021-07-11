FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine3.13 AS build

WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet publish src/Vulder.Search.Api -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine3.13

WORKDIR /app

COPY --from=build /app .
ENV MongoServer=mongodb://192.168.1.8:27017 
EXPOSE 80

ENTRYPOINT [ "dotnet", "Vulder.Search.Api.dll" ]