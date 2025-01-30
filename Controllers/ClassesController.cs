using Microsoft.AspNetCore.Mvc;
using ABCIgnite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABCIgnite.Controllers
{
    [Route("api/classes")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private static List<ClassModel> classes = new List<ClassModel>();
        private static int nextClassId = 1;

        [HttpPost]
        public IActionResult CreateClass([FromBody] ClassModel classData)
        {
            if (classData == null)
                return BadRequest(new { error = "Class data is required." });

            if (string.IsNullOrEmpty(classData.Name))
                return BadRequest(new { error = "Class name is required." });

            if (classData.Capacity < 1)
                return BadRequest(new { error = "Capacity must be at least 1." });

            if (classData.EndDate <= DateTime.UtcNow)
                return BadRequest(new { error = "End date must be in the future." });

            classData.Id = nextClassId++;
            classes.Add(classData);

            return CreatedAtAction(nameof(CreateClass), new { id = classData.Id }, classData);
        }

        [HttpGet]
        public IActionResult GetClasses()
        {
            return Ok(classes);
        }
    }
}
