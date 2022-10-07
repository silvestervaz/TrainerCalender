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
    public class SchedulesController : ControllerBase
    {
        // private readonly TrainerCalenderDbContext _context;
        private readonly IScheduleRepository _scheduleRepository;

        public SchedulesController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        // GET: api/Schedules
        [HttpGet]
        public async Task<object> GetSchedules()
        {
            try
            {
                IEnumerable<ScheduleDto> scheduleDtos = await _scheduleRepository.GetSchedules();
                return scheduleDtos;
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
 //       public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
 //       {
 //           return await _context.Schedules.ToListAsync();
 //       }

        //       // GET: api/Schedules/5
             [HttpGet("{id}")]
        public async Task<object> GetSchedule(int id)
        {
            try
            {
                ScheduleDto scheduleDto = await _scheduleRepository.GetScheduleById(id);
                return scheduleDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //       public async Task<ActionResult<Schedule>> GetSchedule(int id)
        //       {
        //           var schedule = await _context.Schedules.FindAsync(id);

        //           if (schedule == null)
        //           {
        //               return NotFound();
        //           }

        //           return schedule;
        //       }

        //       // PUT: api/Schedules/5
        //       // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
             [HttpPut("{id}")]
        public async Task<object> Put([FromBody] ScheduleDto scheduleDto)
        {
            try
            {
                ScheduleDto model = await _scheduleRepository.CreateUpdateSchedule(scheduleDto);
                return model;
            }
            catch
            {
                return null;
            }
        }
        //     public async Task<IActionResult> PutSchedule(int id, Schedule schedule)
        //       {
        //           if (id != schedule.Id)
        //           {
        //               return BadRequest();
        //           }

        //           _context.Entry(schedule).State = EntityState.Modified;

        //           try
        //           {
        //               await _context.SaveChangesAsync();
        //           }
        //           catch (DbUpdateConcurrencyException)
        //           {
        //               if (!ScheduleExists(id))
        //               {
        //                   return NotFound();
        //               }
        //               else
        //               {
        //                   throw;
        //               }
        //           }

        //           return NoContent();
        //       }

        //       // POST: api/Schedules
        //       // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
              [HttpPost]
        public async Task<object> Post([FromBody] ScheduleDto scheduleDto)
        {
            try
            {
                ScheduleDto model = await _scheduleRepository.CreateUpdateSchedule(scheduleDto);
                return model;
            }
            catch
            {
                return null;
            }
        }
        //       public async Task<ActionResult<Schedule>> PostSchedule(ScheduleDto schedule)
        //       {
        //           var course= await _context.Courses.Where(x => x.Name == schedule.CourseName).FirstOrDefaultAsync();
        //           var trainerCourse=_context.TrainerCourses.Where(x=>x.CourseId == course.Id).FirstOrDefault();
        //           if (trainerCourse == null)
        //               return NotFound();

        //           var newSchedule=new Schedule
        //           {
        //                SessionName =schedule.SessionName,

        //                Date =schedule.Date,

        //                StartTime =schedule.StartTime,

        //                EndTime=schedule.EndTime, 

        //                Location =schedule.Location ,   

        //                Mode =schedule.Mode,

        //                TrainerCourseId=trainerCourse.Id
        //   }

        //;           _context.Schedules.Add(newSchedule);
        //           await _context.SaveChangesAsync();

        //           // return CreatedAtAction("GetSchedule", new { id = newSchedule.Id }, schedule);
        //           return await GetSchedule(newSchedule.Id);
        //          // return "data added succesfully";
        //       }

        //       // DELETE: api/Schedules/5
               [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                return await _scheduleRepository.DeleteSchedule(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //       public async Task<IActionResult> DeleteSchedule(int id)
        //       {
        //           var schedule = await _context.Schedules.FindAsync(id);
        //           if (schedule == null)
        //           {
        //               return NotFound();
        //           }

        //           _context.Schedules.Remove(schedule);
        //           await _context.SaveChangesAsync();

        //           return NoContent();
        //       }

        //       private bool ScheduleExists(int id)
        //       {
        //           return _context.Schedules.Any(e => e.Id == id);
        //       }
    }
}
