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
    public class SkillsController : ControllerBase
    {
        // private readonly TrainerCalenderDbContext _context;
        private readonly ISkillRepository _skillRepository;


        public SkillsController(ISkillRepository skillRepository)
        {
            //_context = context;
            _skillRepository = skillRepository;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<object> GetSkills()
        {
            try
            {
                IEnumerable<SkillDto> SkillDtos = await _skillRepository.GetSkills();
                
                return SkillDtos;
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }


            //return await _context.Skills.ToListAsync();
        }

        // GET: api/Skills/5
       [HttpGet("{id}")]
        public async Task<object> GetSkill(int id)
        {
            try
            {
                SkillDto skilldto= await _skillRepository.GetSkillById(id);

                return skilldto;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        //public async Task<ActionResult<Skill>> GetSkill(int id)
        //{
        //    var skill = await _context.Skills.FindAsync(id);

        //    if (skill == null)
        //    {
        //        return NotFound();
        //    }

        //    return skill;
        //}

        // PUT: api/Skills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id")]
        public async Task<object> Put([FromBody] SkillDto skillDto)
        {
            try
            {
                SkillDto model = await _skillRepository.CreateUpdateSkill(skillDto);
                return model;
            }
            catch
            {
                return null;
            }
        }
        //public async Task<IActionResult> PutSkill(int id, Skill skill)
        //{
        //    if (id != skill.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(skill).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SkillExists(id))
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

        // POST: api/Skills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<object> Post([FromBody] SkillDto skillDto)
        {
            try
            {
                SkillDto model = await _skillRepository.CreateUpdateSkill(skillDto);
                return model;
            }
            catch
            {
                return null;
            }
        }
        //public async Task<ActionResult<Skill>> PostSkill(Skill skill)
        //{
        //    _context.Skills.Add(skill);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSkill", new { id = skill.Id }, skill);
        //}

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                return await _skillRepository.DeleteSkill(id); 
            }
            catch (Exception ex)
            {
                return null;
            }
        }

            //public async Task<IActionResult> DeleteSkill(int id)
            //{
            //    var skill = await _context.Skills.FindAsync(id);
            //    if (skill == null)
            //    {
            //        return NotFound();
            //    }

            //    _context.Skills.Remove(skill);
            //    await _context.SaveChangesAsync();

            //    return NoContent();
            //}

            //private bool SkillExists(int id)
            //{
            //    return _context.Skills.Any(e => e.Id == id);
            //}
        }
}
