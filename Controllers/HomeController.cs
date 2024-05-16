using lychee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;





namespace lychee.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public async Task<ActionResult> Index(string Namn)
        {
            LoopModell loopa = new LoopModell();

            using (HttpClient client = new HttpClient())
            {
                var BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/"); // används så exempelvis en variabel kan tillsättas i länkens slut.
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); // godkänna JSON-format

                string urlString = "https://pokeapi.co/api/v2/pokemon/";
                string Url = urlString + Namn;
                Console.WriteLine(BaseAddress);

                HttpResponseMessage response = await client.GetAsync(Url);
                try
                {
                    if (string.IsNullOrEmpty(Namn))/* && string.IsNullOrEmpty(myString))*/
                    {
                        ViewBag.Tom = Namn;
                    }


                    else if (response.IsSuccessStatusCode)
                    {

                        var data = await response.Content.ReadAsStringAsync();
                        var pokemon = JsonConvert.DeserializeObject<LoopModell>(data);

                        var pokemonId = pokemon.id;
                        var pokemonName = pokemon.name;
                        var pokemonUrl = pokemon.image;


                        LoopModell loopas = new LoopModell
                        {
                            id = pokemonId,
                            name = pokemonName,
                            image = pokemonUrl

                        };
                        
                        foreach (var ability in pokemon.abilities)
                        {
                            var abilityUrl = ability.image;
                            ViewBag.urls = abilityUrl;
                        }
                        return Json(loopas);
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)// för att titta om felmeddelandet är densamma som 404. 
                    {
                        ViewBag.FelMed = "Denna pokemon finns inte:(( testa söka på någon annan :D";
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" ett fel: {ex.Message}");

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
