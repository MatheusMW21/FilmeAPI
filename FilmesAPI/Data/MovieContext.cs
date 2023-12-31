﻿using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions <MovieContext> opts)
        : base(opts)
    {
        
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Adress> Adresses { get; set; }
}
