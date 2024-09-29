using IUCULTURE.front.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using System.Text;
using System.Text.Json;
using X.PagedList;

namespace IUCULTURE.front.Controllers
{
     
    public class ClubController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ClubController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [Authorize(Roles = "ExpertAdmin,SeniorAdmin,JuniorAdmin")]
        public async Task<IActionResult> List(int page = 1)
        {
            var token = User.Claims.FirstOrDefault(x=>x.Type==
            "accessToken")?.Value;
            if(token!=null)
            {
                var client = this.httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",token);

                var response = await client.GetAsync("http://localhost:5048/api/clubs");
           
                if(response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<ClubListModel>>
                        (jsonData, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });

                    return View(result.ToPagedList(page, 10));
                
                }
               
            }
            
            return View();
        }

        [Authorize(Roles = "ExpertAdmin")]
        public async Task<IActionResult> Remove(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = this.httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                await client.DeleteAsync($"http://localhost:5048/api/clubs/{id}");
            }

            return RedirectToAction("List");
        }




        public IActionResult Create()
        {
            return View(new CreateClubModel());
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateClubModel model)
        {
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

                    var response = await client.PostAsync("http://localhost:5048/api/clubs", content);
                
                    if(response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bir hata oluştu");
                    }
                
                }

                

            }

            return View(model);
        }
        [Authorize(Roles = "ExpertAdmin")]
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

                var response = await client.GetAsync($"http://localhost:5048/api/clubs/{id}");

                if (response.IsSuccessStatusCode) 
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<ClubListModel>
                        (jsonData, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });

                    return View(result);
                }


            }

            return RedirectToAction("List");
        }

        [Authorize(Roles = "ExpertAdmin")]
        [HttpPost]
        public async Task<IActionResult> Update(ClubListModel model)
        {
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

                    var response = await client.PutAsync("http://localhost:5048/api/clubs", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bir hata oluştu");
                    }

                }



            }

            return View(model);
        }



    }
}
