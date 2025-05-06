using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ProductDto;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
	public class UILayoutOurMenuComponentPartial2:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public UILayoutOurMenuComponentPartial2(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7112/api/Product/GetLast9ProductsWithCategories");
			var jsondata = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryName>>(jsondata);
			return View(values);
		}
	}
}
