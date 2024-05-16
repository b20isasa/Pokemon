using lychee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace lychee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public async Task<ActionResult> Index(string Namn)
        {
            using (HttpClient client = new HttpClient())
            {
                var BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string Url = BaseAddress + Namn;
                HttpResponseMessage response = await client.GetAsync(Url);

                try
                {
                   
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var pokemon = JsonConvert.DeserializeObject<LoopModell>(data); //converterar till Json-format

                        var pokemonId = pokemon.id; // h�mtar ut id
                        var pokemonName = pokemon.name;
                        var pokemonUrl = pokemon.abilities[0].ability.url; //url:en eftersom den �r neslad

                        LoopModell loopas = new LoopModell
                        {
                            id = pokemonId,
                            name = pokemonName,
                            image = pokemonUrl  // dessa b�r de eftertraktade elementen fr�n API:n.
                        };

                        return Json(loopas);  // Visar som en array
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound) //  HttpStatusCode.NotFound �r densamma som 404, page not found.
                    {
                        ViewBag.FelMed = "Denna pokemon finns inte. Testa s�ka p� n�gon annan.";
                    }
                }
                catch (Exception ex)  // egentligen beh�vs inte try and catch med tanke p� if-conditions. 
                {
                    Console.WriteLine($" Ett fel: {ex.Message}");
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
