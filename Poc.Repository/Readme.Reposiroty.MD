## The Repository Pattern provides an abstraction (interface) over the data 
	so that your application can work regardless of how the data is persisted, 
	whether it will be saved to a database, a file or even a REDIS cache.
	https://code-maze.com/async-generic-repository-pattern/
	https://blog.zhaytam.com/2019/03/14/generic-repository-pattern-csharp/
	https://github.com/zHaytam/RepositoryPatternExample/issues/1

#### Generic 

#### Asyna/Await

#### Clean Caching after Insert | Update | Delete


#### Config Repository in ConfigureServices method in the Startup.cs file.
	```
	services.AddScoped(typeof(IAsyncRepository<>), typeof(EfAsyncRepository<>));
	```

#### Test your codes

