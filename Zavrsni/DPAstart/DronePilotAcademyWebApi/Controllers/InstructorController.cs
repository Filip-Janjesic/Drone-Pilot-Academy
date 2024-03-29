﻿using DronePilotAcademyWebApi.Data;
using DronePilotAcademyWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DronePilotAcademyWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class InstructorController : ControllerBase
    {
        private readonly Context _context;

        public InstructorController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var instructors = _context.Instructor.ToList();
                if (instructors == null || instructors.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.Instructor.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                        ex.Message);
            }

        }

        [HttpGet]
        [Route("{ID:int}")]
        public IActionResult GetByID(int ID)
        {

            if (ID <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var i = _context.Instructor.Find(ID);

                if (i == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, i);
                }

                return new JsonResult(i);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post(Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Instructor.Add(instructor);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, instructor);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                   ex.Message);
            }
   }

        [Route("{ID:int}")]

        public IActionResult Put(int ID, Instructor instructor)
        {

            if (ID <= 0 || instructor == null)
            {
                return BadRequest();
            }
            try
            {
                var instructorBase = _context.Instructor.Find(ID);
                if (instructorBase == null)
                {
                    return BadRequest();
                }
       
                instructorBase.FIRST_NAME = instructor.FIRST_NAME;
                instructorBase.LAST_NAME = instructor.LAST_NAME;
                instructorBase.PILOT_LICENSE_NUMBER = instructor.PILOT_LICENSE_NUMBER;
                instructorBase.EMAIL = instructor.EMAIL;
                instructorBase.CONTACT_NUMBER = instructor.CONTACT_NUMBER;

                _context.Instructor.Update(instructorBase);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, instructorBase);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  ex);
            }
        }

        [HttpDelete]
        [Route("{ID:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int ID)
        {
            if (ID <= 0)
            {
                return BadRequest();
            }

            var instructorBase = _context.Instructor.Find(ID);
            if (instructorBase == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Instructor.Remove(instructorBase);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Deleted\"}");

            }
            catch (Exception )
            {

                return new JsonResult("{\"poruka\":\"Can not be deleted\"}");

            }
        }


    }
}



        
    

