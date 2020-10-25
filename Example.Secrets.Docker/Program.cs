using Microsoft.Extensions.Configuration;
using RockLib.Secrets;
using RockLib.Secrets.Docker;
using System;
using System.IO;

namespace Example.Secrets.Docker
{
    class Program
    {
        static void Main(string[] args)
        {
            // This example shows RockLib.Secrets reading the files that Docker stores its secrets (/run/secrets/)

            //if you want to create the files of the example.. run these lines
            //if (!File.Exists("/run/secrets"))
            //    Directory.CreateDirectory("/run/secrets");
            //File.WriteAllText("/run/secrets/DOCKER_SECRET_FILE_NAME", "EXAMPLEVALUEHERE-COULDBE-AN-API-KEY");
            //File.WriteAllText("/run/secrets/ANOTHER_DOCKER_SECRET_FILE_NAME", "look-im-another-docker-secret");
            //File.WriteAllText("/run/secrets/MANUAL_ADD", "lol-it-works");

            var builder = new ConfigurationBuilder();

            builder
                .AddJsonFile("appsettings.json")
                .AddRockLibSecrets()
                .AddDockerSecret("AnotherKey", "MANUAL_ADD");

            var config = builder.Build();

            Console.WriteLine($"SomeApiKey: {config["SomeApiKey"]}");
            Console.WriteLine($"AppSettings:Value1: {config["AppSettings:Value1"]}");
            Console.WriteLine($"AppSettings:Value2: {config["AppSettings:Value2"]}");
            Console.WriteLine($"AnotherKey: {config["AnotherKey"]}");

            Console.ReadKey();
        }
    }
}
