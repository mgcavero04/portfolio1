Front end: https://localhost:3000/
Back end: http://localhost:5263/api/products
Training code:https://github.com/TryCatchLearn/Restore-v2/tree/main

Run front end(react):npm run dev
Run back end(.net): dotnet run

rfc<enter> --> React Functional Component boilerplate.

Section 6:
----------

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