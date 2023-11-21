using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class MovieController : ControllerBase
{

    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDTO movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetMovies([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return (IEnumerable<Movie>)_mapper.Map<List<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();
        var movieDTO = _mapper.Map<ReadMovieDTO>(movie);
        return Ok(movieDTO);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO movieDTO)
    {
        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id);
        if (movie == null) return NotFound();
        _mapper.Map(movieDTO, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateMoviePacth(int id, [FromBody] UpdateMovieDTO movieDTO)
    {
        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id);
        if (movie == null) return NotFound();
        _mapper.Map(movieDTO, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null) return NotFound();
        _context.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }
}