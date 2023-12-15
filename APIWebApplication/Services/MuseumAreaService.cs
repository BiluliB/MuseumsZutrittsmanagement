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

    /// <summary>
    /// Retrieves a list of museum areas asynchronously.
    /// </summary>
    /// <returns>A list of museum areas as response DTOs.</returns>
    public async Task<List<MuseumAreaResponse>> GetAllAsync()
    {
        var values = await _context.MuseumAreas.ToListAsync();

        return _mapper.Map<List<MuseumAreaResponse>>(values);
    }

    /// <summary>
    /// Retrieves a museum area by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the museum area to retrieve.</param>
    /// <returns>A museum area as a response DTO, or null if not found.</returns>
    public async Task<MuseumAreaResponse> GetByIdAsync(int id)
    {
        var entity = await _context.MuseumAreas.FindAsync(id);
        if (entity == null) return null;

        return _mapper.Map<MuseumAreaResponse>(entity);
    }

    /// <summary>
    /// Creates a new museum area asynchronously.
    /// </summary>
    /// <param name="model">The request DTO containing museum area data.</param>
    /// <returns>The newly created museum area as a response DTO.</returns>
    public async Task<MuseumAreaResponse> CreatAsync(CreateMuseumAreaRequest model)
    {
        var mapped = _mapper.Map<MuseumArea>(model);
        _context.MuseumAreas.Add(mapped);
        await _context.SaveChangesAsync();

        return _mapper.Map<MuseumAreaResponse>(mapped);
    }

    /// <summary>
    /// Deletes a museum area by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the museum area to delete.</param>
    /// <returns>A response DTO indicating the result of the deletion.</returns>
    public async Task<DeletResponse> DeletAsync(int id)
    {
        var entity = await _context.MuseumAreas.FindAsync(id);
        if (entity == null) return null;
        
        _context.MuseumAreas.Remove(entity);
        await _context.SaveChangesAsync();

        return new DeletResponse { Id = id };
    }

    /// <summary>
    /// Updates a museum area asynchronously.
    /// </summary>
    /// <param name="id">The ID of the museum area to update.</param>
    /// <param name="model">The request DTO containing updated museum area data.</param>
    /// <returns>The updated museum area as a response DTO, or null if not found.</returns>
    public async Task<MuseumAreaResponse> UpdateAsync(int id,UpdateMuseumAreaRequest model)
    {
        var entity = await _context.MuseumAreas.FindAsync(id);
        if (entity == null) return null;
        
        _mapper.Map(model, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<MuseumAreaResponse>(entity);        
    }

}
