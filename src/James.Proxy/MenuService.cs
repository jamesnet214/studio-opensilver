using Studio.Proxy;
using Studio.Support.Local.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace James.Proxy
{
    public class MenuService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public MenuService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://jamesnet.dev/")
            };
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<MenuResponse>> GetMenusAsync(int? menuType = null)
        {
            try
            {
                // 메뉴 타입이 주어진 경우, 해당 타입의 메뉴만을 필터링하여 요청합니다.
                var endpoint = menuType.HasValue ? $"api/menu/getmenus?type={menuType}" : "api/menu/getmenus";

                // "api/menu/getmenus" 엔드포인트에서 메뉴 데이터를 비동기적으로 가져옵니다.
                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                var menus = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<MenuResponse>>(menus, _jsonOptions);
            }
            catch (Exception ex)
            {
                // 에러 처리: 로깅, 사용자에게 알림 등
                Console.WriteLine($"Error fetching menus: {ex.Message}");
                return new List<MenuResponse>();
            }
        }

        public async Task<List<MenuResponse>> GetMenusWithSelectionAsync(int articleId, int? menuType = null)
        {
            try
            {
                // 메뉴 타입과 articleId를 사용하여 엔드포인트 URL 구성
                var endpoint = $"api/menu/getmenuswithselection/{articleId}" + (menuType.HasValue ? $"?type={menuType}" : "");

                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                var menus = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<MenuResponse>>(menus, _jsonOptions);
            }
            catch (Exception ex)
            {
                // 에러 처리: 로깅, 사용자에게 알림 등
                Console.WriteLine($"Error fetching menus with selection: {ex.Message}");
                return new List<MenuResponse>();
            }
        }
    }
}
