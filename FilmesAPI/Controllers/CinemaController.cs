﻿using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class CinemaController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public CinemaController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddCinema([FromBody] CreateCinemaDTO cinemaDTO)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCinemaById), new { Id = cinema.Id }, cinemaDTO);

    }

    [HttpGet]
    public IEnumerable<ReadCinemaDTO> GetCinemas()
    {
        return _mapper.Map<List<ReadCinemaDTO>>(_context.Cinemas.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetCinemaById(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema != null)
        {
            ReadCinemaDTO cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);
            return Ok(cinemaDTO);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCinema(int id, [FromBody] UpdateMovieDTO cinemaDTO)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema != null)
        {
            return NotFound();
        }
        _mapper.Map(cinemaDTO, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCinema(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        
        if (cinema != null)
        {
            return NotFound();
        }
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}

