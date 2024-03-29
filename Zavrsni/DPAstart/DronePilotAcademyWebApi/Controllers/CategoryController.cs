﻿using DronePilotAcademyWebApi.Data;
using DronePilotAcademyWebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace DronePilotAcademyWebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class CategoryController : ControllerBase
    {
        private readonly Context _context;

        public CategoryController(Context context) 
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
                var categories = _context.Category.ToList();
                if (categories == null || categories.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.Category.ToList());
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
                var c = _context.Category.Find(ID);

                if (c == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, c);
                }

                return new JsonResult(c);

            }
            catch (Exception ex)
            {
                return  
                    StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }

        }

        [HttpPost]
        public IActionResult Post(Category category)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Category.Add(category);
                _context.SaveChanges();
                
                return StatusCode(StatusCodes.Status201Created, category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                   ex.Message);
            }
        }

        [Route("{ID:int}")]
        public IActionResult Put(int ID, Category category)
        {
            if (ID <= 0 || category == null)
            {
                return BadRequest();
            }

            try
            {
                var cateBase = _context.Category.Find(ID);
                if (cateBase == null)
                {
                    return BadRequest();
                }
           

                cateBase.NAME=category.NAME;
                cateBase.PRICE=category.PRICE;
                cateBase.NUMBER_OF_TR_LECTURES = category.NUMBER_OF_TR_LECTURES;
                cateBase.NUMBER_OF_DRIVING_LECTURES = category.NUMBER_OF_DRIVING_LECTURES;

                _context.Category.Update(cateBase);
                _context.SaveChanges();
                
                return StatusCode(StatusCodes.Status200OK, cateBase);

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

            var cateBase = _context.Category.Find(ID);
            if (cateBase == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Category.Remove(cateBase);
                _context.SaveChanges();

                return new JsonResult("{\"message\":\"Deleted\"}");

            }
            catch (Exception )
            {

                return StatusCode(StatusCodes.Status400BadRequest, "Can not be deleted");

            }
        }
    }
}
