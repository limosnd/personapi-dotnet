@echo off
setlocal

echo ==========================================
echo 1/3 - Levantando contenedores Docker
echo ==========================================
docker compose up -d

if %errorlevel% neq 0 (
    echo  Error al levantar los contenedores.
    exit /b %errorlevel%
)

echo ==========================================
echo 🧩 2/3 - Ejecutando init.sql dentro del contenedor SQL Server
echo ==========================================
docker exec -it sqlserver /opt/mssql-tools18/bin/sqlcmd ^
  -S localhost -U sa -P "YourStrong!Passw0rd" -C ^
  -i /docker-entrypoint-initdb.d/init.sql

if %errorlevel% neq 0 (
    echo Error al ejecutar el script SQL.
    exit /b %errorlevel%
)

echo ==========================================
echo 🧠 3/3 - Generando entidades con Scaffold-DbContext
echo ==========================================

:: Mueve a la carpeta del proyecto (ajusta si tu .csproj está en subcarpeta)
cd /d "%~dp0"

dotnet ef dbcontext scaffold ^
  "Server=localhost,1433;Database=arq_per_db;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=true;" ^
  Microsoft.EntityFrameworkCore.SqlServer ^
  --output-dir Models/Entities --context ArqPerDbContext --force

if %errorlevel% neq 0 (
    echo Error en Scaffold-DbContext
    exit /b %errorlevel%
)

echo ==========================================
echo Base creada y entidades generadas correctamente
echo ==========================================

docker exec -it sqlserver /opt/mssql-tools18/bin/sqlcmd ^
  -S localhost -U sa -P "YourStrong!Passw0rd" -C ^
  -Q "SELECT name FROM sys.databases"

pause
