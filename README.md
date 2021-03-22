# info-playground-abongioanni

DB SCHEME
![db scheme image](https://github.com/vallauri-ict/formula-one-abongioanni/blob/dev/Schema.png)

La soluzione si dirama in 5 progetti:
## Dll
Libreria contente:
- modelli generali che rappresentano le tabelle nel DB
- DTO per le routes
- set di tools per l'interfacciamento con il DB
- set di http tools per effetuare richieste http client

## Console
Progetto per la gestione del DB da parte di un operatore (admin ad esempio) permettendo di:
- eliminare le tabelle
- rigenerare le tabelle
- effettuare backup e restore
- creare o elminare le relazioni

## Form
Progetto vuoto

## Web form
Webform che permette di visualizzare le tabelle in maniera statica

## Web services
Set di servizi per richieste http da parte di un client
