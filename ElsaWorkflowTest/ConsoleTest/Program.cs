// See https://aka.ms/new-console-template for more information

using Elsa.Extensions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddElsa();
var serviceProvider = services.BuildServiceProvider();


Console.WriteLine("Hello, World!");
