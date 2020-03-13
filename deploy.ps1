dotnet publish -c Release ./BattleshipGoogleCloud.csproj
gcloud app deploy ./bin/Release/netcoreapp2.1/publish/app.yaml