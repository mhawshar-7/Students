﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
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
