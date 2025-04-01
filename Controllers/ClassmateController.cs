using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using workflow_kubernetes.Models;

namespace workflow_kubernetes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassmateController : ControllerBase
    {
        private List<Classmate> classMatesList = new List<Classmate> {
            new Classmate(1, "Daniel", "Mansur", 21, "Necesita lentes para ver"),
            new Classmate(2, "Alondra", "🌻", 26, "Antes estudiaba medicina"),
            new Classmate(3, "Samuel", "Flores", 20, "Tiene el pelo rojo"),
            new Classmate(4, "Javier", "Tamez", 19, "Se distrae mucho en la chamba")
        };

        // GET api/classmate/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var classmate = this.classMatesList.FirstOrDefault(c => c.ClassmateId == id);

                if (classmate == null)
                {
                    return NotFound($"Classmate with ID {id} not found.");
                }

                return Ok(classmate);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // GET api/classmate
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.classMatesList);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // POST api/classmate
        [HttpPost]
        public IActionResult Post([FromBody] Classmate classmate)
        {
            try
            {
                if (classmate == null)
                {
                    return BadRequest("Classmate data is null.");
                }

                // Add the new classmate to the list
                this.classMatesList.Add(classmate);

                // Return 201 Created with a location to the new resource
                return CreatedAtAction(nameof(Get), new { id = classmate.ClassmateId }, classmate);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // PUT api/classmate/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Classmate classmate)
        {
            try
            {
                var existingClassmate = this.classMatesList.FirstOrDefault(c => c.ClassmateId == id);

                if (existingClassmate == null)
                {
                    return NotFound($"Classmate with ID {id} not found.");
                }

                // Update the classmate properties
                existingClassmate.Name = classmate.Name;
                existingClassmate.LastName = classmate.LastName;
                existingClassmate.Age = classmate.Age;
                existingClassmate.Description = classmate.Description;

                return NoContent(); // 204 No Content for successful update
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // DELETE api/classmate/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var classmate = this.classMatesList.FirstOrDefault(c => c.ClassmateId == id);

                if (classmate == null)
                {
                    return NotFound($"Classmate with ID {id} not found.");
                }

                this.classMatesList.Remove(classmate);

                return NoContent(); // 204 No Content for successful deletion
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
