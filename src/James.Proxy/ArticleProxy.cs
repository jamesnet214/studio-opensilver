using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System;
using Studio.Support.Local.Models;
using System.Collections.Generic;

namespace Studio.Proxy
{
    public class ArticleProxy
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ArticleProxy()
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

        public async Task<List<ArticleResponse>> GetArticles(string menuId = null, string order = "recent")
        {
            var response = await _httpClient.GetAsync($"api/article/getarticles?menuId={menuId}&order={order}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ArticleResponse>>(content, _jsonOptions);
        }

        public async Task<List<ArticleResponse>> GetArticlesByUserId()
        {
            var response = await _httpClient.GetAsync("api/article/getarticlesbyuserid");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ArticleResponse>>(content, _jsonOptions);
        }

        public async Task<ArticleResponse> GetArticleById(int articleId)
        {
            var response = await _httpClient.GetAsync($"api/article/{articleId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ArticleResponse>(content, _jsonOptions);
        }

        public async Task<ArticleResponse> GetEditArticleById(int articleId)
        {
            var response = await _httpClient.GetAsync($"api/article/geteditarticlebyid/{articleId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ArticleResponse>(content, _jsonOptions);
        }

        public async Task<bool> CheckEditPermission(int articleId)
        {
            var response = await _httpClient.GetAsync($"api/article/checkeditpermission/{articleId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool>(content, _jsonOptions);
        }

        public async Task<bool> CheckCreatePermission()
        {
            var response = await _httpClient.GetAsync("api/article/checkcreatepermission");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool>(content, _jsonOptions);
        }

        public async Task<int> AddArticle(int languageId)
        {
            var json = JsonSerializer.Serialize(languageId);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/article/add", stringContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<int>(content, _jsonOptions);
        }

        public async Task UpdateArticleCreatedDate(UpdateArticleCreatedDateRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/article/updatearticlecreateddate", stringContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task IncrementViewCount(int articleId)
        {
            var response = await _httpClient.PostAsync($"api/article/incrementviewcount/{articleId}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<NationalityCount>> GetNationalityCounts()
        {
            var response = await _httpClient.GetAsync("api/article/nationality-counts");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<NationalityCount>>(content, _jsonOptions);
        }
    }
}