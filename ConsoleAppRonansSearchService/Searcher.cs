﻿using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRonansSearchService
{
    class Searcher
    {

        public void SearchDocuments(ISearchIndexClient indexClient, string searchText, string filter = null, List<string> facet = null)
        {
            var sp = new SearchParameters();

            if (!string.IsNullOrEmpty(filter))
            {
                sp.Filter = filter;
            }

            if (facet != null)
            {
                sp.Facets = facet;
            }

            DocumentSearchResult<Json.Status> response = indexClient.Documents.Search<Json.Status>(searchText, sp);

            if (response.Facets != null)
            {
                FacetResults facetResults = response.Facets;
                foreach (var facetResult in facetResults)
                {
                    Console.WriteLine($"Facet Key : {facetResult.Key}");
                    foreach (var f in facetResult.Value)
                    {
                        Console.WriteLine($"f.value, ({f.Count})");
                    }
                }
            }
            else
            {
                foreach (SearchResult<Json.Status> result in response.Results)
                {
                    Console.WriteLine(result.Document);
                }
            }
        }
    }
}

