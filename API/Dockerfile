# 1. Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 2. Copy the project file first and restore dependencies
COPY ["API.csproj", "./"]
RUN dotnet restore "API.csproj"

# 3. Copy everything else inside the API folder and publish the release
COPY . .
RUN dotnet publish "API.csproj" -c Release -o /app/publish

# 4. Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# 5. Bind Kestrel to Render's default HTTP port
ENV ASPNETCORE_HTTP_PORTS=10000

ENTRYPOINT ["dotnet", "API.dll"]

