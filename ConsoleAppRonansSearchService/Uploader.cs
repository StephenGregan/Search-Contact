using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppRonansSearchService
{
    class Uploader
    {
        private List<Json.Status> PrepareDocuments()
        {
            List<Json.Status> searchContactDocuments = new List<Json.Status>();

            Json.Status js = new Json.Status()
            {
                id = "1000",
            };

            searchContactDocuments.Add(js);
            

            return searchContactDocuments;

        }

        public void Upload(ISearchIndexClient indexClient)
        {
            try
            {
                var documents = PrepareDocuments();
                var batch = IndexBatch.Upload(documents);
                indexClient.Documents.Index(batch);

                Thread.Sleep(2000);
            }
            catch (IndexBatchException e)
            {
                Console.WriteLine($"Opps The Following index failed...\n { e.IndexingResults.Where(r => !r.Succeeded).Select(r => r.Key)}");

            }

        }
    }
}

