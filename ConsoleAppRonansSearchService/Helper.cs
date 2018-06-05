using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRonansSearchService
{
    class Helper
    {
        public const string IndexName = "[Index Name]";

        public static SearchServiceClient Initialize(string serviceName, string apiKey)
        {
            SearchServiceClient serviceClient = new SearchServiceClient(serviceName, new SearchCredentials(apiKey));
            DeleteIfIndexExists(serviceClient);
            CreateIndex(serviceClient);

            return serviceClient;
        }

        private static void CreateIndex(SearchServiceClient client)
        {
            var IndexDefination = new Index()
            {
                Name = IndexName,
                Fields = new[]
                {
                    new Field("id", DataType.String)                                { IsKey = true },
                    new Field("class", DataType.String)                              { IsSearchable = true, IsFacetable = true, IsRetrievable = true, IsSortable = true, IsFilterable = true},
                    new Field("defaultOption", DataType.Boolean)                    { IsFacetable = true, IsRetrievable = true, IsSortable = true, IsFilterable = true},
                    new Field("description", DataType.String)                       { IsSearchable = true, IsFacetable = true, IsRetrievable = true, IsSortable = true, IsFilterable = true},
                    new Field("name", DataType.String)                              { IsSearchable = true, IsFacetable = true, IsRetrievable = true, IsSortable = true, IsFilterable = true},
                    new Field("nameKey", DataType.String)                           { IsFacetable = true, IsRetrievable = true, IsSortable = true, IsFilterable = true},
                }
            };

            client.Indexes.Create(IndexDefination);

        }

        private static void DeleteIfIndexExists(SearchServiceClient client)
        {
            if (client.Indexes.Exists(IndexName))
            {
                client.Indexes.Delete(IndexName);
            }
        }
    }
}

