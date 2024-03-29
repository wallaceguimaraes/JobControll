using Microsoft.EntityFrameworkCore;

namespace api.Models.EntityModel.Users
{
   public static class UserQuery
   {
      public static IQueryable<User> WhereId(this IQueryable<User> users, int userId)
          => users.Where(user => user.Id == userId);

      public static IQueryable<User> WhereSalt(this IQueryable<User> users, string salt)
         => users.Where(user => user.Salt == salt);

      public static IQueryable<User> WhereNotId(this IQueryable<User> users, int userId)
           => users.Where(user => user.Id != userId);

      // public static IQueryable<User> IncludeTimesAndProject(this IQueryable<User> users)
      //     => users.Include(user => user.Times).ThenInclude(time => time.Project);

      public static IQueryable<User> WhereIds(this IQueryable<User> users, ICollection<int> userIds)
         => users.Where(user => userIds.Contains(user.Id));

      public static IQueryable<User> WhereLogin(this IQueryable<User> users, string login)
         => users.Where(user => user.Login == login);

      public static IQueryable<User> WhereEmail(this IQueryable<User> users, string email)
         => users.Where(user => user.Email == email);

   }
}