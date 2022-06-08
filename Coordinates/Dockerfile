#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Coordinates/Coordinates.csproj", "Coordinates/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["ViewModel/ViewModel.csproj", "ViewModel/"]
COPY ["Helper/Helper.csproj", "Helper/"]
RUN dotnet restore "Coordinates/Coordinates.csproj"
COPY . .
WORKDIR "/src/Coordinates"
RUN dotnet build "Coordinates.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Coordinates.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coordinates.dll"]