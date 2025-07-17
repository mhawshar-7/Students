# CoreData Folder

## Interfaces

Located in `CoreData/Interfaces`:

- **IUnitOfWork.cs**  
  We can manage multiple repository operations within a single transaction.

- **IGenericRepository.cs**  
  Generic data access layer that works for any entity type (T), with common operations.

- **IStudentRepository.cs!**  
  We can specialize data access for the `Student` entity.

- **ISoftDeletable.cs**  
  Interface for entities that support soft delete via an `IsDeleted` property.

### Entities

Located in `CoreData/Entities`:

- **BaseEntity.cs**  
  The base class for all entities, 
  typically includes common properties like Id, CreatedDate, ModifiedDate.

## Usage

Use the interfaces to implement repository and unitofwork patterns for data access.  
Entities define the data models used through the application.
