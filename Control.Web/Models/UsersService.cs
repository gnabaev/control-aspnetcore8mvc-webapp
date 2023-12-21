namespace Control.Web.Models
{
	public class UsersService : IUsersService
	{
		private readonly AppDbContext _context;

		public UsersService(AppDbContext context)
		{
			_context = context;
		}

		public List<User> GetUsers()
		{
			return _context.Users.ToList();
		}
	}
}
