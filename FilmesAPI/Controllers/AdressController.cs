using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class AdressController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public AdressController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IEnumerable<ReadAdressDTO> GetAdress()
    {
        return _mapper.Map<List<ReadAdressDTO>>(_context.Adresses);
    }

    [HttpGet("{id}")]
    public IActionResult GetAdressById(int id) 
    {
        Adress adress = _context.Adresses.FirstOrDefault(adress => adress.Id == id);

        if (adress != null ) 
        {
            ReadAdressDTO readAdressDTO = _mapper.Map<ReadAdressDTO>(adress);

            return Ok(readAdressDTO);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAdress(int id, [FromBody] UpdateAdressDTO updateAdressDTO)
    {
        Adress adress = _context.Adresses.FirstOrDefault(adress => adress.Id == id);

        if (adress != null)
        {
            return NotFound();
        }
        _mapper.Map(updateAdressDTO, adress);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeleteAdress(int id)
    {
        Adress adress = _context.Adresses.FirstOrDefault(adress =>adress.Id == id);
        if(adress != null )
        {
            return NotFound();
        }
        _context.Remove(adress);
        _context.SaveChanges();
        return NoContent();
    }

}
