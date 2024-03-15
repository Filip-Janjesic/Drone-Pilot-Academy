using DrivingSchoolWebApi.Data;
using DrivingSchoolWebApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrivingSchoolWebApi.Models;


namespace DrivingSchoolWebApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]

    public class CourseController : ControllerBase
    {
        private readonly Context _context;
        private readonly ILogger<CourseController> _logger;
        public CourseController(Context context, ILogger<CourseController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public DateTime? START_DATE { get; private set; }

        /// <summary>
        /// dohvaca sve tecajeve
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting courses");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var courses = _context.Course
                    .Include(c => c.Instructor)
                    .Include(c => c.Vehicle)
                    .Include(c => c.Category)
                    .Include(c => c.Students)
                    .ToList();

                if (courses == null || courses.Count == 0)
                {
                    return new EmptyResult();
                }

                List<CourseDTO> back = new();

                courses.ForEach(c =>
                {
                    back.Add(new CourseDTO()
                    {
                        ID = c.ID,
                        IDInstructor = c.Instructor.ID,
                        IDCategory = c.Category.ID,
                        IDVehicle = c.Vehicle.ID,
                        START_DATE = c.START_DATE,
                        Number_of_students = c.Students.Count

                    });
                });
                return Ok(back);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status503ServiceUnavailable,
                    ex);
            }


        }

        /// <summary>
        /// dodavanje novih tecajeva
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="courseDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [HttpGet]
        [Route("{ID:int}")]
        public IActionResult GetById(int ID)
        {
            // ovdje će ići dohvaćanje u bazi


            if (ID == 0)
            {
                return BadRequest(ModelState);
            }

            var C = _context.Course.Include(i => i.Instructor)
                .Include(v => v.Vehicle)
                .Include(ca => ca.Category)
                .Include(st => st.Students)
              .FirstOrDefault(x => x.ID == ID);

            if (C == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, C); 
            }

            try
            {
                return new JsonResult(new CourseDTO()
                {
                    ID = C.ID,
                    START_DATE = C.START_DATE,
                    IDCategory = C.Category == null ? 0 : C.Category.ID,
                    IDInstructor = C.Instructor == null ? 0 : C.Instructor.ID,
                    IDVehicle = C.Vehicle == null ? 0 : C.Vehicle.ID

                    
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }




        [HttpPost]
        public IActionResult Post(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (courseDTO.IDInstructor <= 0)
            {
                return BadRequest(ModelState);
            }

            if (courseDTO.IDVehicle <= 0)
            {
                return BadRequest(ModelState);
            }
            if (courseDTO.IDCategory <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var instructor = _context.Instructor.Find(courseDTO.IDInstructor);
                if (instructor == null)
                {
                    return BadRequest(ModelState);
                }
                var vehicle = _context.Vehicle.Find(courseDTO.IDVehicle);
                if (vehicle == null)
                {
                    return BadRequest(ModelState);
                }

                var category = _context.Category.Find(courseDTO.IDCategory);
                if (category == null)
                {
                    return BadRequest(ModelState);
                }


                Course c = new()
                {
                    START_DATE = courseDTO.START_DATE,
                    Instructor = instructor,
                    Vehicle = vehicle,
                    Category = category

                };

                _context.Course.Add(c);
                _context.SaveChanges();

                courseDTO.ID = c.ID;


                return Ok(courseDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
            }

        }


        /// <summary>
        /// promjena tecajeva
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="courseDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{ID:int}")]

        public IActionResult Put(int ID, CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (ID <= 0 || courseDTO == null)
            {
                return BadRequest();
            }
            try
            {
                var course = _context.Course.Find(ID);
                if (course == null)
                {
                    return BadRequest();
                }
                var instructor = _context.Instructor.Find(courseDTO.IDInstructor);
                if (instructor == null)
                {
                    return BadRequest(ModelState);
                }
                var vehicle = _context.Vehicle.Find(courseDTO.IDVehicle);
                if (vehicle == null)
                {
                    return BadRequest(ModelState);
                }

                var category = _context.Category.Find(courseDTO.IDCategory);
                if (category == null)
                {
                    return BadRequest(ModelState);
                }

                /*  var student = _context.Student.Find(ID);
                  if (student == null)
                  {
                      return BadRequest(ModelState);
                  }
                */
                course.START_DATE = courseDTO.START_DATE;

                course.Instructor = instructor;
                course.Vehicle = vehicle;
                course.Category = category;

                _context.Course.Update(course);
                _context.SaveChanges();

                courseDTO.ID = ID;
                //courseDTO.Category=category.NAME;

                return Ok(courseDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }
        /// <summary>
        /// brisanje tecajeva
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{ID:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int ID)
        {
            if (ID <= 0)
            {
                return BadRequest();
            }

            var courseBase = _context.Course.Find(ID);
            if (courseBase == null)
            {
                return BadRequest();
            }
            try
            {
                _context.Course.Remove(courseBase);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"deleted\"}");
            }
            catch (Exception ex)
            {
                return new JsonResult("{\"message\":\"Can not be deleted\"}");
            }
        }

        [HttpGet]
        [Route("{ID:int}/students")]
        public IActionResult GetStudents(int ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (ID <= 0)
            {
                return BadRequest();
            }
            try
            {
                var course = _context.Course
                    .Include(c => c.Students)
                    .FirstOrDefault(c => c.ID == ID);

                if (course == null)
                {
                    return BadRequest();
                }

                if (course.Students == null || course.Students.Count == 0)
                {
                    return new EmptyResult();
                }

                List<StudentDTO> Back = new();
                course.Students.ForEach(s =>
                {
                    Back.Add(new StudentDTO()
                    {
                        ID = s.ID,
                        FIRST_NAME = s.FIRST_NAME,
                        LAST_NAME = s.LAST_NAME,
                        ADDRESS = s.ADDRESS,
                        OIB = s.OIB,
                        CONTACT_NUMBER = s.CONTACT_NUMBER,
                        DATE_OF_ENROLLMENT = s.DATE_OF_ENROLLMENT

                    });
                });

                return Ok(Back);
            }
            catch (Exception ex)
            {
                return StatusCode(
                        StatusCodes.Status503ServiceUnavailable,
                        ex.Message);
            }

        }
        [HttpPost]
        [Route("{ID:int}/add/{studentID:int}")]
        public IActionResult AddStudent(int ID, int studentID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (ID <= 0 || studentID <= 0)
            {
                return BadRequest();
            }

            try
            {
                var course = _context.Course
                   .Include(c => c.Students)
                   .FirstOrDefault(c => c.ID == ID);
                if (course == null)
                {
                    return BadRequest();
                }
                var student = _context.Student.Find(studentID);
                if (student == null)
                {
                    return BadRequest();
                }

                course.Students.Add(student);
                _context.Course.Update(course);
                _context.SaveChanges();


                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(
                       StatusCodes.Status503ServiceUnavailable,
                       ex.Message);
            }

        }

        [HttpDelete]
        [Route("{ID:int}/add/{studentID:int}")]
        public IActionResult DeleteStudent(int ID, int studentID)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (ID <= 0 || studentID <= 0)
            {
                return BadRequest();
            }

            try
            {
                var course = _context.Course
                   .Include(c => c.Students)
                   .FirstOrDefault(c => c.ID == ID);
                if (course == null)
                {
                    return BadRequest();
                }

                var student = _context.Student.Find(studentID);

                if (student == null)
                {
                    return BadRequest();
                }

                course.Students.Remove(student);

                _context.Course.Update(course);
                _context.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(
                       StatusCodes.Status503ServiceUnavailable,
                       ex.Message);
            }

        }
    }
}
    

