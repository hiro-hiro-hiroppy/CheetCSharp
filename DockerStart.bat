cd ./_dockerWindows
for /f "usebackq" %x in (`docker ps -a -q`) do docker rm -f %x
docker-compose up -d
pause