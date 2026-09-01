# 1. Use the official .NET 10 SDK image to build the app
FROM ://microsoft.com AS build
WORKDIR /src

# 2. Copy the project file first and restore dependencies
COPY ["API.csproj", "./"]
RUN dotnet restore "API.csproj"

# 3. Copy everything else inside the API folder and publish the release
COPY . .
RUN dotnet publish "API.csproj" -c Release -o /app/publish

# 4. Use the official .NET 10 ASP.NET runtime image
FROM ://microsoft.com AS final
WORKDIR /app
COPY --from=build /app/publish .

# 5. Bind Kestrel to Render's default HTTP port
ENV ASPNETCORE_HTTP_PORTS=10000

ENTRYPOINT ["dotnet", "API.dll"]


