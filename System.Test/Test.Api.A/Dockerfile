FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 51186
EXPOSE 44302

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY Test.Api.A/Test.Api.A.csproj Test.Api.A/
RUN dotnet restore Test.Api.A/Test.Api.A.csproj
COPY . .
WORKDIR /src/Test.Api.A
RUN dotnet build Test.Api.A.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Test.Api.A.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test.Api.A.dll"]
