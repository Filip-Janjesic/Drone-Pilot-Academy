using DronePilotAcademyWebApi.Data;
using DronePilotAcademyWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace DronePilotAcademyWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class DroneController : Controller
    {
        private readonly Context _context;

        public DroneController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                try
                {
                    var drones = _context.Drone.ToList();
                    if (drones == null || drones.Count == 0)
                    {
                        return new EmptyResult();
                    }
                    return new JsonResult(_context.Drone.ToList());
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                            ex.Message);
                }

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
                var v = _context.Drone.Find(ID);

                if (v == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, v);
                }

                return new JsonResult(v);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post(Drone drone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Drone.Add(drone);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, drone);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                   ex.Message);
            }


        }

        [HttpPut]
        [Route("{ID:int}")]
        public IActionResult Put(int ID, Drone drone)
        {
            if (ID <= 0 || drone == null)
            {
                return BadRequest();
            }

            try
            {
                var droneBase = _context.Drone.Find(ID);
                if (droneBase == null)
                {
                    return BadRequest();
                }

                droneBase.TYPE = drone.TYPE;
                droneBase.BRAND = drone.BRAND;
                droneBase.MODEL = drone.MODEL;
                droneBase.PURCHASE_DATE=drone.PURCHASE_DATE;
                droneBase.DATE_OF_REGISTRATION=drone.DATE_OF_REGISTRATION;
                

                _context.Drone.Update(droneBase);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, droneBase);

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

            var droneBase = _context.Drone.Find(ID);
            if (droneBase == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Drone.Remove(droneBase);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Deleted\"}");

            }
            catch (Exception ex)
            {

                return new JsonResult("{\"poruka\":\"Can not be deleted\"}");

            }
        }


    }
}

        
    







