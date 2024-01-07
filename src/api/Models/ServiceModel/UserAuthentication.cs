using Microsoft.Extensions.Options;
using api.Models.EntityModel.Users;
using Microsoft.EntityFrameworkCore;
using api.Data.Context;
using api.Authorization;
using api.Extensions;
using api.Models.Interfaces;

namespace api.Models.ServiceModel
{
    public class UserAuthentication : IUserAuthentication
    {
        private readonly ApiDbContext _dbContext;
        private readonly AuthOptions _authOptions;

        public UserAuthentication(
            ApiDbContext dbContext,
            IOptions<AuthOptions> authOptionsAccessor
             )
        {
            _dbContext = dbContext;
            _authOptions = authOptionsAccessor.Value;
        }
        private const string USER_NOT_FOUND = "USER_NOT_FOUND";
        public User User { get; private set; }

        public async Task<(bool, User)> SignIn(string login, string password)
        {
            User = await _dbContext.Users
                .WhereLogin(login)
                .SingleOrDefaultAsync();

            if (User == null) return (false, null);

            return (User.Password == password.Encrypt(User.Salt), User);
        }

        public async Task<(User?, string?)> FindUser(int holderId, string salt)
        {
            var queryUser = _dbContext.Users
              .WhereId(holderId)
              .WhereSalt(salt);

            User = await queryUser.SingleOrDefaultAsync();

            if (User is null)
                return (User, USER_NOT_FOUND);

            return (User, null);
        }
    }
}