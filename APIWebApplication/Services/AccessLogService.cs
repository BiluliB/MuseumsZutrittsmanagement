using APIWebApplication.Data;
using APIWebApplication.DTO.Response;
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

        public async Task<List<AccessLogDTO>> GetAllAsync()
        {
            var accessLog = await _context.AccessLog.ToListAsync();



            return _mapper.Map<List<AccessLogDTO>>(accessLog);
        }
    }
}
