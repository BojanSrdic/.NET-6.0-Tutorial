using DotNet.Data;
using DotNet.Models;

namespace DotNet.Services
{
	public class StudentService : IStudentService
	{
		private readonly DatabaseContext _context;

		public StudentService(DatabaseContext context)
		{
			_context = context;
		}

		public void CreateUser(Student model)
		{
			// Todo: Mapp domain models and data transfer objects
			var user = new Student
			{
				UserName = model.UserName,
				Email = model.Email,
				Password = model.Password
			};

			// Todo: Add new models to tables in db and save changes
			_context.Students.Add(user);
			_context.SaveChanges();
		}

		public void DeleteUser(int id)
		{
			var item = _context.Students.Find(id);

			// Todo: throw exception if user doesn't exist before deleting
			if (item is null)
				throw new KeyNotFoundException("Item not found");
			
			_context.Students.Remove(item);
			_context.SaveChanges();
		}

		public Student GetUser(int id)
		{
			return _context.Students.Find(id);
		}

		public List<Student> GetUsers()
		{
			return _context.Students.ToList();
		}

		public void UpdataUser(Student model)
		{
			throw new NotImplementedException();
		}
	}
}