REM カレントディレクトリを移動
cd %CD%
cd _dockerWindows

REM for /f "usebackq" %x in (`docker ps -a -q`) do docker rm -f %x
docker-compose up -d

REM PostgreSQL
cd ../Entity.MyDbContext
dotnet ef database update

REM S3
cd ../AWS.S3.MigrateConsole
dotnet run AWS.S3.MigrateConsole.csproj

REM DynamoDB
cd ../AWS.DynamoDB.Entity.MigrateConsole
dotnet run AWS.DynamoDB.Entity.MigrateConsole.csproj

