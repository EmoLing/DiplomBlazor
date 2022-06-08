#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AnimalManagement/AnimalManagement.csproj", "AnimalManagement/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["ViewModel/ViewModel.csproj", "ViewModel/"]
COPY ["Helper/Helper.csproj", "Helper/"]
RUN dotnet restore "AnimalManagement/AnimalManagement.csproj"
COPY . .
WORKDIR "/src/AnimalManagement"
RUN dotnet build "AnimalManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AnimalManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AnimalManagement.dll"]