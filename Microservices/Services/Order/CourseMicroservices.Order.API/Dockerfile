FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Course.Shared/*.csproj Shared/Course.Shared/

COPY Services/Order/CourseMicroservices.Order.Application/*.csproj Services/Order/CourseMicroservices.Order.Application/
COPY Services/Order/CourseMicroservices.Order.Domain/*.csproj Services/Order/CourseMicroservices.Order.Domain/
COPY SServices/Order/CourseMicroservices.Order.Domain.Core/*.csproj Services/Order/CourseMicroservices.Order.Domain.Core/
COPY Services/Order/CourseMicroservices.Order.Infastructure/*.csproj Services/FakePayment/CourseMicroservices.Infastructure/

COPY Services/Order/CourseMicroservices.Order.API/*.csproj Services/Order/CourseMicroservices.Order.API/
RUN dotnet restore Services/Order/CourseMicroservices.Order.API/*.csproj
COPY . .
RUN dotnet publish Services/Order/CourseMicroservices.Order.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","CourseMicroservices.Order.API.dll" ]