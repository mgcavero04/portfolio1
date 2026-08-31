using System;
using API.Entities;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

namespace API.Data;


    
public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<StoreContext>()
            ?? throw new InvalidOperationException("Failed to retrieve store context");
        
        await SeedData(context);
    }
    private static async Task SeedData(StoreContext context)
    {
        context.Database.Migrate();
        if (context.Products.Any()) return;
        var products = new List<Entities.Product>
        {
            new ()
            {
                Name = "First Portfolio",
                Description = "This picture shows some of my first web projects: website, graphics and web applications. I used HTML, CSS, and JavaScript to create these projects.",
                Price = 20000,
                PictureUrl = "/images/products/oldPortfolio.jpg",
                Brand = "HTML, CSS, JavaScript",
                Type = "Web Site",
                QuantityInStock = 100,
                Url = "https://mgportfolio.azurewebsites.net/images/products/oldPortfolio.jpg"
            },
            
            new ()
            {
                Name = "Angular 7 Demo",
                Description = "This was a demo of a recent version of Angular 7. This was developed to show some of the new capabilites.",
                Price = 0,
                PictureUrl = "/images/products/angular7-1.jpg",
                Brand = "Angular",
                Type = "Web Application",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/angular7-1.jpg"
            },
            new ()
            {
                Name = "Angular 7 Demo",
                Description = "This was a demo of a recent version of Angular 7. This was developed to show some of the new capabilites.",
                Price = 0,
                PictureUrl = "/images/products/angular7-2.jpg",
                Brand = "Angular",
                Type = "Web Application",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/angular7-2.jpg"
            },
            new ()
            {
                Name = "Angular Web Application",
                Description = "This was a web page that was developed to show different resources like: PDFs, Word documents, pictures, videos by filtering different categories of products. Heavy use of CSS and Json",
                Price = 0,
                PictureUrl = "/images/products/keystonehardscapesTabs.jpg",
                Brand = "Angular",
                Type = "Web Application",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/keystonehardscapesTabs.jpg"
            },
            new ()
            {
                Name = "Google Map API",
                Description = "This is a web page to show filtering of different locations using Google Map API. This page had a filtering capability to search by address and show in the map the closest locations.",
                Price = 0,
                PictureUrl = "/images/products/map.png",
                Brand = "PHP, Javascript, CSS",
                Type = "Web Application",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/map.png"
            },
            new ()
            {
                Name = "ArcGIS Form",
                Description = "This is an arcgis form that open as a pop up in a city of atlanta page.",
                Price = 0,
                PictureUrl = "/images/products/arcgisForm.jpg",
                Brand = "HTML, CSS, Javascript",
                Type = "Web Site",
                QuantityInStock = 100,
                Url = "https://mgportfolio.azurewebsites.net/images/products/arcgisForm.jpg"
            },
            new ()
            {
                Name = "Simpson's Rule",
                Description = "This is an implementation of the Simpson's Rule algorithm to calculate the integral of a function. This was developed using Python",
                Price = 0,
                PictureUrl = "/images/products/compositeSimpsons.png",
                Brand = "Python",
                Type = "Web Site",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/compositeSimpsons.png"
            },
            new ()
            {
                Name = "Web site for the City of Atlanta",
                Description = "This is a web site developed for the City of Atlanta using the WebFlow platform.",
                Price = 0,
                PictureUrl = "/images/products/atlpartnerships.jpg",
                Brand = "HTML, CSS, Javascript",
                Type = "Web Site",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/atlpartnerships.jpg"
            },
            new ()
            {
                Name = "E Commerce Page",
                Description = "This is a template for a mobile E Commerce page, done for a non-profite organization.",
                Price = 0,
                PictureUrl = "/images/products/ecommercePage.png",
                Brand = "HTML, CSS, Javascript",
                Type = "Web Site",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/ecommercePage.png"
            },
            new ()
            {
                Name = "Searcg Page",
                Description = "This shows a pop up windows that has a Search capability of accounts",
                Price = 0,
                PictureUrl = "/images/products/groups.jpg",
                Brand = "JQUery, Javascript, HTML, CSS",
                Type = "Web Application",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/groups.jpg"
            },
            new ()
            {
                Name = "Professional Web Site",
                Description = "This is a web site developed using the Web Flow platform.",
                Price = 0,
                PictureUrl = "/images/products/MarianaMontiel.jpg",
                Brand = "HTML, CSS, Javascript",
                Type = "Web Site",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/MarianaMontiel.jpg"
            },
            new ()
            {
                Name = "Form for Input of Data",
                Description = "This is a web application built using Angular, Typescript, .NET, SQL Server. This form accepts input of data in different formats and also lets upload many documents.",
                Price = 0,
                PictureUrl = "/images/products/netForm1.png",
                Brand = "Angular, Typescript, .NET, SQL Server",
                Type = "Web Application",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/netForm1.png"
            },
            new ()
            {
                Name = "Tableau Visualization",
                Description = "This is a Tablaeau Visualization",
                Price = 0,
                PictureUrl = "/images/products/salaries.jpg",
                Brand = "Tableau",
                Type = "Visualization",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/salaries.jpg"
            },
            new ()
            {
                Name = "Tableau Visualization",
                Description = "This is a Tablaeau Visualization",
                Price = 0,
                PictureUrl = "/images/products/tableauDayHourMostUsed.jpg",
                Brand = "Tableau",
                Type = "Visualization",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/tableauDayHourMostUsed.jpg"
            },
            new ()
            {
                Name = "Input of Data",
                Description = "This is a report and Editor of Data for varios forms of formats, to update,add, delete, read records done in JQuery, Javascript, HTML, CSS, .NET, SQL Server",
                Price = 0,
                PictureUrl = "/images/products/take6(2).png",
                Brand = "JQuery",
                Type = "Web Application",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/take6(2).png"
            },
            new ()
            {
                Name = "ServiceNow Visualization",
                Description = "ServiceNow Visualization",
                Price = 0,
                PictureUrl = "/images/products/take8.jpg",
                Brand = "Data Analysis",
                Type = "Visualization",
                QuantityInStock = 1,
                Url = "https://mgportfolio.azurewebsites.net/images/products/take8.jpg"
            }
};
        context.Products.AddRange(products);
        context.SaveChanges();
    }
}   
