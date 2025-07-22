
### 📘 Entity Framework Getting Started Guide

#### ✅ Step 1: Setup SQL Server and SSMS
- **Installed SQL Server** using the developer edition.
- Installed **SQL Server Management Studio (SSMS)**.
- Verified the connection with server name like: `ASHUTOSH` or `(localdb)\mssqllocaldb`.
- In SSMS, we can:
  - View system databases.
  - Create new databases manually or via EF.

---

#### ✅ Step 2: SQL Server vs MySQL Differences
- **Syntax mostly same** for:
  - `INSERT`, `UPDATE`, `DELETE`, `SELECT`, `WHERE`, etc.
- Some differences:
  - No `SHOW DATABASES`; instead use:
    ```sql
    SELECT name FROM sys.databases;
    ```
  - Must use:
    ```sql
    USE dbname;
    ```
- DML, DDL, TCL, and DQL work similarly with slight syntax changes.

---

#### ✅ Step 3: Entity Framework Basics
- EF is **similar to Hibernate**:
  - Object-relational mapping (ORM).
  - Use annotations/configuration.
  - Works on top of DbContext.

---

#### ✅ Step 4: Basic EF DbContext Setup

```csharp
using Microsoft.EntityFrameworkCore;

namespace Entity_freamwork_Start
{
    internal class DBConnection : DbContext
    {
        public DbSet<Employee> employees; // Entity table mapping

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MySimpleDB;Trusted_Connection=True;");
        }
    }
}
```

---

#### ✅ Database Connection Info
- **Server**: `(localdb)\mssqllocaldb`
- **Database**: `MySimpleDB`
- **Authentication**: Windows Authentication (Trusted_Connection=True)

---

#### 📌 Notes:
- EF commands are run via `Package Manager Console` or `dotnet ef` CLI.
- Table creation and CRUD operations can be done via migrations or code.
