using AutoMapper;
using API.Models;
using API.DTOs;

public class AutoMapperProfile : Profile 
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterDTO, User>();
    }
}