//using ArticleViewer.Models;
//using System.Net.Http.Json;

//namespace ArticleViewer.Services
//{
//    public class ArticleService
//    {
//        private readonly HttpClient _httpClient;

//        public ArticleService(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }

//        public async Task<List<Article>> GetArticlesAsync()
//        {
//            try
//            {
//                var response = await _httpClient.GetAsync("https://ps-dev-1-partnergateway.patientsky.dev/assignment/articles");

//                if (response.IsSuccessStatusCode)
//                {
//                    return await response.Content.ReadFromJsonAsync<List<Article>>();
//                }
//                else
//                {
//                    throw new Exception($"API error: {response.StatusCode}");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.Message}");
//                throw new Exception("An error occurred while fetching articles.");
//            }
//        }


//        public async Task<Article> GetArticleByIdAsync(int id)
//        {
//            try
//            {
//                var response = await _httpClient.GetFromJsonAsync<Article>($"https://ps-dev-1-partnergateway.patientsky.dev/assignment/articles/{id}");

//                if (response == null)
//                {
//                    throw new Exception("Article not found.");
//                }

//                return response;
//            }
//            catch (HttpRequestException ex)
//            {
//                Console.WriteLine($"HTTP Error: {ex.Message}");
//                throw new Exception("Network error while fetching the article.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.Message}");
//                throw new Exception("An unexpected error occurred while fetching the article.");
//            }
//        }
//    }
//}

using ArticleViewer.Models;
using System.Net.Http.Json;

namespace ArticleViewer.Services
{
    public class ArticleService
    {
        private readonly HttpClient _httpClient;

        public ArticleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Fetch all articles
        public async Task<List<Article>> GetArticlesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://ps-dev-1-partnergateway.patientsky.dev/assignment/articles");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Article>>();
                }
                else
                {
                    throw new Exception($"API error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("An error occurred while fetching articles.");
            }
        }

        // Fetch a specific article by ID
        public async Task<Article> GetArticleByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<Article>($"https://ps-dev-1-partnergateway.patientsky.dev/assignment/articles/{id}");

                if (response == null)
                {
                    throw new Exception("Article not found.");
                }

                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Error: {ex.Message}");
                throw new Exception("Network error while fetching the article.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("An unexpected error occurred while fetching the article.");
            }
        }
    }
}
