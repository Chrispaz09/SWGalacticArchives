using SWGalacticArchives.Models;

namespace SWGalacticArchives.Services.Interfaces
{
    public interface IAPIService<T>
    {
        /// <summary>
        /// Gets the entity by Id.
        /// </summary>
        /// <param name="id">Entity Id.</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public Task<T> GetAsync(string id, CancellationToken token = default);

        /// <summary>
        /// Gets all entitys from Api.
        /// </summary>
        /// <param name="getPageItems">Route to retreive a specific set of items from the api based on the URL. </param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public Task<IEnumerable<Result<T>>> GetAllResultsAsync(string? getPageItems = null, CancellationToken token = default);

        /// <summary>
        /// Gets information pertaining to data grids. EX. Total items, Previous page, next page, etc.
        /// </summary>
        /// <param name="getNewPagedetails">Route to retreive a specific set of items from the api based on the URL</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public Task<DataGridInfo> GetDataGridInfoAsync(string? getNewPagedetails = null, CancellationToken token = default);
    }
}
