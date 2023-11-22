using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class AdressProfile : Profile
{
    public AdressProfile()
    {
        CreateMap<CreateAdressDTO, Adress>();
        CreateMap<Adress, ReadAdressDTO>();
        CreateMap<UpdateAdressDTO, Adress>();
    }
}
