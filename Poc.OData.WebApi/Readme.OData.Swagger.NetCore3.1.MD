## OData + Swagger + Endpoint routing + Net Core 3.1

## install Swashbuckle
    1. Swashbuckle.AspNetCore
    2. Swashbuckle.AspNetCore.Annotations

## install OData
    1. Microsoft.AspNetCore.OData
    2. Microsoft.AspNetCore.OData.Versioning
    (Not must)3. OData.Swagger

## install Authentication and so on
    1. Microsoft.AspNetCore.Authentication.JwtBearer
    2. Microsoft.AspNetCore.Mvc.NewtonsoftJson

## Create "Configure OData with Swagger" on Extension Class "Gem.Extensions.OData.Swagger".

## Register "ConfigureServices" &  configure the HTTP request pipeline on "Configure"

### Register "ConfigureServices" on Startup.cs. (Real logic on "Gem.Extensions.OData.Swagger" project.)
    1. Add AddOData() & AddODataQueryFilter()
        ```
           services.AddOData();
           services.AddODataQueryFilter();
        ```
    2. AddSwaggerGen With Authentication: ()
        ```
            services.AddODataSwaggerGenJwt();
        ```
    3. AddOdataSwaggerOutputFormatters: ()
        ```
            services.AddOdataSwaggerOutputFormatters();
        ```

### To configure the HTTP request pipeline on Startup.cs "Configure" method.
    1. #1 Add UseSwagger UI
    ```
        app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Poc OData API V1");
            });
    ```
    2. Add EnableDependencyInjection: (This is very important, Do NOT forget them!)
    ```
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // ==== #2 Add EnableDependencyInjection ===========>
                endpoints.EnableDependencyInjection();
                //// ==== #3 Add Select().Filter().OrderBy().Count().MaxTop(10) ===========>
                //endpoints.Select().Filter().OrderBy().Count().MaxTop(10);
            });
    ```