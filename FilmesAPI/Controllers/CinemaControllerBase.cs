using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    public class CinemaControllerBase
    {

        [HttpPost]
        public IActionResult AddCinema([FromBody] CreateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);
            _movieContext.Cinema.Add(cinema);
        }
    }
}