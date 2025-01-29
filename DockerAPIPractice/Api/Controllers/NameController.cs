using DockerAPIPractice.Data;
using DockerAPIPractice.Model;
using Microsoft.AspNetCore.Mvc;

namespace DockerAPIPractice.Controllers;

[ApiController]
[Route("[controller]")]
public class NameController : ControllerBase
{
    private readonly NameDbContext _nameDbContext;

    public NameController(NameDbContext nameDbContext)
    {
        _nameDbContext = nameDbContext;
    }

    [HttpGet]
    public ActionResult<List<Names>> GetNamesAsync()
    {
        var names = _nameDbContext.Names.ToList();
        return Ok(names);
    }

    [HttpPost]
    public async Task<ActionResult<Names>> NewName([FromBody] Names newName)
    {
        if (newName == null)
        {
            return BadRequest("Name cant be null");
        }

        _nameDbContext.Names.Add(newName);
        await _nameDbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(NewName), new { id = newName.Id }, newName);
    }
}