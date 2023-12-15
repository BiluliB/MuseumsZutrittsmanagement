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

        public OpeningHourService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<List<OpeningHourResponse>> GetAllAsync()
        {
            var openingHour = await _context.OpeningHours.ToListAsync();



            return _mapper.Map<List<OpeningHourResponse>>(openingHour);
        }

        public async Task<OpeningHourResponse> GetByIdAsync(int id)
        {
            var entity = await _context.OpeningHours.FindAsync(id);
            if (entity == null) return null;

            return _mapper.Map<OpeningHourResponse>(entity);
        }

        public async Task<OpeningHourResponse> CreatAsync(CreateOpeningHourRequest model)
        {
            var mapped = _mapper.Map<OpeningHour>(model);
            _context.OpeningHours.Add(mapped);
            await _context.SaveChangesAsync();

            return _mapper.Map<OpeningHourResponse>(mapped);

        }

        public async Task<DeletResponse> DeletAsync(int id)
        {
            var entity = await _context.OpeningHours.FindAsync(id);
            if (entity == null) return null;

            _context.OpeningHours.Remove(entity);
            await _context.SaveChangesAsync();

            return new DeletResponse { Id = id };

        }

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
