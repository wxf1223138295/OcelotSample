FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 51209
EXPOSE 44332

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY Test.Api.B/Test.Api.B.csproj Test.Api.B/
RUN dotnet restore Test.Api.B/Test.Api.B.csproj
COPY . .
WORKDIR /src/Test.Api.B
RUN dotnet build Test.Api.B.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Test.Api.B.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test.Api.B.dll"]
