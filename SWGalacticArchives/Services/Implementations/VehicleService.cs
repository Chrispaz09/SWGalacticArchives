using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SWGalacticArchives.Models;
using SWGalacticArchives.Services.Interfaces;

namespace SWGalacticArchives.Services.Implementations
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient _httpClient;

        private string _path = "/vehicles/";

        public VehicleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Result<Vehicle>>> GetAllResultsAsync(string? getPageItems = null, CancellationToken token = default)
        {
            string fullPath = string.Empty;

            fullPath = getPageItems is not null ? getPageItems : _httpClient.BaseAddress + _path;

            var results = new List<Result<Vehicle>>();

            try
            {
                var response = await _httpClient.GetAsync(fullPath, token);

                response.EnsureSuccessStatusCode();

                var jsonSerialized = await response.Content.ReadAsStringAsync(token);

                var root = JsonConvert.DeserializeObject<Root<Vehicle>>(jsonSerialized);

                results = root.Results;
            }
            catch (Exception ex)
            {

                throw new ApplicationException($"Error fetching response from {fullPath}", ex.InnerException);
            }

            return results;
        }

        public async Task<Vehicle> GetAsync(string id, CancellationToken token = default)
        {
            var fullPath = _httpClient.BaseAddress + _path + id.ToString();

            var response = await _httpClient.GetAsync(fullPath, token);

            Vehicle getVehicle = new Vehicle();

            try
            {
                response.EnsureSuccessStatusCode();

                var jsonSerialized = await response.Content.ReadAsStringAsync(token);

                var root = JsonConvert.DeserializeObject<Root<Vehicle>>(jsonSerialized);

                var result = root.Result;

                getVehicle = result.Properties;

                getVehicle.Uid = result.Uid;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error fetching response from {fullPath}", ex.InnerException);
            }

            return getVehicle;
        }

        public async Task<DataGridInfo> GetDataGridInfoAsync(string? getNewPagedetails = null, CancellationToken token = default)
        {
            string fullPath = string.Empty;

            fullPath = getNewPagedetails is not null ? getNewPagedetails : _httpClient.BaseAddress + _path;

            var results = new List<Result<Vehicle>>();

            var dataGridInfo = new DataGridInfo();

            try
            {
                var response = await _httpClient.GetAsync(fullPath, token);

                response.EnsureSuccessStatusCode();

                var jsonSerialized = await response.Content.ReadAsStringAsync(token);

                var root = JsonConvert.DeserializeObject<Root<Vehicle>>(jsonSerialized);

                dataGridInfo.total_records = root.total_records;

                dataGridInfo.total_pages = root.total_pages;

                dataGridInfo.next = root.next;

                dataGridInfo.previous = root.previous;
            }
            catch (Exception ex)
            {

                throw new ApplicationException($"Error fetching response from {fullPath}", ex.InnerException);
            }

            return dataGridInfo;
        }
    }
}
