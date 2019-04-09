FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5008

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ./Test.Api.D/Test.Api.D.csproj Test.Api.D/
RUN dotnet restore Test.Api.D/Test.Api.D.csproj
COPY . .
WORKDIR /src/Test.Api.D
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test.Api.D.dll"]

