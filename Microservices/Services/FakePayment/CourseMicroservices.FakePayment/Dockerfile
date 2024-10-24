FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Course.Shared/*.csproj Shared/Course.Shared/
COPY Services/FakePayment/CourseMicroservices.FakePayment/*.csproj Services/FakePayment/CourseMicroservices.FakePayment/
RUN dotnet restore Services/FakePayment/CourseMicroservices.FakePayment/*.csproj
COPY . .
RUN dotnet publish Services/FakePayment/CourseMicroservices.FakePayment/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","CourseMicroservices.FakePayment.dll" ]