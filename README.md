# Testaufbau
Database:
- start the docker-compose file in the main Testaufbau folder
- restore the empty db from one of the .sql files

Services:
- den gewünschten Service per IDE ausführen
- bei Rest und GraphQl öffnet sich der Browser zum testen

Clients:
- nachdem der Service gestartet wurde, kann der Client per IDE ausgeführt werden um ihn zu testen
- hierbei ist eventuell vorher die Program.cs Datei anzupassen, da hier verschiedene Szenarios hinterlegt sind

Benchmarking:
- im Benchmarking Ordner liegt ein Vergleich zwischen System.Text.Json und Newtonsoft.Json
- die anderen Benchmarks liegen in den jeweiligen Client Ordnern
- die Benchmarks sollten nicht per IDE ausgeführt werden:
  - Program.cs anpassen und das entsprechende Benchmark auswählen
  - Rechtsklick auf das Client-Projekt dann publish auswählen
  - win-x64 auswählen
  - dann IDE schließen
  - In der konsole in den Ordner navigieren (z.B. cd .\Testaufbau\RestClient\bin\Release\net6.0\win-x64\publish)
  - Dann Benchmark ausführen mit ```dotnet .\RestClient.dll```