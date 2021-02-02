## How to get appsetting.cs configuration data

https://medium.com/@dozieogbo/a-better-way-to-inject-appsettings-in-asp-net-core-96be36ffa22b

there are several ways:

### 1. DI on startup.cs
    ```
        //add api configuration parameters
        var configApi = new ApiConfig();
        Configuration.GetSection("Api").Bind(configApi);
        //Create singleton from instance
        services.AddSingleton<ApiConfig>(configApi);
    ```

### 2. config on startup.cs + IOptions<ApiConfig> apiConfig
	```
		services.Configure<ApiConfig>(Configuration.GetSection("Api"));
	```

		
