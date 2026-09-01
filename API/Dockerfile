# 1. Use the official .NET SDK image to build the app
FROM ://microsoft.com AS build
WORKDIR /src

# 2. Copy everything and publish the release
COPY . .
RUN dotnet publish "Restore.csproj" -c Release -o /app/publish

# 3. Build runtime image
FROM ://microsoft.com AS final
WORKDIR /app
COPY --from=build /app/publish .

# 4. Bind Kestrel to Render's default HTTP port
ENV ASPNETCORE_HTTP_PORTS=10000

ENTRYPOINT ["dotnet", "API.dll"]
