using Microsoft.EntityFrameworkCore;
using PaginaWebCoperex.Models;
using static MudBlazor.CategoryTypes;

namespace PaginaWebCoperex.Services.DepartamentoServices
{
    public class DepartamentoService : IDepartamentoService
    {

        private readonly PaginaWebContext _PaginaWebDbContext;


        public DepartamentoService(PaginaWebContext PaginaWebDbContext)
        {

            _PaginaWebDbContext = PaginaWebDbContext;
            
        }

        public async Task<bool> AddUpdateAsync(DepartamentoTrabajo departamento)
        {
            if (departamento.DepartamentoId > 0)
            {
                // Buscar la feria existente en la base de datos
                var existingdepartamento = await _PaginaWebDbContext.DepartamentoTrabajo.FindAsync(departamento.DepartamentoId);

                if (existingdepartamento != null)
                {
                    // Actualizar las propiedades existentes

                    existingdepartamento.NombreDepartamento = departamento.NombreDepartamento;
                    existingdepartamento.Activo = true;

                    // Marcar el espacio como modificado
                    _PaginaWebDbContext.DepartamentoTrabajo.Update(existingdepartamento);
                }
                else
                {
                    return false; // Si no se encontró el espacio, devolver false
                }
            }
            else
            {
                // Si no hay ID, se trata de un nuevo espacio, agregarlo
                _PaginaWebDbContext.DepartamentoTrabajo.Add(departamento);
            }

            // Guardar los cambios en la base de datos
        await _PaginaWebDbContext.SaveChangesAsync();
            return true; // Retornar true si se ha agregado o actualizado correctamente
        }

        public async Task<bool> DeleteAsync(int departamento)
        {
            var estado = await _PaginaWebDbContext.DepartamentoTrabajo.FindAsync(departamento);
            if (estado != null)
            {

                _PaginaWebDbContext.DepartamentoTrabajo.Update(estado);
                await _PaginaWebDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<DepartamentoTrabajo>> GetAllAsync()
        {
            return await _PaginaWebDbContext.DepartamentoTrabajo
              .ToListAsync();
        }

        public async Task<DepartamentoTrabajo> GetByIdAsync(int id_departamento)
        {
            try
            {
                var result = await _PaginaWebDbContext.DepartamentoTrabajo
                    .FirstOrDefaultAsync(fa => fa.DepartamentoId == id_departamento);

                if (result == null)
                {
                    // Manejar el caso donde no se encontró el objeto
                    throw new KeyNotFoundException($"No se encontró el departamento de trabajo con ID {id_departamento}");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar el departamento", ex);
            }
        }

        public async Task<MPaginatedResult<DepartamentoTrabajo>> GetPaginatedAsync(int pageNumber, int pageSize, string searchTerm = "", bool sortAscending = true)
        {
            IQueryable<DepartamentoTrabajo> query = _PaginaWebDbContext.DepartamentoTrabajo;

            // Filtro por el término de búsqueda
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(fa => fa.NombreDepartamento != null && fa.NombreDepartamento.Contains(searchTerm));
            }

            // Ordenamiento
            query = sortAscending
                ? query.OrderBy(fa => fa.DepartamentoId).ThenBy(fa => fa.NombreDepartamento)
                : query.OrderByDescending(fa => fa.DepartamentoId).ThenByDescending(fa => fa.NombreDepartamento);

            var totalItems = await query.CountAsync();

            // Aplicar paginación
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new MPaginatedResult<DepartamentoTrabajo>
            {
                Items = items,
                TotalCount = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
