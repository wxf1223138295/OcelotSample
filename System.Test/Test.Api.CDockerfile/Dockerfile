FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 8006

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ./Test.Api.C/Test.Api.C.csproj Test.Api.C/
RUN dotnet restore Test.Api.C/Test.Api.C.csproj
COPY . .
WORKDIR /src/Test.Api.C
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test.Api.C.dll"]