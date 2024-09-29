using IUCULTURE.front.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using System.Text;
using System.Text.Json;
using X.PagedList;

namespace IUCULTURE.front.Controllers
{
   
    public class ClubPublicController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ClubPublicController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


       
        public async Task<IActionResult> List(int page =1)
        {
            var client = this.httpClientFactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5048/api/clubs");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<ClubListModel>>
                    (jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                return View(result.ToPagedList(page, 16));

            }

            return View();
        }


        public async Task<IActionResult> ClubDetails(int id)
        {
            var client = this.httpClientFactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5048/api/clubs");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var allClubs = JsonSerializer.Deserialize<List<ClubListModel>>(
                    jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                // Belirli id'ye sahip etkinliği filtrele
                var selectedClub = allClubs.FirstOrDefault(club => club.Id == id);

                if (selectedClub != null)
                {
                    return View(selectedClub);
                }
            }

            return View();
        }


    }
}
