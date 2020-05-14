/*====================================================================================
ApiController - kontroler, który obsługuje API. To miejsce, w którym zewnętrzne      |
API zostaje podłączone do aplikacji webowej.                                         |
====================================================================================*/
/*====================================================================================
                                      GETJOKE                                        |
Jest to funkcja, która ma za zadanie pobierać żarty. Jeżeli zadanie to jest          |
zakończone sukcesem, to konwertuje ona ten żart - następuje jego deserializacja.     |
====================================================================================*/
/*====================================================================================
                                  SEARCHJOKE                                         |
Funkcja do szukania żartów ze względu na wpisane słowo. Jeżeli wpisane przez nas     |
słowo jest zawarte w żartach, będą one wyświetlone w postaci list. Funkcja działa w  |
taki sposób, że wyszukuje żart z taką zawartością oraz ją deserializuje. Następnie   |
tworzona jest lista stringów, a żart zostaje do niej wpisany.                        |
====================================================================================*/



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Jokes_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IdentityByExamples.Controllers
{
    public class ApiController : Controller
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiController(ILogger<ApiController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        private async Task<JokeModel> GetJoke()
        {
            var client = _httpClientFactory.CreateClient("API Client");
            var result = await client.GetAsync("");
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JokeModel>(content);
            }
            return null;
        }

        [HttpPost]
        public async Task<List<string>> SearchJoke()
        {
            string searchedWord = Request.Form["word"];
            var client = _httpClientFactory.CreateClient("API Client");
            string url = client.BaseAddress + "search?term=" + searchedWord;
            string responseBody = await client.GetStringAsync(url);

            JokesModel jokes = JsonConvert.DeserializeObject<JokesModel>(responseBody);
            List<string> lista = new List<string>();

            for (int i = 0; i < jokes.Results.Count; i++)
            {
                lista.Add(jokes.Results[i].Joke);
            }
            //użycie Linq to posortowania żartów od najkrótszego do najdłuższego
            return lista.OrderBy(s => s.Length).ToList(); 
        }

        public async Task<IActionResult> Index()
        {
            var model = await GetJoke();
            return View(model);
        }

        public async Task<IActionResult> DisplayJokes()
        {
            var list = await SearchJoke();
            ViewBag.model = list;
            var result = list.Count(); //użycie Linq - zliczanie ilości wyszukanych żartów
            string message = "";
            if (result == 0)
                message = "Niestety... Nie udało nam się znaleźć pasujących żartów. \n " +
                    "Wróć do wyszukiwarki i spróbuj wpisać inne słowo";
            else if (result == 1)
                message = "Odnaleziono " + result + " żart";
            else if (result > 1 && result < 5)
                message = "Odnaleziono " + result + " żarty";
            else
                message = "Odnaleziono " + result + " żartów";
          
            ViewBag.message = message;
            ViewBag.result = result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
