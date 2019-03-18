FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 53148
EXPOSE 44363

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY Test.Api.C/Test.Api.C.csproj Test.Api.C/
RUN dotnet restore Test.Api.C/Test.Api.C.csproj
COPY . .
WORKDIR /src/Test.Api.C
RUN dotnet build Test.Api.C.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Test.Api.C.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test.Api.C.dll"]
