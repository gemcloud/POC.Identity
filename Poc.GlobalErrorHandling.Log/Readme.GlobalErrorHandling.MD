## Global Error Handling in ASP.NET Core Web API
	reference https://code-maze.com/global-error-handling-aspnetcore/

There are 2 ways by use Middleware: 
	one is Built-In Middleware;
	another is the Custom Middleware;

### Handling Errors Globally with the Custom Middleware
1. To refernce project "Gem.Extensions.OData.Swagger" tp add Swagger, and change the "launchSettings.json" to start swagger UI.
2. Add the "ErrorDetailModel.cs" on the "Models" folder.
3. Create the "Middleware" folder, and add Middleware class "ExceptionMiddleware.cs";
4. To extend and call "app.UseMiddleware()" in the ExceptionMiddlewareExtensions.cs on the folder "Extensions" ;
5. Use Exception Middleware "app.ConfigureCustomExceptionMiddleware();" in the Configure method in the Startup class.
6. To remove the "Try-Catch" block from Contoller files.

### Add Log Service 

