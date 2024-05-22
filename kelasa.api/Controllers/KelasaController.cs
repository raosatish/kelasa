using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace kelasa.api.Controllers;

[ApiController]
[Route("[controller]")]
public class KelasaController : ControllerBase
{

    private readonly ILogger<KelasaController> _logger;
    private readonly IKelasaRepository _repo;

    public KelasaController(ILogger<KelasaController> logger, IKelasaRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Kelasa>>  Get(string id)
    {
        return await _repo.GetKelasa(id);
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<Kelasa>>> GetAll(){
        return  Ok(await _repo.GetAllKelasa());
    }

    [HttpPost]
    public async Task<ActionResult<Kelasa>> Create(Kelasa newKelasa){
        var k = await _repo.Create(newKelasa);
        return Created("",k);
    }
}
