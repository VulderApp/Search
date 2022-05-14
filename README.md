# Search
[![Test](https://github.com/VulderApp/Search/actions/workflows/test.yml/badge.svg)](https://github.com/VulderApp/Search/actions/workflows/test.yml)
[![codecov](https://codecov.io/gh/VulderApp/Search/branch/dev/graph/badge.svg?token=WHF3E0HBIH)](https://codecov.io/gh/VulderApp/Search)

Microservice responsible for school management

## Run development server
```bash
$ docker-compose -f docker-compose.dev.yml up -d
$ dotnet restore
$ dotnet watch --project ./src/Vulder.School.Api
```

## Build a release
```bash
$ dotnet restore
$ dotnet build
$ dotnet publish ./src/Vulder.School.Api -c Release
```

## Build a docker image
```bash
$ docker build -t vulderapp/school:release .
```
## Run a docker image
```bash
$ docker run -p 80:80 -e MONGODB_CONNECTION_STRING=connection_string -e REDIS_CONNECTION_STRING=connection_string vulderapp/school:release
```
