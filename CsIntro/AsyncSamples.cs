using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CsIntro
{
    class AsyncSamples
    {
        public object JsonObject { get; private set; }

        public void InputOutputBoundCode()
        {
            Task<List<string>> task = Task.Run<List<string>>(async () => await GetPokemonsAsync());
            List<string> pokemons = task.Result;

            Console.WriteLine("Thses are the first 20 pokemons:");
            foreach (var pokemon in pokemons)
            {
                Console.WriteLine(pokemon);
            }
        }

        public void CpuBoundCode()
        {
            Console.WriteLine("Heavy CPU Process Started");
            Task.Run<Task>(async () => await DoHeavyProcess());
            Console.WriteLine("Heavy left running in the background.");
        }

        private async Task<List<string>> GetPokemonsAsync()
        {
            List<string> pokemons = new List<string>();

            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync("https://pokeapi.co/api/v2/pokemon/");

            // The line above IS relevant for the example while the code below is NOT.
            // Code below is just to parse the result from that REST service as we have no class to parse it against. 

            dynamic jsonObject = (JObject)JsonConvert.DeserializeObject(content);
            var pokemonsJson = jsonObject["results"];
            foreach (var pokemon in pokemonsJson)
            {
                var pokemonObject = (JObject)JsonConvert.DeserializeObject(pokemon.ToString());
                pokemons.Add(pokemonObject["name"].ToString());
            }

            return pokemons;
        }

        private async Task DoHeavyProcess()
        {
            await Task.Run(() => {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                }

                Console.WriteLine("Heavy CPU Process Finished");
            });
        }

    }
}
