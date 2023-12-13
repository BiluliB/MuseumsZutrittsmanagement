using APIWebApplication.Data;
using APIWebApplication.DTO;
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

        public VisitorCapacityService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<List<VisitorCapacityResponse>> GetAllAsync()
        {
            var visitorCapacity = await _context.VisitorCapacities.ToListAsync();

            

            return _mapper.Map<List<VisitorCapacityResponse>>(visitorCapacity);
        }
        public async Task<VisitorCapacityResponse> GetByIdAsync(int id)
        {
            var entity = await _context.VisitorCapacities.FindAsync(id);
            if (entity == null) return null;

            return _mapper.Map<VisitorCapacityResponse>(entity);
        }

        public async Task<VisitorCapacityResponse> CreatAsync(CreateVisitorCapacityRequest model)
        {
            var mapped = _mapper.Map<VisitorCapacity>(model);
            _context.VisitorCapacities.Add(mapped);
            await _context.SaveChangesAsync();

            return _mapper.Map<VisitorCapacityResponse>(mapped);

        }

        public async Task<DeletResponse> DeletAsync(int id)
        {
            var entity = await _context.VisitorCapacities.FindAsync(id);
            if (entity == null) return null;

            _context.VisitorCapacities.Remove(entity);

            return new DeletResponse { Id = id };

        }

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
