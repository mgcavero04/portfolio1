# 1. Fetch the correct .NET 10 SDK build tool
FROM ://microsoft.com AS build
WORKDIR /src

# 2. Copy and restore dependencies
COPY ["API.csproj", "./"]
RUN dotnet restore "API.csproj"

# 3. Compile the application
COPY . .
RUN dotnet publish "API.csproj" -c Release -o /app/publish

# 4. Fetch the correct .NET 10 Runtime environment
FROM ://microsoft.com AS final
WORKDIR /app
COPY --from=build /app/publish .

# 5. Bind port to Render defaults
ENV ASPNETCORE_HTTP_PORTS=10000

ENTRYPOINT ["dotnet", "API.dll"]

