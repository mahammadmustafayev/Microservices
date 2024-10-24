FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/Course.Shared/*.csproj Shared/Course.Shared/
COPY FrontEnds/Course.Web/*.csproj FrontEnds/Course.Web/
RUN dotnet restore FrontEnds/Course.Web/*.csproj
COPY . .
RUN dotnet publish FrontEnds/Course.Web/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Course.Web.dll" ]