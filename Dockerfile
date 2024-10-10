FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet test ./UnitTests/UnitTests.csproj
RUN dotnet publish -c Release -o /release

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
ENV DB_SERVER=mysql
ENV DB_USER=root
ENV DB_PASS=1234qwer
WORKDIR /app
COPY --from=build /release .
EXPOSE 8080
ENTRYPOINT ["dotnet", "PasswordManager.dll"]