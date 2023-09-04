using DotNet.Models;
using DotNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IStudentService _studentService;

		public StudentsController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		// POST: api/user
		[HttpPost]
		public IActionResult Create(Student model)
		{
			_studentService.CreateUser(model);

			return Ok(new { message = "User created successfully!" });
		}

		// GET: api/user/id
		[HttpDelete("id")]
		public IActionResult Delete(int id)
		{
			var item = _studentService.GetUser(id);

			if (item == null)
				return NotFound("User doesn't exist");


			_studentService.DeleteUser(item.Id);

			return Ok(new { message = "User deleted successfully!" });
		}

		// GET: api/user
		[HttpGet]
		public IActionResult GetList()
		{
			return Ok(_studentService.GetUsers());
		}

		// DELETE: api/user/id
		[HttpGet("id")]
		public IActionResult GetById(int id)
		{
			var item = _studentService.GetUser(id);

			if(item == null)
				return NotFound("User doesn't exist");

			var read = new Student { UserName = item.UserName, Email = item.Email };

			return Ok(read);
		}

	}
}