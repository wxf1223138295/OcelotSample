FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 8005

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ./Test.Api.B/Test.Api.B.csproj Test.Api.B/
RUN dotnet restore Test.Api.B/Test.Api.B.csproj
COPY . .
WORKDIR /src/Test.Api.B
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test.Api.B.dll"]