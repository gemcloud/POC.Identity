## use MediatR
https://dotnetcoretutorials.com/2019/04/30/the-mediator-pattern-part-3-mediatr-library/


1. To install "MediatR.Extensions.Microsoft.DependencyInjection" by Nuget tools;
2. To register "AddMediatR" in the ConfigureServices method in the Startup.cs file;
	```
	services.AddMediatR(typeof(Startup));
	```
3. To create "Commands" / "Queries" folders and create subfolders "Handlers" and "Models";
4. DI "IMediator" on the Controller or Service class.

### Compare Dependency Injection v. MediatR
https://medium.com/swlh/dependency-injection-v-mediatr-a-simple-c-benchmark-32630ff864ea

