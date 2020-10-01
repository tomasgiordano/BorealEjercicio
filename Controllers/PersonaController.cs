using BorealEjercicio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BorealEjercicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private static Persona persona1 = new Persona();
        private static List<Persona> listaPersonas = new List<Persona>{new Persona(),new Persona{Id = 2,Name = "Carlos"}};

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(listaPersonas);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int Id)
        {
            return Ok(listaPersonas.FirstOrDefault(c => c.Id == Id));
        }

        [HttpPost]
        public IActionResult addPersona(Persona newPersona)
        {
            listaPersonas.Add(newPersona);
            return Ok(listaPersonas);
        }

        [HttpDelete("{id}")]
        public IActionResult deletePersona(int Id)
        {
            Persona aux = new Persona();
            for(int i=0;i<listaPersonas.Count;i++)
            {
                if(listaPersonas[i].Id==Id)
                {
                    aux=listaPersonas[i];
                    listaPersonas.Remove(listaPersonas[i]);
                    return Ok(aux.Name+" "+aux.Surname+" eliminado.");
                }
            }
            return Ok("No existe la pesona con id: "+Id);
        }
    }
}