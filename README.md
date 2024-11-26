# pos-backend

## Sql Server Exporess
```
$ docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=password#" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/ser
ver:2019-latest
```
