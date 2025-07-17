# EFData Folder

### Data

- **GenericRepository.cs**  
  Implements the IGenericRepository for CRUD operations on entities derived from `BaseEntity`.

- **UnitOfWork.cs**  
  Manages repositories and coordinates saving changes to the database.

- **StoreContext.cs**  
  The main EF Core `DbContext` for the application. 
  Handles entity sets, model configuration, and custom save logic (including soft deletes and audit fields).

- **Migrations/**  
  Contains EF Core migration files generated automatically when add migration.

### Config
- **StudentConfiguration.cs**  
  Entity configuration for the `Student` entity, specify property requirements and data types.

