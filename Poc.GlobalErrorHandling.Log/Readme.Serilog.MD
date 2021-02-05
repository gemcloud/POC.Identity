## NetCore + Serilog + Seq

### Install NuGet Packages: Install Serilog.AspNetCore V"3.4.0"
	"Serilog.AspNetCore"
	"Serilog.Sinks.Async"
	"Serilog.Sinks.Console"      ==> for Console to start up from the Project.
	"Serilog.Sinks.Debug"        ==> VS 2019 Output Debug Windows.
	"Serilog.Sinks.File"         ==> Output log file.
	"Serilog.Sinks.Seq"          ==> Output to Seq (To download & install Seq)
		https://datalust.co/Download
https://www.c-sharpcorner.com/article/serilog-in-asp-net-core-3-1/

## Create "appsettings.serilogs.json":
	and read it on Program.cs
	```
		.AddJsonFile("appsettings.serilogs.json", optional: false, reloadOnChange: true)
	```
https://jkdev.me/asp-net-core-serilog/

### SerilogMiddleware:
	https://blog.datalust.co/smart-logging-middleware-for-asp-net-core/
	1. Create class "SerilogMiddleware";
	2. Add the middleware "app.UseMiddleware<SerilogMiddleware>();" to the pipeline on Startup.cs;
	3. Wroked by checking Seq | Console | Debug etc.

#### Serilog on GlobalException Middleware
https://andrewlock.net/adding-serilog-to-the-asp-net-core-generic-host/

#### Fixed: issue: No service for type 'Serilog.ILogger' has been registered.
Fixed by add 
```
	private readonly ILogger<ExceptionMiddleware> _logger;
```

#### Fixed: There is issue: Log was used on namespace, so C# ask you have to add "Serilog.Log"

#### Logging “levels” in a structured world
https://nblumhardt.com/2014/03/logging-levels-in-a-structured-world/

#### Fixed issue: this it routing issue!
sokution is :
	https://stackoverflow.com/questions/59283210/how-do-i-resolve-the-issue-the-request-matched-multiple-endpoints-in-net-core-w
 Something went wrong: Microsoft.AspNetCore.Routing.Matching.AmbiguousMatchException: The request matched multiple endpoints. Matches:



