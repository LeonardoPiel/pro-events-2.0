# Project Title

Repository to showcase skills using ASP.NET Core Web API and Angular.

## Database Update

To update the database, run the following commands in the terminal:
```bash
dotnet-ef migrations add SetName -p .\pro-events.Persistence\ -s .\pro-events.API
dotnet-ef database update -s .\pro-events.API\
```

## Visual Studio Tips
For helpful tips and tricks while working in Visual Studio, refer to this article.

## JSON Sample Input for POST Action
Use the following JSON sample input when making a POST request:

```json
{
  "location": "Antonio João",
  "eventDate": "2023-11-21T01:00:33.843",
  "subject": "Tereré",
  "amount": 10,
  "imgUrl": "foto2.png",
  "cellphone": "389479384",
  "email": "pp@teste.com",
  "ticketLots": [],
  "socials": [],
  "speakerEvents": []
}
