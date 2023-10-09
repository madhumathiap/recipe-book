## Recipe Book

### Recipe Book API

#### Features

#### v1.0
- Add Ingredient
- List Ingredient
- Add Recipe
- List Recipes with search, filter, pagination
- View Recipe

#### Tech Stack
- .NET 7
- Entity Framework Core
- Sqlite
- xUnit
- Docker
- Azure VM

#### Commands

Build project

```
dotnet build
```

Run the project
```
cd RecipeBook
dotnet run --urls=http://*:5000
```


Add migrations

```
dotnet ef migrations add "name"
```

Update database from migrations

```
dotnet ef database update
```

Start Docker Service in Linux
```
sudo service docker start
```

Build Docker Image

```
docker build . -f RecipeBook/Dockerfile -t recipe-book-api:latest
```

Run Docker Container

```
docker run recipe-book-api
```

Connect to Ubuntu VM in Azure
```
ssh username@ip
```