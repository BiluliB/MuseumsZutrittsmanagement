using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWebApplication.Data;
using APIWebApplication.DTO;
using Microsoft.EntityFrameworkCore;

public class MuseumAreaService
{
    private readonly AppDbContext _context;

    public MuseumAreaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<MuseumAreaDTO>> GetAllMuseumAreasAsync()
    {
        var museumAreas = await _context.MuseumAreas.ToListAsync();

        var museumAreaDTOs = museumAreas.Select(m => new MuseumAreaDTO
        {
            ID = m.ID,
            AreaName = m.AreaName,
            AreaDescription = m.AreaDescription,
            AreaLocation = m.AreaLocation,
            AccessRules = m.AccessRules
        }).ToList();

        return museumAreaDTOs;
    }
}
