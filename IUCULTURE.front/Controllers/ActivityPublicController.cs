using IUCULTURE.front.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using System.Dynamic;
using System.Text;
using System.Text.Json;
using System.Reflection;
using IUCULTURE.Back.Persistence.Context;
using X.PagedList;
using Microsoft.EntityFrameworkCore;

namespace IUCULTURE.front.Controllers
{
    
    public class ActivityPublicController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ActivityPublicController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }



        public async Task<IActionResult> List(int page=1)
        {
            
            
            var client = this.httpClientFactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5048/api/activities");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<ActivityListModel>>
                (jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                return View(result.ToPagedList(page,15));

            }

            return View();
        }





        public async Task<IActionResult> ActivityDetails(int id)
        {
            var client = this.httpClientFactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5048/api/activities");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var allActivities = JsonSerializer.Deserialize<List<ActivityListModel>>(
                    jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                // Belirli id'ye sahip etkinliği filtrele
                var selectedActivity = allActivities.FirstOrDefault(activity => activity.Id == id);

                if (selectedActivity != null)
                {
                    return View(selectedActivity);
                }
            }

            return View();

        }




    }
}
