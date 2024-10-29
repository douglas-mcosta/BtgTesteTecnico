#aguardando 40 segundos para o provisionamento e start do banco
sleep 40s && /opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P "n<8l=8R54I[j" -i banco-inicial.sql 