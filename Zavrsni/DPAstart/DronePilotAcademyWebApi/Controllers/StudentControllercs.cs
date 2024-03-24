using DronePilotAcademyWebApi.Data;
using DronePilotAcademyWebApi.Models;
using DronePilotAcademyWebApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DronePilotAcademyWebApi.Controllers
{
        [ApiController]
        [Route("api/v1/[controller]")]

        public class StudentController : ControllerBase
        {
            private readonly Context _context;

        private readonly ILogger<StudentController> _logger;
            public StudentController(Context context, ILogger<StudentController> logger) 
            {
                _context = context;
                _logger = logger;
            }

            [HttpGet]
            public IActionResult Get()
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var students = _context.Student.ToList();
                if (students == null || students.Count == 0)
                {
                    return new EmptyResult();
                }

                List<StudentDTO> back = new();

                students.ForEach(s =>
                {
                    var sDto = new StudentDTO();


                    back.Add(new StudentDTO
                    {
                        ID= s.ID,
                        FIRST_NAME= s.FIRST_NAME,
                        LAST_NAME= s.LAST_NAME,
                        ADDRESS= s.ADDRESS,
                        CONTACT_NUMBER=s.CONTACT_NUMBER,
                        DATE_OF_ENROLLMENT=s.DATE_OF_ENROLLMENT,

                    });
                       

                });

                return new JsonResult(back);

            }

        [HttpGet]
        [Route("{ID:int}")]
        public IActionResult GetByID(int ID)
        {

            if (ID <= 0)
            {
                return BadRequest(ModelState);
            }
            
           var s = _context.Student.Find(ID);

           if (s == null)
             {
               return StatusCode(StatusCodes.Status204NoContent, s);
             }
            try 
            {
                var DTO = new StudentDTO()

                {
                    ID = s.ID,
                    FIRST_NAME = s.FIRST_NAME,
                    LAST_NAME = s.LAST_NAME,
                    ADDRESS = s.ADDRESS,
                    CONTACT_NUMBER = s.CONTACT_NUMBER,
                    DATE_OF_ENROLLMENT = s.DATE_OF_ENROLLMENT,
                };
                return new JsonResult(DTO);
            }     
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, e.Message);
            }

        }

            public IActionResult Post(StudentDTO dto)
            {

            _logger.LogInformation("Stigao", dto.FIRST_NAME);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

            _logger.LogInformation("Stigao", dto.LAST_NAME);

            try
                {
                    Student s = new Student()
                    {
                        FIRST_NAME = dto.FIRST_NAME,
                        LAST_NAME = dto.LAST_NAME,
                        ADDRESS = dto.ADDRESS,
                        OIB= dto.OIB,
                        CONTACT_NUMBER = dto.CONTACT_NUMBER,
                        DATE_OF_ENROLLMENT = dto.DATE_OF_ENROLLMENT,
                    };
                _context.Student.Add(s);
                _context.SaveChanges();
                dto.ID = s.ID;
                    return Ok(dto);

                }
                catch (Exception ex)
                {
                    return StatusCode(
                        StatusCodes.Status503ServiceUnavailable, ex.InnerException);
                }
            }

            [HttpPut]
            [Route("{ID:int}")]
            public IActionResult Put(int ID,StudentDTO sDto)
            {

                if (ID <= 0 || sDto == null)
                {
                    return BadRequest();
                }

                try
                {
                    var studentBase = _context.Student.Find(ID);
                    if (studentBase == null)
                    {
                        return BadRequest();
                    }
                    
                    studentBase.FIRST_NAME = sDto.FIRST_NAME;
                    studentBase.LAST_NAME = sDto.LAST_NAME;
                    studentBase.ADDRESS = sDto.ADDRESS;
                    studentBase.CONTACT_NUMBER = sDto.CONTACT_NUMBER;
                    studentBase.DATE_OF_ENROLLMENT = sDto.DATE_OF_ENROLLMENT;

                    _context.Student.Update(studentBase);  
                    _context.SaveChanges();
                    sDto.ID = studentBase.ID;
                    return StatusCode(StatusCodes.Status200OK, sDto);

                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                      ex); 
                }


            }

        [HttpGet]
        [Route("search/{condition}")]
        public IActionResult SearchStudent(string condition)
        {
            // ovdje će ići dohvaćanje u bazi

            if (condition == null || condition.Length < 3)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var students = _context.Student
                    .Include(st => st.Courses)
                    .Where(st => st.FIRST_NAME.Contains(condition) || st.LAST_NAME.Contains(condition))
                    .ToList();
        
                List<StudentDTO> back = new();

                students.ForEach(s => {
                    var sdto = new StudentDTO();
                    back.Add(new StudentDTO
                    {
                        FIRST_NAME = s.FIRST_NAME,
                        LAST_NAME = s.LAST_NAME,
                        ADDRESS = s.ADDRESS,
                        OIB = s.OIB,
                        CONTACT_NUMBER = s.CONTACT_NUMBER,
                        DATE_OF_ENROLLMENT = s.DATE_OF_ENROLLMENT,
                    });
                });


                return new JsonResult(back);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, e.Message);
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

            var studentBase = _context.Student.Find(ID);
            if (studentBase == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Student.Remove(studentBase);
                _context.SaveChanges();

                return new JsonResult("{\"message\":\"Deleted\"}");

            }
            catch (Exception )
            {

                return new JsonResult("{\"message\":\"Can not be deleted\"}");

            }

        }

    }


    }

