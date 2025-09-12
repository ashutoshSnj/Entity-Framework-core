# Entity Framework Core – Inheritance Mapping Strategies

This document summarizes my learnings about **Inheritance in Entity Framework Core (EF Core)**.  
It focuses on the **different inheritance mapping strategies**, how EF Core handles them, and the required migration commands.  

---

## 🔹 Why Inheritance in EF Core?

In software development, inheritance allows us to create a **base class** with common properties (e.g., `Id`, `Name`, `Address`) and then create **derived classes** for specialized entities (e.g., `FullTimeEmployee`, `PartTimeEmployee`).  

When working with databases, EF Core provides multiple strategies to represent this inheritance model in relational tables.  

---

## 🔹 Inheritance Strategies in EF Core

### 1️⃣ TPH (Table per Hierarchy)
- A **single table** is used for all entities.  
- A **discriminator column** is automatically added to differentiate between entity types.  
- Simple and fast, but the table can become very wide with many nullable columns.  

**Connection Class:**
```csharp
public class DBConnection1 : DbContext
{
    public DbSet<Employe> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=Employedata1;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employe>()
            .HasDiscriminator<string>("EmployeeType")
            .HasValue<FullTimeEmployee>("FullTime")
            .HasValue<PartTimeEmployee>("PartTime");
    }
}
```

---

### 2️⃣ TPT (Table per Type)
- Each entity type has its **own table**.  
- The base table holds the common properties, while derived tables hold specific ones.  
- Provides normalized design but may lead to **complex joins** when querying.  

**Connection Class:**
```csharp
public class DBConnection2 : DbContext
{
    public DbSet<Employe> Employees { get; set; }
    public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
    public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=Employedata2;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employe>().ToTable("Employees");
        modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployees");
        modelBuilder.Entity<PartTimeEmployee>().ToTable("PartTimeEmployees");
    }
}
```

---

### 3️⃣ TPC (Table per Concrete Type)
- Each **concrete class** has its own table.  
- Base class properties are **duplicated** in each table.  
- No discriminator is needed.  
- Avoids joins but leads to **data duplication**.  

**Connection Class:**
```csharp
public class DBConnection3 : DbContext
{
    public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
    public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=Employedata3;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FullTimeEmployee>().UseTpcMappingStrategy();
        modelBuilder.Entity<PartTimeEmployee>().UseTpcMappingStrategy();
    }
}
```

---

## 🔹 Migration Commands

When we change the model or add a new inheritance strategy, we need to update the database schema.  

1. **Create a new migration**
```bash
Add-Migration InitialMigration
```

2. **Update the database**
```bash
Update-Database
```

3. **Remove last migration (if needed)**
```bash
Remove-Migration
```

4. **Script the migration (optional)**
```bash
Script-Migration
```

---

## 🔹 Summary

- **TPH** → Single table, simple but may contain many `NULL` columns.  
- **TPT** → Normalized design, but queries need joins.  
- **TPC** → No joins, but data duplication.  

👉 Choosing the right strategy depends on **performance, normalization needs, and project requirements**.  

---
✅ This document captures my learning about **Inheritance Mapping in EF Core** along with connection classes and migration commands.
