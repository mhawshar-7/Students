
namespace CoreData.Entities
{
	public class Student: BaseEntity
	{
		public Student()
		{
		}

		public Student(string name)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}
