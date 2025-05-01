Redis docker run (if not exists first pull from 'redis/redis-stack-server') under name 'redis-docker-server' with port 6379 exposed as 6379:
docker run -d --name redis-docker-server -p 6379:6379 redis/redis-stack-server:latest

Rerun exixting container:
docker start redis-docker-server

Check if redis is running:
docker ps