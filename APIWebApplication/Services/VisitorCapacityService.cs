using APIWebApplication.Data;
using APIWebApplication.DTO;
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

        public VisitorCapacityService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<List<AccessLogDTO>> GetAllAsync()
        {
            var visitorCapacity = await _context.VisitorCapacity.ToListAsync();

            

            return _mapper.Map<List<AccessLogDTO>>(visitorCapacity);
        }
    }
}
