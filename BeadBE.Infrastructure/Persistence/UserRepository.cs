using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Domain.Entities;
using BeadBE.Infrastructure.Persistence.Models;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace BeadBE.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly BeadContext DbContext;
        private readonly IMapper _mapper;

        public UserRepository(BeadContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Add(UserEntity user)
        {
            DbContext.Set<User>().Add(_mapper.Map<UserEntity, User>(user)).State = EntityState.Added;

            await DbContext.SaveChangesAsync();
        }

        public UserEntity GetUserByEmail(string email)
        {
            User? existingUser = DbContext.Set<User>().SingleOrDefault(user => user.Email == email);

            return _mapper.Map<User, UserEntity>(existingUser);
        }
    }
}
