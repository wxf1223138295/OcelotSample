FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 8003

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ./Ocelot.Host/Ocelot.Host.csproj Ocelot.Host/
RUN dotnet restore Ocelot.Host/Ocelot.Host.csproj
COPY . .
WORKDIR /src/Ocelot.Host
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ocelot.Host.dll"]