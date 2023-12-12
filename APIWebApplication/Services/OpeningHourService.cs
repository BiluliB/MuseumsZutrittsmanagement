using APIWebApplication.Data;
using APIWebApplication.Models;
using APIWebApplication.DTO.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIWebApplication.Services
{
    public class OpeningHourService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OpeningHourService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<List<OpeningHourDTO>> GetAllAsync()
        {
            var openingHour = await _context.OpeningHour.ToListAsync();



            return _mapper.Map<List<OpeningHourDTO>>(openingHour);
        }
    }
}
