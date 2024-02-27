using clientproject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Json;

namespace clientproject.Controllers
{
    public class HospitalController : Controller
    {
        private readonly string ApiAdres = "https://localhost:7046/api/Hastane/";
         HttpClient client;

        public HospitalController()
        {
            client = new HttpClient();
        }

        public  async Task<IActionResult> Index()
        {
           List<HastaneUpdateVM> hastaneler = await client.GetFromJsonAsync<List<HastaneUpdateVM>>("https://localhost:7046/api/Hastane/GetAllHospitals");
            return View();
        }
        public async Task<IActionResult> GetById(int id=1)
        {
            HastaneUpdateVM hastane= await client.GetFromJsonAsync<HastaneUpdateVM>(ApiAdres+"GetHospitalById?id=" +id );
            return View(hastane);
        }
        public async Task<IActionResult> Create(HastaneUpdateVM hastane)
        {
            hastane.HastaneAd = "Kartal ";
            hastane.Adres = "Adres";
            var ekle = client.PostAsJsonAsync(ApiAdres + "AddHospital", hastane);

            return View();
        }
        public async Task<IActionResult> Update(int id=1)
        {
            HastaneUpdateVM hastaneUpdate = await client.GetFromJsonAsync<HastaneUpdateVM>(ApiAdres + "UpdateHospital" + id);
            hastaneUpdate.HastaneAd = "Kartal ";
            hastaneUpdate.Adres = "Adres";
            var result = await client.PutAsJsonAsync(ApiAdres + "UpdateHospital" + id, hastaneUpdate);
            return View();

        }
        public async Task<IActionResult> Delete(int id)
        {
            
            var result = await client.DeleteAsync(ApiAdres + "DeleteHospital/" + id);

            if (result.IsSuccessStatusCode)
            {
                
                return RedirectToAction("Index"); 
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                
                return View("Error");
            }
        }
    }
}
