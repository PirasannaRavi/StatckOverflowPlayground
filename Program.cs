using System.Collections.Generic;
using Newtonsoft.Json;

namespace StatckOverflowPlayground
{
    class Program
    {
        static void Main(string[] args)
        {

            var json = @"
                {
                    'assets': [
                    {
                    'name': 'abc',
                    'products': [
                        {
                        'id': '11',
                        'status': true
                        },
                        {
                        'id': '14',
                        'status': null
                        }
                    ]
                    },
                    {
                    'name': 'xyz',
                    'products': [
                        {
                        'id': '11',
                        'status': true
                        },
                        {
                        'id': '28',
                        'status': null
                        }
                    ]
                    },
                    {
                    'name': '123',
                    'products': [
                        {
                        'id': '48',
                        'status': null
                        }
                    ]
                    },
                    {
                    'name': '456',
                    'products': [
                        {
                        'id': '11',
                        'status': true
                        }
                    ]
                    }
                ]
                }";

            var root = JsonConvert.DeserializeObject<Root>(json);
            var assets = root.Assets;
            assets.ForEach(a =>
            {
                a.Products.RemoveAll(p => p.Id != 11);
            });
        }
    }

    public partial class Root
    {
        [JsonProperty("assets")]
        public List<Asset> Assets { get; set; }
    }

    public partial class Asset
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }

    public partial class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("status")]
        public bool? Status { get; set; }
    }
}
