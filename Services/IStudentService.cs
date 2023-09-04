
using DotNet.Models;

namespace DotNet.Services
{
	public interface IStudentService
	{
		Student GetUser(int id);
		List<Student> GetUsers();
		void CreateUser(Student model);
		void UpdataUser(Student model);
		void DeleteUser(int id);
	}
}