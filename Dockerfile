FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ASP.NET-Core-6.0-Tutorial.csproj", "."]
RUN dotnet restore "./ASP.NET-Core-6.0-Tutorial.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ASP.NET-Core-6.0-Tutorial.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "ASP.NET-Core-6.0-Tutorial.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASP.NET-Core-6.0-Tutorial.dll"]