FROM microsoft/dotnet:latest

ENV http_proxy="http://10.203.222.109:3128/"
ENV https_proxy="http://10.203.222.109:3128/"
ENV no_proxy=""

WORKDIR /app

COPY *.csproj ./
COPY *.Config ./
RUN dotnet restore

#RUN dotnet ef database update

COPY . ./
RUN dotnet publish -c Release -o published

ENTRYPOINT ["dotnet", "published/dotnet-new.dll"]
