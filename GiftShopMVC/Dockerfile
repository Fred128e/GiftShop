FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY GiftShopMVC/GiftShopMVC.csproj GiftShopMVC/
RUN dotnet restore GiftShopMVC/GiftShopMVC.csproj
COPY . .
WORKDIR /src/GiftShopMVC
RUN dotnet build GiftShopMVC.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish GiftShopMVC.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GiftShopMVC.dll"]
