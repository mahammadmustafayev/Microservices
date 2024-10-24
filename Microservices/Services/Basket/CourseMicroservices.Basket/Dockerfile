FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Course.Shared/*.csproj Shared/Course.Shared/
COPY Services/Basket/CourseMicroservices.Basket/*.csproj Services/Basket/CourseMicroservices.Basket/
RUN dotnet restore Services/Basket/CourseMicroservices.Basket/*.csproj
COPY . .
RUN dotnet publish Services/Basket/CourseMicroservices.Basket/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","CourseMicroservices.Basket.dll" ]