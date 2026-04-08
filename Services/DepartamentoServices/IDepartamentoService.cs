using static MudBlazor.CategoryTypes;
using PaginaWebCoperex.Models;

namespace PaginaWebCoperex.Services.DepartamentoServices
{
    public interface IDepartamentoService
    {

        Task<bool> AddUpdateAsync(DepartamentoTrabajo departamento);
        Task<bool> DeleteAsync(int departamento);
        Task<List<DepartamentoTrabajo>> GetAllAsync();
        Task<DepartamentoTrabajo> GetByIdAsync(int id_departamento);

        Task<MPaginatedResult<DepartamentoTrabajo>> GetPaginatedAsync(int pageNumber, int pageSize, string searchTerm = "", bool sortAscending = true);
    }
}
