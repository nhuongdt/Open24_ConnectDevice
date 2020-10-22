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

    // GET api/DM_NhomHangHoa
    [HttpGet]
    public async Task<ActionResult<List<DM_NhomHangHoa>>> GetAll()
    {
      return await _dbContext.DM_NhomHangHoa.ToListAsync();
    }

    // GET api/DM_NhomHangHoa/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DM_NhomHangHoa>> Get(string id)
    {
      return await _dbContext.DM_NhomHangHoa.FindAsync(id);
    }   
  }
}