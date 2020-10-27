using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SetupConnectController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;

    public SetupConnectController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET api/SetupConnect
    [HttpGet]
    public async Task<ActionResult<List<DM_NhomHangHoa>>> Get()
    {
      return await _dbContext.DM_NhomHangHoa.Select(x=> new DM_NhomHangHoa{ID= x.ID, TenNhomHangHoa= x.TenNhomHangHoa})
      .ToListAsync();
      // return await _dbContext.DM_NhomHangHoa.ToListAsync();
    }
 
    // GET api/SetupConnect/id
    [HttpGet("{id}")]
    public async Task<ActionResult<DM_NhomHangHoa>> Get(Guid id)
    {
      return await _dbContext.DM_NhomHangHoa.FindAsync(id);
    }   
  }
}