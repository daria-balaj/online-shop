// using API.Data;
// using API.Services;
// using Microsoft.Extensions.Configuration;
// using API.DTOs;
// using API.Models;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using AutoMapper;
// using System.Security.Claims;
// using Microsoft.IdentityModel;
// using Microsoft.IdentityModel.JsonWebTokens;
// using Microsoft.IdentityModel.Tokens;
// using Microsoft.EntityFrameworkCore;
// using System.Security.Cryptography;

// using Moq;

// namespace Tests;

// public class AuthServiceTests
// {
//     private readonly AuthService _sut;
//     private readonly Mock<DataContext> _context = new Mock<DataContext>();
//     private readonly Mock<IConfiguration> _config = new Mock<IConfiguration>();
//     private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

//     public AuthServiceTests()
//     {
//         _sut = new AuthService(_config.Object, _context.Object, _mapper.Object);
//     }

//     [Fact]
//     public void RegisterAsyncValidInput()
//     {
//         //Arrange
//         // var dto = new RegisterDTO {

//         // }
//         //Act
//         //_sut.RegisterAsync();
//         //Assert

//     }
// }

