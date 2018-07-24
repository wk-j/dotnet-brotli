namespace HiBrotli

open System.Linq
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.ResponseCompression
open System.Threading.Tasks
open System.Threading
open Microsoft.AspNetCore.Http

type Startup private () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration

    member __.ConfigureServices(services: IServiceCollection) =
        services
            .AddResponseCompression(fun options ->
                options.Providers.Add<BrotliCompressionProvider>()
                options.MimeTypes <- ResponseCompressionDefaults.MimeTypes.Concat([| "image/svg+xml"; "application/javascript" |])
            )
            .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1) |> ignore

    member __.Configure(app: IApplicationBuilder, env: IHostingEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        else
            app.UseHsts() |> ignore

        let showHeaders (context: HttpContext) (next: System.Func<Task>) =
            Task.Run(fun () ->
                context.Request.Headers |> Seq.iter (fun x ->
                    printfn " Header %A" x
                )
                next.Invoke()
            )

        app.Use(showHeaders) |> ignore
        app.UseResponseCompression()
            .UseStaticFiles()
            .UseMvc()
        |> ignore

    member val Configuration : IConfiguration = null with get, set