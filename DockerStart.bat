cd ./_dockerWindows
REM for /f "usebackq" %x in (`docker ps -a -q`) do docker rm -f %x
docker-compose up -d
pause