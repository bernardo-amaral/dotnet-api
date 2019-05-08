FROM microsoft/dotnet AS build-env

ENV http_proxy="http://10.203.222.109:3128/"
ENV https_proxy="http://10.203.222.109:3128/"
ENV no_proxy=""

WORKDIR /app

COPY *.csproj ./
COPY *.Config ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "dotnet-new.dll"]
