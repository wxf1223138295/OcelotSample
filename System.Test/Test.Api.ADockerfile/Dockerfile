FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 8004

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ./Test.Api.A/Test.Api.A.csproj Test.Api.A/
RUN dotnet restore Test.Api.A/Test.Api.A.csproj
COPY . .
WORKDIR /src/Test.Api.A
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test.Api.A.dll"]