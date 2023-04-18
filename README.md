# Testaufbau
Database:

To start the db use:
docker run --name maria_db -e MYSQL_ROOT_PASSWORD=mypass -p 3306:3306 -d mariadb

danach reicht:
docker container start -i maria_db

(oder docker-compose starten und dann den testaufbau beenden)

Docker-Compose um alles in den Container zu bringen:
Tutorial:
https://www.twilio.com/blog/containerize-your-aspdotnet-core-application-and-sql-server-with-docker


Man kann bei MariaDb auch volumes zwischen neustarts persistieren
in yaml reinkopieren:
volumes:
  - data:/var/lib/mysql