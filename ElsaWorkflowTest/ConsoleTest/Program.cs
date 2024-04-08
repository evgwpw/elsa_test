// See https://aka.ms/new-console-template for more information

using Activitys.Requests;
using Elsa.Extensions;
using Elsa.Workflows.Contracts;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddElsa();
var serviceProvider = services.BuildServiceProvider();
var workflowRunner = serviceProvider.GetRequiredService<IWorkflowRunner>();

Workl workl = new Workl(Data.Steps[0]);
var res = workflowRunner.RunAsync(workl);

Console.WriteLine("Hello, World!");
Console.ReadLine();
