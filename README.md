# GPW_API
This is an API to used to get actual GPW (Polish stock market) companies prices and other data (price change etc.). 
The data are colected every 30 - 32 minutes (random interval), usung HTML Parsing from https://www.bankier.pl/gielda/notowania/akcje 
and stored in DB (MS SQL).
Go to mateusztyczka.pl/gpw (GET, port 80) to get a list of GPW companies
Go to mateusztyczka.pl/gpw/abrreviation e.g. mateusztyczka.pl/gpw/alior (GET, port 80) to single GPW company

Please edit appsettings.json (defaultConnections - default connection string)
