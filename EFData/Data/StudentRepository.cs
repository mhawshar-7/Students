using CoreData.Entities;
using CoreData.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
	/// <summary>
	/// Student Repository for more specialize
	/// But now we used Generic Repos instead.
	/// </summary>
	public class StudentRepository : IStudentRepository
	{
		private readonly StoreContext _context;

		public StudentRepository(StoreContext context)
		{
			_context = context;
		}

		public async Task<Student> GetStudentByIdAsync(int id)
		{
			return await _context.Students
						 .FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IReadOnlyList<Student>> GetStudentsAsync()
		{
			return await _context.Students
						 .ToListAsync();
		}
	}
}
