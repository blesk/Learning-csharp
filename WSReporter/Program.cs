using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json;

namespace WSReporter
{
    class Program
    {

        static void Main(string[] args)
        {
            string path = "../../data/two.json";
            //string fileContent = "{'libraries':[{'keyUuid':'717c66cb-5229-495a-983f-8deec79d573b','type':'.NET','productName':'NPM - latest','projectName':'wireless.heatmaps - latest','description':'ServiceStack.Text','directDependency':true,'matchType':'Exact Match','sha1':'4889d31b0c3a406e88f19d47aa180722bf69a4f0','name':'ServiceStack.Text-3.8.3.0.dll','artifactId':'ServiceStack.Text-3.8.3.0.dll','version':'3.8.3.0','groupId':'ServiceStack.Text','licenses':[{'name':'AGPL 3.0','references':[]}]},{'keyUuid':'efcf504d-403b-43d2-819d-57acf7402037','type':'Nuget','productName':'NPM - latest','projectName':'nexus - latest','description':'A very extensive set of extension methods that allow you to more naturally specify the expected outc...','directDependency':true,'matchType':'Exact Match','sha1':'f20766c716e9a46771ff5b9328e43c0a858ff565','name':'fluentassertions.4.19.4.nupkg','artifactId':'fluentassertions.4.19.4.nupkg','version':'4.19.4','groupId':'FluentAssertions','licenses':[{'name':'Apache 2.0','references':[]}]}}";
            //const string path = "../../data/NPM-latest.json";
            string fileContent = File.ReadAllText(path);

            //Dictionary<String, List<WSLibrary>> libs = 
            //    JsonConvert.DeserializeObject<Dictionary<String, List<WSLibrary>>>(File.ReadAllText(path));
            JsonTextReader reader = new JsonTextReader(new StringReader(fileContent));
            while (reader.Read())
            {
                
                if (reader.Value != null)
                {
                    Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                }
                else
                {
                    Console.WriteLine("Token: {0}", reader.TokenType);
                }
            }



            //DataTable libsTable = libs.Tables["libraries"];
            //Console.WriteLine(libsTable.Rows.Count);
            // dynamic libs = JsonConvert.DeserializeObject<JsonArrayAttribute>(File.ReadAllText(path));

            //var libs = JsonSerializer.DeserializeObject

            /*
                        foreach (dynamic entry in libs) {
                            string name = entry.name;
                            Console.WriteLine(name);
                        }
            */
            // Console.WriteLine(libs);

        }
    }
}
