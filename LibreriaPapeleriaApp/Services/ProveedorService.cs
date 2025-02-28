using LibreriaPapeleriaApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;


namespace LibreriaPapeleriaApp.Services
{
    public class ProveedorService
    {
        private readonly HttpClient _httpClient;

        public ProveedorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Proveedor>> GetProveedoresAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5002/api/proveedores");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Proveedor>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Proveedor> GetProveedorByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5002/api/proveedores/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Proveedor>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CreateProveedorAsync(Proveedor proveedor)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5002/api/proveedores", proveedor);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProveedorAsync(Proveedor proveedor)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5002/api/proveedores/{proveedor.ProveedorId}", proveedor);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProveedorAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5002/api/proveedores/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}