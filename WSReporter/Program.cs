using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WSReporter
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length < 1) {
                Console.WriteLine("Please add path to JSON file as a parameter.");
                System.Environment.Exit(1);
            }
            string path = args[0];
            
            string fileContent = File.ReadAllText(path);

            List<WSLibrary> libraries = new List<WSLibrary>();
            
            JsonTextReader reader = new JsonTextReader(new StringReader(fileContent));
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    if (reader.Read()){
                        if((string)reader.Value != "libraries")
                        {
                            libraries.Add(GetWSLibrary(reader));
                        }
                    } 
                    else 
                    {
                        break;
                    }

                }
            }

            foreach (var library in libraries)
            {
                if (library.DirectDependency && library.Type != "Nuget")
                {
                    Console.WriteLine($"{library.Name}: Version: {library.Version} Type: {library.Type}");
                }
            }
        }

        private static WSLibrary GetWSLibrary(JsonTextReader reader)
        {
            var lib = new WSLibrary();
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }

                if (reader.TokenType == JsonToken.PropertyName)
                {
                    switch ((string)reader.Value)
                    {
                        case "type":
                            reader.Read();
                            lib.Type = (string)reader.Value;
                            break;

                        case "productName":
                            reader.Read();
                            lib.ProductName = (string)reader.Value;
                            break;

                        case "projectName":
                            reader.Read();
                            lib.ProjectName = (string)reader.Value;
                            break;

                        case "directDependency":
                            reader.Read();
                            lib.DirectDependency = (bool)reader.Value;
                            break;

                        case "name":
                            reader.Read();
                            lib.Name = (string)reader.Value;
                            break;

                        case "version":
                            reader.Read();
                            lib.Version = (string)reader.Value;
                            break;

                        default:
                            break;
                    }

                }

                // get rid of licenses for now
                if (reader.TokenType == JsonToken.StartObject)
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.EndObject)
                        {
                            break;
                        }
                    }
                } 
            }
            return lib;
        }


    }
}
