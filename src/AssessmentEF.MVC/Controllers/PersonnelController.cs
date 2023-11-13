using Microsoft.AspNetCore.Mvc;
using AssessmentEF.MVC.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Xml;

namespace AssessmentEF.MVC.Controllers
{
    public class PersonnelController : Controller
    {
        private readonly Uri _baseAddress = new Uri("http://localhost:5271/api");
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions options;

        public PersonnelController()
        {
            _client = new HttpClient();
            _client.BaseAddress= _baseAddress;
            options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Personnel> personnels = new List<Personnel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Personnels/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                personnels = JsonSerializer.Deserialize<List<Personnel>>(data, options);
            }
            return View(personnels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Personnel personnel)
        {
            if (personnel == null) return View();
            try
            {                
                string data = JsonSerializer.Serialize<Personnel>(personnel, options);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Personnels/add", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Index");
            }
            try
            {
                Personnel personnel = new Personnel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Personnels/getbyid/" + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    personnel = JsonSerializer.Deserialize<Personnel>(data, options);
                }
                return View(personnel);                
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Personnel personnel)
        {
            if (personnel == null) return View();
            try
            {
                string data = JsonSerializer.Serialize<Personnel>(personnel, options);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Personnels/edit", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }
    }
}
