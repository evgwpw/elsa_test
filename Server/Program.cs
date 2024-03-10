using Elsa.EntityFrameworkCore.Modules.Management;
using Elsa.EntityFrameworkCore.Modules.Runtime;
using Elsa.Extensions;
using Elsa.Persistence.EntityFramework.SqlServer;
using Elsa.EntityFrameworkCore.Extensions;
using System.Reflection;
using Elsa.Workflows;
using Activitys;
using Elsa.Workflows.Contracts;
using Elsa.Workflows.Features;
using Activitys.Requests;


MyWorkflow myWorkflow = new MyWorkflow();
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("SqlServer")!;
var contextType = typeof(Elsa.Persistence.EntityFramework.Core.ElsaContext);
//WorkflowsFeature workflowsFeature = null;
//private static Assembly Assembly => typeof(SqlServerProvidersExtensions).Assembly;
builder.Services.AddElsa(elsa =>
{
    
    // Configure Management layer to use EF Core.
    elsa.UseWorkflowManagement(management => management.UseEntityFrameworkCore(ef => 
    {
        ef.DbContextOptionsBuilder = (sp, ob) => 
        {
            ob.UseSqlServer(connectionString, contextType);
        };
    }).AddVariableType<Step>("Request")
    );

    // Configure Runtime layer to use EF Core.
    elsa.UseWorkflowRuntime(runtime => runtime.UseEntityFrameworkCore(ef => 
    {
        ef.DbContextOptionsBuilder = (sp, ob) =>
        {
            ob.UseSqlServer(connectionString, contextType);
        };
    }));

    // Default Identity features for authentication/authorization.
    elsa.UseIdentity(identity =>
    {
        identity.TokenOptions = options => options.SigningKey = "sufficiently-large-secret-signing-key"; // This key needs to be at least 256 bits long.
        identity.UseAdminUserProvider();
    });

    // Configure ASP.NET authentication/authorization.
    elsa.UseDefaultAuthentication(auth => auth.UseAdminApiKey());

    // Expose Elsa API endpoints.
    elsa.UseWorkflowsApi();

    // Setup a SignalR hub for real-time updates from the server.
    elsa.UseRealTimeWorkflows();

    // Enable C# workflow expressions
    elsa.UseCSharp();
    elsa.UseJavaScript();
    elsa.UseLiquid();

    // Enable HTTP activities.
    elsa.UseHttp();

    // Use timer activities.
    elsa.UseScheduling();

    // Register custom activities from the application, if any.
    elsa.AddActivitiesFrom<Program>();
    elsa.AddActivitiesFrom<Elsa.Email.Activities.SendEmail>();

    // Register custom workflows from the application, if any.
    elsa.AddWorkflowsFrom<Program>();
    elsa.AddActivitiesFrom<MyActivity>();
    elsa.AddWorkflowsFrom<MyWorkflow>();
    
    //elsa.UseWorkflowManagement(m => 
    //{
    //    m.AddVariableType<Activitys.Request>(category: "MyCategory");
    //});

    //workflowsFeature = new WorkflowsFeature(elsa);
    //workflowsFeature.Apply();
});
// Configure CORS to allow designer app hosted on a different origin to invoke the APIs.
builder.Services.AddCors(cors => cors
    .AddDefaultPolicy(policy => policy
        .AllowAnyOrigin() // For demo purposes only. Use a specific origin instead.
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithExposedHeaders("x-elsa-workflow-instance-id"))); // Required for Elsa Studio in order to support running workflows from the designer. Alternatively, you can use the `*` wildcard to expose all headers.

// Add Health Checks.
builder.Services.AddHealthChecks();
builder.Services.AddMvcCore();
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddTransient<IWorkflowBuilder, WorkflowBuilder>();
//builder.Services.AddSwaggerGen(config =>
//{
//    //some swagger configuration code.

//    //use fully qualified object names
//    config.CustomSchemaIds(x => x.FullName);
//});

// Build the web application.
var app = builder.Build();

// Configure web application's middleware pipeline.

//app.UseSwagger();
//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//    options.RoutePrefix = string.Empty;
//});

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.MapHealthChecks("/health");
app.UseRouting();
app.UseCors();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseWorkflowsApi();
app.UseWorkflows();
app.UseWorkflowsSignalRHubs();
app.MapFallbackToFile("index.html");


//IWorkflowBuilder workflowBuilder = workflowsFeature.   .GetService<IWorkflowBuilder>();

//var ss = workflowBuilder.BuildWorkflowAsync(myWorkflow);
//var ser = app.Services.GetService<IActivitySerializer>();

//var data = ser.Serialize(ss);

app.Run();


