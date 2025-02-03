using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Rema;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Enter a store name or address to search: ");
        string searchTerm = Console.ReadLine();
        await SearchStores(searchTerm);
    }

    static async Task SearchStores(string searchTerm)
    {
        string apiUrl = "https://kassal.app/api/v1/physical-stores/";
        string apiKey = "9EdGPREltngbUGabEGUAVYAhyuzahvyD0k4J0ztE";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                string requestUrl = $"{apiUrl}?search={searchTerm}";

                HttpResponseMessage response = await client.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseBody);

                if (apiResponse?.Data != null && apiResponse.Data.Count > 0)
                {
                    foreach (var store in apiResponse.Data)
                    {
                        Console.WriteLine($"Store ID: {store.Id}");
                        Console.WriteLine($"Group: {store.Group}");
                        Console.WriteLine($"Name: {store.Name}");
                        Console.WriteLine($"Address: {store.Address}");
                        Console.WriteLine($"Phone: {store.Phone}");
                        Console.WriteLine($"Email: {store.Email}");
                        Console.WriteLine($"Fax: {store.Fax}");
                        Console.WriteLine($"Logo URL: {store.Logo}");
                        Console.WriteLine($"Website: {store.Website}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No stores found matching your search.");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
            catch (JsonException e)
            {
                Console.WriteLine($"JSON deserialization error: {e.Message}");
            }
        }
    }
}
