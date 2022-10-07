using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainerCalender.Models;
using TrainerCalender.Models.Dto;
using TrainerCalender.Repository;

namespace TrainerCalender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerCoursesController : ControllerBase
    {
        //private readonly TrainerCalenderDbContext _context;
        private readonly ITrainerCourseRepository _trainerCourseRepository;
        public TrainerCoursesController(ITrainerCourseRepository trainerCourseRepository)
        {
            //_context = context;
            _trainerCourseRepository = trainerCourseRepository;
        }

        // GET: api/TrainerCourses
        [HttpGet]
        public async Task<object> GetTrainerCourses()
        {
            try
            {
                IEnumerable<TrainerCourseDto> trainerCourseDtos = await _trainerCourseRepository.GetTrainerCourses();
                foreach(var trainerCourse in trainerCourseDtos)
                {
                    trainerCourse.TrainerName=User.Identity.Name;
                    return trainerCourse;
                }
                return "success";
               // return trainerCourseDtos;
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }
        //public async Task<ActionResult<IEnumerable<TrainerCourse>>> GetTrainerCourses()
        //{
        //    return await _context.TrainerCourses.Include(x=>x.Schedules).ToListAsync();
        //}

        //// GET: api/TrainerCourses/5
        [HttpGet("{id}")]
        public async Task<object> GetTrainerCourse(int id)
        {
            try
            {
                TrainerCourseDto trainerCourseDto = await _trainerCourseRepository.GetTrainerCourseById(id);
                return trainerCourseDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //public async Task<ActionResult<TrainerCourse>> GetTrainerCourse(int id)
        //{
        //    var trainerCourse = await _context.TrainerCourses.FindAsync(id);

        //    if (trainerCourse == null)
        //    {
        //        return NotFound();
        //    }

        //    return trainerCourse;
        //}

        //// PUT: api/TrainerCourses/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<object> Put([FromBody] TrainerCourseDto trainerCourseDto)
        {
            try
            {
                TrainerCourseDto model = await _trainerCourseRepository.CreateUpdateTrainerCourse(trainerCourseDto);
                return model;
            }
            catch
            {
                return null;
            }
        }
        //public async Task<IActionResult> PutTrainerCourse(int id, TrainerCourse trainerCourse)
        //{
        //    if (id != trainerCourse.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(trainerCourse).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TrainerCourseExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/TrainerCourses
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<object> Post([FromBody] TrainerCourseDto trainerCourseDto)
        {
            try
            {
                TrainerCourseDto model = await _trainerCourseRepository.CreateUpdateTrainerCourse(trainerCourseDto);
                return model;
            }
            catch
            {
                return null;
            }
        }
        //public async Task<ActionResult<TrainerCourse>> PostTrainerCourse(TrainerCourseDto trainerCourse)
        //{
        //    var user = await _context.Users.Where(x=>x.FirstName == trainerCourse.TrainerName).FirstOrDefaultAsync();
        //    //if(user == null)
        //    //    return NotFound();

        //    var course = await _context.Courses.Where(x=>x.Name == trainerCourse.CourseName).FirstOrDefaultAsync();
        //    //if (course == null)
        //    //    return NotFound();

        //    if (course == null || user==null)
        //        return NotFound();

        //    var TrainerCourse = new TrainerCourse
        //    {
        //        UserId = user.Id,
        //        CourseId=course.Id
        //    };
        //    _context.TrainerCourses.Add(TrainerCourse);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTrainerCourse", new { id = TrainerCourse.Id }, TrainerCourse);
        //}

        //// DELETE: api/TrainerCourses/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                return await _trainerCourseRepository.DeleteTrainerCourse(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //public async Task<IActionResult> DeleteTrainerCourse(int id)
        //{
        //    var trainerCourse = await _context.TrainerCourses.FindAsync(id);
        //    if (trainerCourse == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TrainerCourses.Remove(trainerCourse);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TrainerCourseExists(int id)
        //{
        //    return _context.TrainerCourses.Any(e => e.Id == id);
        //}
    }
}
