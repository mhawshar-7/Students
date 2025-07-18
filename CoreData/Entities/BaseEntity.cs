﻿using CoreData.Interfaces;

namespace CoreData.Entities
{
	public class BaseEntity: ISoftDeletable
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public bool IsDeleted { get; set; }
	}
}
