using APIWebApplication.Data;
using APIWebApplication.DTO.Request;
using APIWebApplication.DTO.Response;
using APIWebApplication.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIWebApplication.Services
{
    public class AccessLogService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AccessLogService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<List<AccessLogResponse>> GetAllAsync()
        {
            var accessLog = await _context.AccessLogs.ToListAsync();



            return _mapper.Map<List<AccessLogResponse>>(accessLog);
        }

        public async Task<AccessLogResponse> GetByIdAsync(int id)
        {
            var entity = await _context.AccessLogs.FindAsync(id);
            if (entity == null) return null;

            return _mapper.Map<AccessLogResponse>(entity);
        }

        public async Task<AccessLogResponse> CreatAsync(CreateAccessLogRequest model)
        {
            var mapped = _mapper.Map<AccessLog>(model);
            _context.AccessLogs.Add(mapped);
            await _context.SaveChangesAsync();

            return _mapper.Map<AccessLogResponse>(mapped);

        }

        public async Task<DeletResponse> DeletAsync(int id)
        {
            var entity = await _context.AccessLogs.FindAsync(id);
            if (entity == null) return null;

            _context.AccessLogs.Remove(entity);
            await _context.SaveChangesAsync();

            return new DeletResponse { Id = id };

        }

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
