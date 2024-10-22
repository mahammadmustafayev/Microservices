FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Course.Shared/*.csproj Shared/Course.Shared/
COPY Services/Catalog/CourseMicroservices.Catalog/*.csproj Services/Catalog/CourseMicroservices.Catalog/
RUN dotnet restore Services/Catalog/CourseMicroservices.Catalog/*.csproj
COPY . .
RUN dotnet publish Services/Catalog/CourseMicroservices.Catalog/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","CourseMicroservices.Catalog.dll" ]