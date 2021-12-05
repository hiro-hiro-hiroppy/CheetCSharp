cd ./_dockerWindows
docker rm `docker ps -a -q`
docker-compose up -d
pause