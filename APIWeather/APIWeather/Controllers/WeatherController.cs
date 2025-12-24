using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using static APIWeather.Models.Class;
using static System.Net.WebRequestMethods;

namespace APIWeather.Controllers
{
    public class WeatherController : Controller
    {
        private List<string> sehirler = new List<string>
   {
    "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya",
    "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis",
    "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce",
    "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane",
    "Hakkari", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük", "Karaman",
    "Kars", "Kastamonu", "Kayseri", "Kilis", "Kırıkkale", "Kırklareli", "Kırşehir", "Kocaeli", "Konya",
    "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde",
    "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Şanlıurfa", "Şırnak",
    "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak"
   };



        [HttpGet]
        public IActionResult Index()
        {
            var model = new VM
            {
                Cities = sehirler
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(VM model)
        {
            if (!string.IsNullOrEmpty(model.City))
            {
                string url = $"http://api.weatherapi.com/v1/current.json?key=6af3d3efda4e4ada9eb160826252103&q={model.City}&aqi=no=";
                string json = new WebClient().DownloadString(url);
                model.root = JsonConvert.DeserializeObject<Root>(json);
            }

           
            model.Cities = sehirler;

            return View(model);
        }
    }
}
