﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.MenuTableDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class MenuTablesController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public MenuTablesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7112/api/MenuTable/List");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
				return View(values);
			}
			return View();
		}
        [HttpGet]
        public IActionResult CreateMenuTable()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMenuTableDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7112/api/MenuTable", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
		public async Task<IActionResult> UpdateMenuTable(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7112/api/MenuTable/{id}");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<UpdateMenuTableDto>(jsonData);
			if (responseMessage.IsSuccessStatusCode)
			{
				return View(values);
			}
			return View();

		}
		[HttpPost]
		public async Task<IActionResult> UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateMenuTableDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7112/api/MenuTable", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteMenuTable(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7112/api/MenuTable/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return NoContent();
			}
			return View();
		}
		
        public async Task<IActionResult> TableListByStatus()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7112/api/MenuTable/List");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
