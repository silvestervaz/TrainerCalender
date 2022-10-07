using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrainerCalender.Models;
using TrainerCalender.Models.Dto;

namespace TrainerCalender.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TrainerCalenderDbContext _context;
        private IMapper _mapper;

        public UserRepository(TrainerCalenderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateUpdateUser(UserDto userdto)
        {
            User user = _mapper.Map<UserDto, User>(userdto);
            if (user.Id > 0)
            {                
                _context.Users.Update(user);
            }
            else
            {
                _context.Users.Add(user);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                User user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return false;
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<UserDto> GetUserById(int id)
        {
            User user = await _context.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            List<User> UserList = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDto>>(UserList);
        }
    }
}
