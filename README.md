# PokeApi

## About
This is a test project to provide a **[.NET](https://dotnet.microsoft.com) Core Web API** to serve information about pokemons to a SPA with Angular to show a list of pokemons and download a text file with the information about one specific pokemon.

## Project Setup
* Clone and Run
```
$ git clone https://github.com/franciscogilt/pokeapi
$ cd pokeapi
$ dotnet run
```

## API Endpoints
* **Pokémon**

| Type | Request | Description |
| :-: | :-: | :-: |
| GET | `/api/pokemon` | Get all the Pokemons |
| GET | `/api/pokemon/{name}` | Get a single Pokemon by its name |
| GET | `/api/pokemon/{name}/download` | Download a single Pokemon text file by its name |
