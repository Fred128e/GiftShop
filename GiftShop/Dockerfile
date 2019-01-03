FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["GiftShop/GiftShop.csproj", "GiftShop/"]
RUN dotnet restore "GiftShop/GiftShop.csproj"
COPY . .
WORKDIR "/src/GiftShop"
RUN dotnet build "GiftShop.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GiftShop.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GiftShop.dll"]