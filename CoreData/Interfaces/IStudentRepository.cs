using CoreData.Entities;

namespace CoreData.Interfaces
{
	public interface IStudentRepository
	{
		Task<Student> GetStudentByIdAsync(int id);
		Task<IReadOnlyList<Student>> GetStudentsAsync();
	}
}
