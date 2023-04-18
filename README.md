# Testaufbau

Database:
Tutorial for DBContainerization: https://www.twilio.com/blog/containerize-your-sql-server-with-docker-and-aspnet-core-with-ef-core

Command to create an image with a sql database and deploy it into a docker container:
winpty docker run -it -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=SuperSecretPassword1234" -p 1433:1433 --name sql-server-2022 mcr.microsoft.com/mssql/server:2022-latest
(winpty wurde mir von der Konsole vorgeschlagen..)

To Connect to it from any program, use:
Hostname: localhost
Username: SA
Password: SuperSecretPassword1234

To Stop the container use:
CTRL + C

To start it again use:
docker container start -i sql-server-2022

Wichtig:
Ich hatte irgendwelche Zertifikat-Probleme
Um aus der Web-Api auf den SQL-Server zugreifen zu können, muss noch im Connection String "TrustServerCertificate=true" eingefügt werden.
Und Anpassungen im MMC: https://learn.microsoft.com/de-de/troubleshoot/sql/database-engine/connect/error-message-when-you-connect

Docker-Compose um alles in den Container zu bringen:
Tutorial:
https://www.twilio.com/blog/containerize-your-aspdotnet-core-application-and-sql-server-with-docker

---------------------------------------------
Man kann bei MariaDb auch volumes zwischen neustarts persistieren
in yaml reinkopieren:
volumes:
  - data:/var/lib/mysql