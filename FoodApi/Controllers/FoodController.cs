using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApi.Helpers;
using FoodApi.Manager;
using Library;
using Library.DataAccess;
using Library.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodApi.Controllers
{
    [Route("api/[controller]")]
    public class FoodController : Controller
    {
        FoodManager foodManager = new FoodManager();
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;


        // comments changes 
        public static IWebHostEnvironment _environment;
        public FoodController(IWebHostEnvironment environment, IUserRepository repository, JwtService jwtService)
        {
            _environment = environment;
            _repository = repository;
            _jwtService = jwtService;
        }

        public class FileUploadAPI
        {
            public IFormFile files { get; set; }
        }

        [HttpPost("addfood")]
        public IActionResult AddFood(AddFood dto)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                History food = new History
                {
                    foodName = dto.foodName,
                    calories = dto.calories,
                    UserId = userId
                };

                return Created("success", _repository.AddFood(food));
            }
            catch (Exception)
            {
                return Unauthorized();
            }

        }

        [HttpPost]
        public Results Post([FromForm] FileUploadAPI objFile)
        {
            return foodManager.GetFood(objFile);

        }
        [HttpPost("imgid")]
        public History GetCal([FromForm] int id)
        {
            return foodManager.GetCal(id);

        }

        [HttpPost("id")]
        public Root GetNut([FromForm] int id)
        {
            return foodManager.GetRecipe(id);

        }
        [HttpPost("op")]
        public List<Result> GetOp([FromForm] string name)
        {
            return foodManager.GetOp(name).results;

        }
    }
}

