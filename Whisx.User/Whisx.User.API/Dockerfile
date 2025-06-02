FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8082
EXPOSE 8083


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Whisx.User/Whisx.User.API/Whisx.User.API.csproj", "Whisx.User/Whisx.User.API/"]
COPY ["Whisx.Logger/Whisx.Logger.csproj", "Whisx.Logger/"]
COPY ["Whisx.User/Whisx.User.Application/Whisx.User.Application.csproj", "Whisx.User/Whisx.User.Application/"]
COPY ["Whisx.Shared/Whisx.Shared.csproj", "Whisx.Shared/"]
COPY ["Whisx.User/Whisx.User.Domain/Whisx.User.Domain.csproj", "Whisx.User/Whisx.User.Domain/"]
RUN dotnet restore "./Whisx.User/Whisx.User.API/Whisx.User.API.csproj"
COPY . .
WORKDIR "/src/Whisx.User/Whisx.User.API"
RUN dotnet build "./Whisx.User.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Whisx.User.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Whisx.User.API.dll"]