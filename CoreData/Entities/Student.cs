
namespace CoreData.Entities
{
	public class Student: BaseEntity
	{
		public Student()
		{
		}

		public Student(string name, int age, string major, decimal gpa, string contactInfo)
		{
			Name = name;
			Age = age;
			Major = major;
			GPA = gpa;
			ContactInfo = contactInfo;
		}

		public string Name { get; set; }
		public int Age { get; set; }
		public string Major { get; set; }
		public decimal GPA { get; set; }
		public string ContactInfo { get; set; }
	}
}
