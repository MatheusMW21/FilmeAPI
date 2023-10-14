﻿using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class FilmeController : ControllerBase
{
 
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public void AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Genero);
        Console.WriteLine(filme.AnoLancamento);
        Console.WriteLine(filme.Duracao);
        Console.WriteLine(filme.Diretor);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes()
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public Filme? RecuperaId(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }

    [HttpDelete]
    public void DeletaFilme([FromBody] Filme filme)
    {
        filmes.Remove(filme);
    }
}
