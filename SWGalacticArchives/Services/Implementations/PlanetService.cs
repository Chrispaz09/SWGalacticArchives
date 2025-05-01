using Newtonsoft.Json;
using SWGalacticArchives.Models;
using SWGalacticArchives.Services.Interfaces;

namespace SWGalacticArchives.Services.Implementations
{
    public class PlanetService : IPlanetService
    {
        private readonly HttpClient _httpClient;

        private string _path = "/planets/";

        public PlanetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Result<Planet>>> GetAllResultsAsync(string? getPageItems = null, CancellationToken token = default)
        {
            string fullPath = string.Empty;

            if (getPageItems is not null)
            {
                fullPath = getPageItems;
            }
            else
            {
                fullPath = _httpClient.BaseAddress + _path;
            }

            
            var results = new List<Result<Planet>>();

            try
            {
                var response = await _httpClient.GetAsync(fullPath, token);

                response.EnsureSuccessStatusCode();

                var jsonSerialized = await response.Content.ReadAsStringAsync(token);

                var root = JsonConvert.DeserializeObject<Root<Planet>>(jsonSerialized);

                results = root.Results;
            }
            catch (Exception)
            {

                throw;
            }

            return results;
        }

        public async Task<Planet> GetAsync(string id, CancellationToken token = default)
        {
            var fullPath = _httpClient.BaseAddress + _path + id.ToString();
            var response = await _httpClient.GetAsync(fullPath, token);

            var getPlanet = new Planet();

            try
            {
                response.EnsureSuccessStatusCode();

                var jsonSerialized = await response.Content.ReadAsStringAsync(token);

                var root = JsonConvert.DeserializeObject<Root<Planet>>(jsonSerialized);

                var result = root.Result;

                getPlanet = result.Properties;

                getPlanet.Uid = result.Uid;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error fetching response from {fullPath}", ex.InnerException);
            }

            return getPlanet;
        }

        public async Task<DataGridInfo> GetDataGridInfoAsync(string? getNewPagedetails = null, CancellationToken token = default)
        {
            string fullPath = string.Empty;

            if (getNewPagedetails is not null)
            {
                fullPath = getNewPagedetails;
            }
            else
            {
                fullPath = _httpClient.BaseAddress + _path;
            }

            var response = await _httpClient.GetAsync(fullPath, token);
            var results = new List<Result<Vehicle>>();
            var dataGridInfo = new DataGridInfo();
            try
            {
                response.EnsureSuccessStatusCode();

                var jsonSerialized = await response.Content.ReadAsStringAsync(token);

                var root = JsonConvert.DeserializeObject<Root<Vehicle>>(jsonSerialized);

                dataGridInfo.total_records = root.total_records;

                dataGridInfo.total_pages = root.total_pages;

                dataGridInfo.next = root.next;

                dataGridInfo.previous = root.previous;
            }
            catch (Exception)
            {

                throw;
            }

            return dataGridInfo;
        }
    }
}
