using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWebApplication.Data;
using APIWebApplication.DTO.Response;
using APIWebApplication.DTO.Request;
using APIWebApplication.Models;
using APIWebApplication.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class MuseumAreaService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public MuseumAreaService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MuseumAreaResponse>> GetAllAsync()
    {
        var values = await _context.MuseumAreas.ToListAsync();



        return _mapper.Map<List<MuseumAreaResponse>>(values);
    }


    public async Task<MuseumAreaResponse> GetByIdAsync(int id)
    {
        var entity = await _context.MuseumAreas.FindAsync(id);
        if (entity == null) return null;

        return _mapper.Map<MuseumAreaResponse>(entity);
    }

    public async Task<MuseumAreaResponse> CreatAsync(CreateMuseumAreaRequest model)
    {
        var mapped = _mapper.Map<MuseumArea>(model);
        _context.MuseumAreas.Add(mapped);
        await _context.SaveChangesAsync();

        return _mapper.Map<MuseumAreaResponse>(mapped);

    }

    public async Task<DeletResponse> DeletAsync(int id)
    {
        var entity = await _context.MuseumAreas.FindAsync(id);
        if (entity == null) return null;
        
        _context.MuseumAreas.Remove(entity);

        return new DeletResponse { Id = id };

    }

    public async Task<MuseumAreaResponse> UpdateAsync(int id,UpdateMuseumAreaRequest model)
    {
        var entity = await _context.MuseumAreas.FindAsync(id);
        if (entity == null) return null;
        
        _mapper.Map(model, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<MuseumAreaResponse>(entity);
        
    }

}
