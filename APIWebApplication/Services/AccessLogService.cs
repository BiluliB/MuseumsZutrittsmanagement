using APIWebApplication.Data;
using APIWebApplication.DTO.Request;
using APIWebApplication.DTO.Response;
using APIWebApplication.Interfaces;
using APIWebApplication.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIWebApplication.Services
{
    /// <summary>
    /// Service class for managing access log-related operations.
    /// </summary>
    public class AccessLogService : IAccessLogService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AccessLogService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        /// <summary>
        /// Retrieves a list of access logs asynchronously.
        /// </summary>
        /// <returns>A list of access logs as response DTOs.</returns>
        public async Task<List<AccessLogResponse>> GetAllAsync()
        {
            var accessLog = await _context.AccessLogs.ToListAsync();

            return _mapper.Map<List<AccessLogResponse>>(accessLog);
        }

        /// <summary>
        /// Retrieves an access log by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the access log to retrieve.</param>
        /// <returns>An access log as a response DTO, or null if not found.</returns>
        public async Task<AccessLogResponse> GetByIdAsync(int id)
        {
            var entity = await _context.AccessLogs.FindAsync(id);
            if (entity == null) return null;

            return _mapper.Map<AccessLogResponse>(entity);
        }

        /// <summary>
        /// Creates a new access log entry asynchronously.
        /// </summary>
        /// <param name="model">The request DTO containing access log data.</param>
        /// <returns>The newly created access log as a response DTO.</returns>
        public async Task<AccessLogResponse> CreatAsync(CreateAccessLogRequest model)
        {
            var mapped = _mapper.Map<AccessLog>(model);
            _context.AccessLogs.Add(mapped);
            await _context.SaveChangesAsync();

            return _mapper.Map<AccessLogResponse>(mapped);

        }

        /// <summary>
        /// Deletes an access log entry by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the access log to delete.</param>
        /// <returns>A response DTO indicating the result of the deletion.</returns>
        public async Task<DeletResponse> DeletAsync(int id)
        {
            var entity = await _context.AccessLogs.FindAsync(id);
            if (entity == null) return null;

            _context.AccessLogs.Remove(entity);
            await _context.SaveChangesAsync();

            return new DeletResponse { Id = id };

        }

        /// <summary>
        /// Updates an access log entry asynchronously.
        /// </summary>
        /// <param name="id">The ID of the access log to update.</param>
        /// <param name="model">The request DTO containing updated access log data.</param>
        /// <returns>The updated access log as a response DTO, or null if not found.</returns>
        public async Task<AccessLogResponse> UpdateAsync(int id, UpdateAccessLogRequest model)
        {
            var entity = await _context.AccessLogs.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(model, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<AccessLogResponse>(entity);

        }
    }
}
