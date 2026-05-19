using Apbd_Task_CodeFirst.DAL;
using Apbd_Task_CodeFirst.Models;
using Apbd_Task_CodeFirst.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Apbd_Task_CodeFirst.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PCsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public PCsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetComponentsAsync(int id, CancellationToken cancellationToken)
    {
        var component = await _dbContext.PCComponents
            .AsNoTracking()
            .Where(e => e.PcId == id)
            .Select(e => new
            {
                Id = e.PcId,
                Code = e.ComponentCode,
                Description = e.Component.Description,
                Amount = e.Amount
            })
            .ToListAsync(cancellationToken);
        if (component.IsNullOrEmpty())
            return NotFound();

        return Ok(component);
    }

    [HttpGet]
    public async Task<IActionResult> GetComputersAsync(CancellationToken cancellationToken)
    {
        var component = await _dbContext.PCs
            .AsNoTracking()
            .Select(e => new
            {
                e.Id,
                e.Name,
                e.Weight,
                e.Warranty,
                e.CreatedAt,
                e.Stock
            })
            .ToListAsync(cancellationToken);
        if (component.IsNullOrEmpty())
            return NotFound();

        return Ok(component);
    }

    [HttpPost]
    public async Task<IActionResult> PostPcAsync(CreatePCRequest pc, CancellationToken cancellationToken)
    {
        var newPc = new PCs()
        {
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };

        await _dbContext.PCs.AddAsync(newPc, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(new
        {
            newPc.Id,
            newPc.Name,
            newPc.Weight,
            newPc.Warranty,
            newPc.CreatedAt,
            newPc.Stock
        });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutPcAsync(int id, PutPCRequest requestPc, CancellationToken cancellationToken)
    {
        var pc =  await _dbContext.PCs.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (pc == null)
            return NotFound();
        
        pc.Name = requestPc.Name;
        pc.Weight = requestPc.Weight;
        pc.Warranty = requestPc.Warranty;
        pc.CreatedAt = requestPc.CreatedAt;
        pc.Stock = requestPc.Stock;
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteByIdAsync(int id, CancellationToken cancellationToken)
    {
        var pc = await _dbContext.PCs.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (pc == null)
        {
            return NotFound();
        }
        
        _dbContext.PCs.Remove(pc);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}