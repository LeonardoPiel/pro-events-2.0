# Project Title

Repository to showcase skills using ASP.NET Core Web API and Angular.

## Database Update

To update the database, run the following commands in the terminal:
```bash
dotnet-ef migrations add SetName -p .\pro-events.Persistence\ -s .\pro-events.API
dotnet-ef database update -s .\pro-events.API\
```

## Visual Studio Tips
For helpful tips and tricks while working in Visual Studio, refer to this article: https://www.meziantou.net/visual-studio-tips-and-tricks-multi-line-and-multi-cursor-editing.htm

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
```
Json para inserir evento completo:
```json
{
    "location": "Porto Alegre",
    "eventDate": "2023-11-21T01:00:33.843",
    "subject": "JS",
    "amount": 20,
    "imgUrl": "foto2.png",
    "cellphone": "389479384",
    "email": "pp@teste.com",
    "ticketLots": [
        {
            "Description": "1° lote",
            "Value": 200,
            "Init": "2023-11-29T18:20:05.019Z",
            "End": "2023-11-29T18:20:05.019Z",
            "Amount": 50
        },
        {
            "Description": "2° lote",
            "Value": 350,
            "Init": "2023-11-29T18:20:05.019Z",
            "End": "2023-11-29T18:20:05.019Z",
            "Amount": 30
        },
        {
            "Description": "3° lote",
            "Value": 100,
            "Init": "2023-11-29T18:20:05.019Z",
            "End": "2023-11-29T18:20:05.019Z",
            "Amount": 20
        }
    ],
    "socials": [
        {
            "Name": "Facebook",
            "URL": "facebook.com"
        }
    ],
    "Speakers": [
        {
            "Cv":"Curriculum Vitae",
            "ImgUrl": "leo.png",
            "Description": "Programador",
            "Socials": null
        }
    ]
}
