FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Course.Shared/*.csproj Shared/Course.Shared/
COPY Services/PhotoStock/CourseMicroservices.PhotoStock/*.csproj Services/PhotoStock/CourseMicroservices.PhotoStock/
RUN dotnet restore Services/PhotoStock/CourseMicroservices.PhotoStock/*.csproj
COPY . .
RUN dotnet publish Services/PhotoStock/CourseMicroservices.PhotoStock/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","CourseMicroservices.PhotoStock.dll" ]