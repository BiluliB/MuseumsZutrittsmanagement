using APIWebApplication.Data;
using APIWebApplication.DTO.Request;
using APIWebApplication.DTO.Response;
using APIWebApplication.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIWebApplication.Services
{
    public class VisitorCapacityService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the VisitorCapacityService class with the specified database context and mapper.
        /// </summary>
        /// <param name="context">The database context for accessing data.</param>
        /// <param name="mapper">The mapper for converting between DTOs and entities.</param>
        public VisitorCapacityService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        /// <summary>
        /// Retrieves a list of visitor capacities asynchronously.
        /// </summary>
        /// <returns>A list of visitor capacities as response DTOs.</returns>
        public async Task<List<VisitorCapacityResponse>> GetAllAsync()
        {
            var visitorCapacity = await _context.VisitorCapacities.ToListAsync();

            

            return _mapper.Map<List<VisitorCapacityResponse>>(visitorCapacity);
        }

        /// <summary>
        /// Retrieves a visitor capacity by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the visitor capacity to retrieve.</param>
        /// <returns>A visitor capacity as a response DTO, or null if not found.</returns>
        public async Task<VisitorCapacityResponse> GetByIdAsync(int id)
        {
            var entity = await _context.VisitorCapacities.FindAsync(id);
            if (entity == null) return null;

            return _mapper.Map<VisitorCapacityResponse>(entity);
        }

        /// <summary>
        /// Creates a new visitor capacity entry asynchronously.
        /// </summary>
        /// <param name="model">The request DTO containing visitor capacity data.</param>
        /// <returns>The newly created visitor capacity as a response DTO.</returns>
        public async Task<VisitorCapacityResponse> CreatAsync(CreateVisitorCapacityRequest model)
        {
            var mapped = _mapper.Map<VisitorCapacity>(model);
            _context.VisitorCapacities.Add(mapped);
            await _context.SaveChangesAsync();

            return _mapper.Map<VisitorCapacityResponse>(mapped);

        }

        /// <summary>
        /// Deletes a visitor capacity entry by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the visitor capacity to delete.</param>
        /// <returns>A response DTO indicating the result of the deletion.</returns>
        public async Task<DeletResponse> DeletAsync(int id)
        {
            var entity = await _context.VisitorCapacities.FindAsync(id);
            if (entity == null) return null;

            _context.VisitorCapacities.Remove(entity);
            await _context.SaveChangesAsync();

            return new DeletResponse { Id = id };

        }

        /// <summary>
        /// Updates a visitor capacity entry asynchronously.
        /// </summary>
        /// <param name="id">The ID of the visitor capacity to update.</param>
        /// <param name="model">The request DTO containing updated visitor capacity data.</param>
        /// <returns>The updated visitor capacity as a response DTO, or null if not found.</returns>
        public async Task<VisitorCapacityResponse> UpdateAsync(int id, UpdateVisitorCapacityRequest model)
        {
            var entity = await _context.VisitorCapacities.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(model, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<VisitorCapacityResponse>(entity as VisitorCapacity);

        }
    }
}
