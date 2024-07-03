using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomNumberController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRandomNumber()
        {
            return Ok(
                new { 
                    number = new Random().Next(10)
                }
            );
        }

        [HttpGet]
        [Route("dayOfWeek")]
        public IActionResult GetRandomNumberDayOfWeek()
        {
            int dayOfWeek = new Random().Next(1, 8);

            return Ok( 
                new
                {
                    dayNumber = dayOfWeek,
                    dayName = GetDayStrByNumber(dayOfWeek)
                }
            );
        }

        [HttpGet]
        [Route("dayOfWeek/{numberDay}")]
        public IActionResult GetDayOfWeekAccordingNumber(int numberDay)
        {
            if (numberDay < 1)
                return BadRequest("El numero de dia debe ser mayor o igual a 1");
            if (numberDay > 7)
                return BadRequest("El numero de dia debe ser igual o menos a 7"); 

            return Ok($"El dia numero { numberDay } corresponde al dia { GetDayStrByNumber(numberDay) }");
        }

        public static string GetDayStrByNumber(int numberDay)
        {
            return numberDay switch
            {
                1 => "Lunes",
                2 => "Martes",
                3 => "Miercoles",
                4 => "Jueves",
                5 => "Viernes",
                6 => "Sabado",
                7 => "Domingo",
                _ => "No valido",
            };
        }
    }
}
