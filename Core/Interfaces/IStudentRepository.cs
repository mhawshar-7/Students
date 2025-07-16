using Core.Entities;

namespace Core.Interfaces
{
	public interface IStudentRepository
	{
		Task<Student> GetStudentByIdAsync(int id);
		Task<IReadOnlyList<Student>> GetStudentsAsync();
	}
}
