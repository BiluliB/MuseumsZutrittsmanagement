using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWebApplication.Data;
using APIWebApplication.DTO.Response;
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

    public async Task<List<MuseumAreaDTO>> GetAllAsync()
    {
        var museumAreas = await _context.MuseumAreas.ToListAsync();

        

        return _mapper.Map<List<MuseumAreaDTO>>(museumAreas);
    }
}
