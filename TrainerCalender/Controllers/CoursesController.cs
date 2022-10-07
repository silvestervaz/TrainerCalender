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
    public class CoursesController : ControllerBase
    {
        // private readonly TrainerCalenderDbContext _context;
        private readonly ICourseRepository _courseRepository;
        public CoursesController(ICourseRepository courseRepository)
        {
            //_context = context;
            _courseRepository = courseRepository;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<object> GetCourses()
        {
            try
            {
                IEnumerable<CourseDto> CourseDtos = await _courseRepository.GetCourses();
                return CourseDtos;
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }          
        }
        //public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        //{
        //    return await _context.Courses.Include(x=>x.TrainerCourses).ToListAsync();
        //}

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<object> GetCourse(int id)
        {
            try
            {
                CourseDto coursedto = await _courseRepository.GetCourseById(id);
                return coursedto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //public async Task<ActionResult<Course>> GetCourse(int id)
        //{
        //    var course = await _context.Courses.FindAsync(id);
        //    //var skill=await _context.Skills.FindAsync(course.SkillId);

        //    //course.Skill = skill;
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    return course;
        //}

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<object> Put([FromBody] CourseDto courseDto)
        {
            try
            {
                CourseDto model = await _courseRepository.CreateUpdateCourse(courseDto);
                return model;
            }
            catch
            {
                return null;
            }
        }
        //public async Task<IActionResult> PutCourse(int id, Course course)
        //{
        //    if (id != course.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(course).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<object> Post([FromBody] CourseDto courseDto)
        {
            try
            {
                CourseDto model = await _courseRepository.CreateUpdateCourse(courseDto);
                return model;
            }
            catch
            {
                return null;
            }
        }

//        public async Task<ActionResult<Course>> PostCourse(CourseDto course)
//        {
//            var skill = await _context.Skills.Where(x => x.Name.Equals(course.SkillName)).FirstOrDefaultAsync();
//            if (skill == null)
//                return NotFound();

        //            var newCourse = new Course
        //            {
        //                Name = course.Name,
        //                SkillId=skill.Id
        //            };
        //            _context.Courses.Add(newCourse);
        //            await _context.SaveChangesAsync();
        //            //return _context.Courses.Include(x => x.Skill).ToListAsync();
        //;            
        //            //return CreatedAtAction("GetCourse", new { id = newCourse.Id }, newCourse);
        //            return await  GetCourse(newCourse.Id);
        //        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                return await _courseRepository.DeleteCourse(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //public async Task<IActionResult> DeleteCourse(int id)
        //{
        //    var course = await _context.Courses.FindAsync(id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Courses.Remove(course);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CourseExists(int id)
        //{
        //    return _context.Courses.Any(e => e.Id == id);
        //}
    }
}
