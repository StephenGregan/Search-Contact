using Microsoft.Azure.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRonansSearchService
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceName = "[name of search service]";

            string apiKey = "[api key]";

            SearchServiceClient serviceClientApi = Helper.Initialize(serviceName, apiKey);
            ISearchIndexClient indexClientApi = serviceClientApi.Indexes.GetClient(Helper.IndexName);

            Uploader uploader = new Uploader();
            uploader.Upload(indexClientApi);

            Searcher searcher = new Searcher();

            Console.WriteLine("Search by name......\n");
            searcher.SearchDocuments(indexClientApi, "[name]");
            Console.WriteLine(string.Empty);

            //Console.WriteLine("Search Everything......\n");
            //searcher.SearchDocuments(indexClientApi, "*");
            //Console.WriteLine(string.Empty);

            //Console.WriteLine("Search everybody under 30 year's of age.......\n");
            //searcher.SearchDocuments(indexClientApi, "*", "dateOfBirth lt '01/01/1998'");

            //Console.WriteLine("Begin searching by ..... facet\n");
            List<string> facets = new List<string>();
            facets.Add("name");
            //apiKey.SearchDocuments(indexClientApi, "*", null, facets);

            Console.ReadLine();
        }
    }
}
