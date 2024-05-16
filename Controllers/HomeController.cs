using lychee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.OutputCaching;





namespace lychee.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        public async Task<ActionResult> Index(string Namn)
        {
            //PokemonModell model = new PokemonModell();
            LoopModell loopa = new LoopModell();

            using (HttpClient client = new HttpClient())
            {
                var BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/"); // används så exempelvis en variabel kan tillsättas i länkens slut.
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); // godkänna JSON-format
                /*Console.WriteLine(BaseAddress);
                 string Url = BaseAddress + Namn;
               // string myString = Nummer.ToString();
                //string IdNummer = BaseAddress + myString;*/
                string urlString = "https://pokeapi.co/api/v2/pokemon/";
                // var pika = "pikachu";
                string Url = urlString + Namn;
                //string IdUrl = urlString + myString;
                Console.WriteLine(BaseAddress);

                HttpResponseMessage response = await client.GetAsync(Url); // ÄNDRA TILL INSERT
               // HttpResponseMessage responseNum = await client.GetAsync(IdUrl); // ÄNDRA TILL INSERT


                try
                {
                    if (string.IsNullOrEmpty(Namn))/* && string.IsNullOrEmpty(myString))*/
                    {
                        ViewBag.Tom = Namn;
                    }


                    else if ((response.IsSuccessStatusCode))/*|| (responseNum.IsSuccessStatusCode))*/
                    {

                        var data = await response.Content.ReadAsStringAsync();
                        //var FetchData = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data);
                        //ViewBag.Message = FetchData;
                        var pokemon = JsonConvert.DeserializeObject<LoopModell>(data);

                        var pokemonName = pokemon.name;
                        var pokemonId = pokemon.id;
                        var pokemonUrl = pokemon.url;

                        LoopModell loopas = new LoopModell
                        {
                            name = pokemonName,
                            url = pokemonUrl,
                            id = pokemonId
                            
                        };

                        return Json(loopas);
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)// för att titta om felmeddelandet är densamma som 404. 
                    {
                        ViewBag.FelMed = "Denna pokemon finns inte:(( testa söka på någon annan :D";
                        return View();
                    }
                }
                catch (Exception ex) // ta bort denna förstör för else- IF
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");

                }
            }
            return View();

        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
