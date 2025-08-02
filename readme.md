# Obervations

## Organization of the View
### _ViewImports
The `_ViewImports.cshtml` file is used to import namespaces and tag helpers that are common across multiple views in an ASP.NET Core application. This helps to avoid repetitive code in each view file.

### _ViewStart
The `_ViewStart.cshtml` file is used to set the layout for all views in the application. It allows you to define a common layout that will be applied to all views unless overridden by a specific view.

### The Shared Folder
The `Shared` folder contains views that are shared across multiple parts of the application. This typically includes layout files, partial views, and other reusable components that can be used in different views.

#### _Layout
The `_Layout.cshtml` file is a common layout file that defines the overall structure of the HTML page, including the header, footer, and main content area. It is used to provide a consistent look and feel across all pages in the application.

#### _ValidationScriptsPartial
The `_ValidationScriptsPartial.cshtml` file is used to include client-side validation scripts in the layout. This ensures that validation scripts are available on pages that require them, enhancing user experience by providing immediate feedback on form inputs.

### The Pages Folder
The `Pages` folder contains Razor Pages, which are a simplified way to build web pages in ASP.NET Core. Each Razor Page consists of a `.cshtml` file for the view and an optional `.cshtml.cs` file for the page model (code-behind).

## The wwwroot Folder
The `wwwroot` folder is the web root of the application, where static files such as CSS, JavaScript, images, and other assets are stored. This folder is publicly accessible and serves as the base path for static content in the application.

### The Configurations files
#### appsettings.json
The `appsettings.json` file is used to store configuration settings for the application. It typically includes settings such as connection strings, logging configurations, and other application-specific settings. This file can be easily modified without changing the code, allowing for flexible configuration management.

#### launchSettings.json
The `launchSettings.json` file is used to configure how the application is launched during development. It specifies settings such as the environment variables, application URL, and other parameters that affect the development experience. This file is typically used by the development server to set up the application environment when running locally.

## Razor Pages
Razor Pages is a feature of ASP.NET Core that allows developers to build web pages using a page-based programming model. Each Razor Page consists of a `.cshtml` file for the view and an optional `.cshtml.cs` file for the page model (code-behind). Razor Pages provide a more organized way to handle HTTP requests and responses, making it easier to manage page-specific logic and data.

### Razor Syntax
Razor syntax is a markup syntax used in ASP.NET Core to embed server-side code within HTML. It allows developers to write C# code directly in the HTML markup, enabling dynamic content generation and server-side processing. Razor syntax uses the `@` symbol to indicate the start of a code block, making it easy to mix HTML and C# code seamlessly.

#### Example of Razor Syntax:
```csharp
@model MyApp.Models.MyModel
<h1>@Model.Title</h1>
<p>@Model.Description</p>
```
```csharp
@model MyApp.Models.MyModel

<form asp-action="Submit" method="post">
	<label asp-for="Name"></label>
	<input asp-for="Name" />
	<span asp-validation-for="Name"></span>
	<button type="submit">Submit</button>
```
asp-action is used to specify the action method that will handle the form submission, and asp-for is used to bind the input field to a property in the model.
```csharp
@{
var currentTime = DateTime.Now;
}
<p>The current time is: @currentTime</p>
```
```csharp
@{
var items = new List<string> { "Item1", "Item2", "Item3" };
}
<ul>
@foreach (var item in items)
{
	<li>@item</li>
}
</ul>
```
```csharp
@{
var isTrue = true;
}
@if (isTrue)
{
	<p>The condition is true!</p>
}
else
{
	<p>The condition is false!</p>
}
```

## What's the Entity Framework Core
The EF Core is an Object-Relational Mapper (ORM) for .NET applications. It provides a way to interact with databases using .NET objects, allowing developers to work with data in a more intuitive and type-safe manner. EF Core supports various database providers and allows for LINQ queries, change tracking, and migrations, making it easier to manage database interactions in .NET applications.

There are two main approaches to using EF Core:
1. **Code First**: In this approach, you define your data model using C# classes, and EF Core generates the database schema based on these classes. This allows for a more code-centric development experience, where the database structure evolves alongside the application code.
2. **Database First**: In this approach, you start with an existing database and generate the C# classes based on the database schema. This is useful when working with legacy databases or when you want to leverage an existing database structure without having to define it in code.

### Code First Approach Steps
1. **Define the Model**: Create C# classes that represent the entities in your application. Each class corresponds to a table in the database.
2. **Create a DbContext**: Create a class that inherits from `DbContext` and includes `DbSet<T>` properties for each entity type. This class serves as the main point of interaction with the database.
3. **Package Installation**: Install the EF Core, EF Core Tools, and the specific database provider packages (e.g., Microsoft.EntityFrameworkCore.SqlServer) using NuGet.
4. **Configure the appsettings**: Add the connection string to the `appsettings.json` file to specify how to connect to the database.
5. **Configure the Program.cs**: In the `Program.cs` file, configure the services to include the DbContext and specify the database provider.
6. **Create Migrations**: In the Package Manager Console or using the command line, run the `Add-Migration` command to create a migration that reflects the current model. Aftert that, run the `Update-Database` command to apply the migration and create the database schema.

### Database First Approach Steps
1. **Package Installation**: Install the EF Core, EF Core Tools, and the specific database provider packages (e.g., Microsoft.EntityFrameworkCore.SqlServer) using NuGet.
**Learn more about later**