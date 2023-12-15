using APIWebApplication.Data;
using APIWebApplication.Models;
using APIWebApplication.DTO.Response;
using APIWebApplication.DTO.Request;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIWebApplication.Services
{
    public class OpeningHourService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the OpeningHourService class with the specified database context and mapper.
        /// </summary>
        /// <param name="context">The database context for accessing data.</param>
        /// <param name="mapper">The mapper for converting between DTOs and entities.</param>
        public OpeningHourService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        /// <summary>
        /// Retrieves a list of opening hours asynchronously.
        /// </summary>
        /// <returns>A list of opening hours as response DTOs.</returns>
        public Task<List<OpeningHourResponse>> GetAllAsync()
        {
            var openingHour = await _context.OpeningHours.ToListAsync();



            return _mapper.Map<List<OpeningHourResponse>>(openingHour);
        }

        /// <summary>
        /// Retrieves an opening hour by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the opening hour to retrieve.</param>
        /// <returns>An opening hour as a response DTO, or null if not found.</returns>
        public async Task<OpeningHourResponse> GetByIdAsync(int id)
        {
            var entity = await _context.OpeningHours.FindAsync(id);
            if (entity == null) return null;

            return _mapper.Map<OpeningHourResponse>(entity);
        }

        /// <summary>
        /// Creates a new opening hour entry asynchronously.
        /// </summary>
        /// <param name="model">The request DTO containing opening hour data.</param>
        /// <returns>The newly created opening hour as a response DTO.</returns>
        public async Task<OpeningHourResponse> CreatAsync(CreateOpeningHourRequest model)
        {
            var mapped = _mapper.Map<OpeningHour>(model);
            _context.OpeningHours.Add(mapped);
            await _context.SaveChangesAsync();

            return _mapper.Map<OpeningHourResponse>(mapped);

        }

        /// <summary>
        /// Deletes an opening hour entry by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the opening hour to delete.</param>
        /// <returns>A response DTO indicating the result of the deletion.</returns>
        public async Task<DeletResponse> DeletAsync(int id)
        {
            var entity = await _context.OpeningHours.FindAsync(id);
            if (entity == null) return null;

            _context.OpeningHours.Remove(entity);
            await _context.SaveChangesAsync();

            return new DeletResponse { Id = id };

        }

        /// <summary>
        /// Updates an opening hour entry asynchronously.
        /// </summary>
        /// <param name="id">The ID of the opening hour to update.</param>
        /// <param name="model">The request DTO containing updated opening hour data.</param>
        /// <returns>The updated opening hour as a response DTO, or null if not found.</returns>
        public async Task<OpeningHourResponse> UpdateAsync(int id, UpdateOpeningHourRequest model)
        {
            var entity = await _context.OpeningHours.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(model, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<OpeningHourResponse>(entity);

        }
    }
}
