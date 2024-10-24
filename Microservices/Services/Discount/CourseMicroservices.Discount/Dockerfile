FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Course.Shared/*.csproj Shared/Course.Shared/
COPY Services/Discount/CourseMicroservices.Discount/*.csproj Services/Discount/CourseMicroservices.Discount/
RUN dotnet restore Services/Discount/CourseMicroservices.Discount/*.csproj
COPY . .
RUN dotnet publish Services/Discount/CourseMicroservices.Discount/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","CourseMicroservices.Discount.dll" ]