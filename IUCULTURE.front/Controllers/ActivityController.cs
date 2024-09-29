using IUCULTURE.front.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using System.Text;
using System.Text.Json;
using X.PagedList;

namespace IUCULTURE.front.Controllers
{
    [Authorize(Roles = "ExpertAdmin,SeniorAdmin,JuniorAdmin")]
    public class ActivityController : Controller
    {

        private readonly IHttpClientFactory httpClientFactory;

        public ActivityController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> List(int page = 1)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type ==
            "accessToken")?.Value;
            if (token != null)
            {
                var client = this.httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync("http://localhost:5048/api/activities");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<ActivityListModel>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    return View(result.ToPagedList(page, 10));

                }
            }

            return View();
        }


        public async Task<IActionResult> Remove(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type ==
                "accessToken")?.Value;
            if (token != null)
            {
                var client = this.httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                await client.DeleteAsync($"http://localhost:5048/api/activities/{id}");

            }

            return RedirectToAction("List");
        }



        
        public async Task<IActionResult> Create()
        {
            var model = new CreateActivityModel();
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = this.httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync($"http://localhost:5048/api/clubs");
            
                if(response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<List<ClubListModel>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    model.Clubs = new Microsoft.AspNetCore.Mvc.Rendering.SelectList
                        (data,"Id","ClubName");


                    return View(model);

                }

            }

            return RedirectToAction("List");

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActivityModel model)
        {
            var data = TempData["Clubs"]?.ToString();
            if(data!=null) {

                var clubs = JsonSerializer.Deserialize<List<SelectListItem>>(data);

                model.Clubs = new SelectList(clubs, "Value", "Text");
            
            }

            if (ModelState.IsValid)
            {
                var token = User.Claims.FirstOrDefault(x => x.Type ==
                "accessToken")?.Value;
                if (token != null)
                {
                    var client = this.httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var jsonData = JsonSerializer.Serialize(model);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    
                    var response = await client.PostAsync($"http://localhost:5048/api/activities",content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List");
                    }
                    ModelState.AddModelError("", "Bir hata oluştu");
                }
             }
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type ==
                          "accessToken")?.Value;
            if (token != null)
            {
                var client = this.httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.
                    AuthenticationHeaderValue("Bearer", token);



                var responseActivity = await client.GetAsync($"http://localhost:5048/api/activities/{id}");

                if (responseActivity.IsSuccessStatusCode)
                {
                    var jsonData = await responseActivity.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<UpdateActivityModel>
                        (jsonData, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });


                    var responseClub = await client.GetAsync($"http://localhost:5048/api/clubs");

                    if (responseClub.IsSuccessStatusCode)
                    {
                        var jsonClubData = await responseClub.Content.ReadAsStringAsync();
                        var data = JsonSerializer.Deserialize<List<ClubListModel>>(jsonClubData, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });


                        if (result != null)
                        {
                            result.Clubs = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(data, "Id", "ClubName");
                        }
                        

                    }

                    return View(result);
                }


            }

            return RedirectToAction("List");
        }

       
        [HttpPost]
        public async Task<IActionResult> Update(UpdateActivityModel model)
        {
            var data = TempData["Clubs"]?.ToString();
            if (data != null)
            {

                var clubs = JsonSerializer.Deserialize<List<SelectListItem>>(data);

                model.Clubs = new SelectList(clubs, "Value", "Text", model.ClubId);
    

    }

            if (ModelState.IsValid)
            {
                var token = User.Claims.FirstOrDefault(x => x.Type ==
                "accessToken")?.Value;
                if (token != null)
                {
                    var client = this.httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var jsonData = JsonSerializer.Serialize(model);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"http://localhost:5048/api/activities", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List");
                    }
                    ModelState.AddModelError("", "Bir hata oluştu");
                }
            }
            return View(model);
        }
        
       
        
    }
    
}
