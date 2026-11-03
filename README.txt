Front end: https://localhost:3000/
Back end: http://localhost:5263/api/products
Training code:https://github.com/TryCatchLearn/Restore-v2/tree/main

Run front end(react):npm run dev
Run back end(.net): dotnet run

rfc<enter> --> React Functional Component boilerplate.

Section 6: Vite creates the website files, Docker packages those files with the API, and Render builds and runs that package.
----------
Flow: Browser React app → HTTP request → .NET server → controller → response back to React.



				 STORE
				   ^
                                   |

		CatalogApi            errorApi:createApi()
		    ^                          ^
                    |                          |
				baseApi:baseQuerywithErrorHandling()
					       ^
					       |
					    Redux
------------------------------------------------------------
Here’s the path for loading products:

In catalogApi.tsx, fetchProducts sets the endpoint path to products.
Redux Toolkit calls baseQueryWithErrorHandling from baseApi.ts. It uses fetchBaseQuery to make an HTTP request, 
combining products with the production base URL /api. The browser requests /api/products from the same site.
The .NET server receives that request and routes it to ProductsController.GetProducts() in ProductsController.cs. 
The response is JSON, which React uses as product data.
An interface isn’t required for this communication: the two sides agree on the HTTP URL and JSON shape. 
The TypeScript Product type helps describe the data in React, but it doesn’t call or enforce the C# code.
Program.cs runs when Render starts the container. It sets up the .NET app, middleware, and routes, including app.MapControllers(). After startup, that configured server handles incoming requests; Program.cs doesn’t run again for each API call.