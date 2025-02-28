using LibreriaPapeleriaApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;


namespace LibreriaPapeleriaApp.Services
{
    public class ProductOrdenService
    {
        private readonly HttpClient _httpClient;

        public ProductOrdenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5001/api/productos");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Producto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5001/api/productos/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Producto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CreateProductoAsync(Producto producto)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5001/api/productos", producto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductoAsync(Producto producto)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5001/api/productos/{producto.ProductoId}", producto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5001/api/productos/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Orden>> GetOrdenesAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5001/api/ordenes");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Orden>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Orden> GetOrdenByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5001/api/ordenes/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Orden>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CreateOrdenAsync(Orden orden)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5001/api/ordenes", orden);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateOrdenAsync(Orden orden)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5001/api/ordenes/{orden.OrdenId}", orden);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteOrdenAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5001/api/ordenes/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
