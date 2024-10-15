using Microsoft.Extensions.Options;
using QuickSnapWeb.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace QuickSnapWeb.Pictures;

public class PictureProvider(HttpClient _httpClient, IOptions<ApiOptions> _apiOptions) : IPictureProvider
{
    public async Task<PicturesResponseViewModel> GetAsync(string token)
    {
        try
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_apiOptions.Value.ApiUrl}/api/pictures"),
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);
            return (await response.Content.ReadFromJsonAsync<PicturesResponseViewModel>())!;
        }
        catch (Exception ex)
        {
            var a = ex;
            throw;
        }
    }
}
