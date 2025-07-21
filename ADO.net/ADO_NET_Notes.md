
# 📘 ADO.NET Notes

ADO.NET (ActiveX Data Objects .NET) is a data access technology from the Microsoft .NET Framework that provides communication between relational and non-relational systems through a common set of components.

---

## 🔹 1. What is ADO.NET?
- ADO.NET is a set of classes that expose data access services to the .NET programmer.
- It works with different data sources like SQL Server, Oracle, and even XML files.
- Part of the .NET Framework under `System.Data` namespace.

---

## 🔹 2. Key ADO.NET Components

| Component              | Description |
|------------------------|-------------|
| `SqlConnection`        | Establishes a connection to a data source |
| `SqlCommand`           | Executes queries and stored procedures |
| `SqlDataReader`        | Fast, forward-only way to read data |
| `SqlDataAdapter`       | Bridge between DataSet and Data Source |
| `DataSet`              | In-memory data cache |
| `DataTable`            | Represents one table of in-memory data |
| `ConnectionString`     | Used to configure connection to the database |

---

## 🔹 3. Code Example - Connect and Read Data

```csharp
using System;
using System.Data.SqlClient;

class Program {
    static void Main() {
        string connectionString = "Server=localhost;Database=TestDB;Trusted_Connection=True;";
        using(SqlConnection conn = new SqlConnection(connectionString)) {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                Console.WriteLine(reader["Name"]);
            }
        }
    }
}
```

---

## 🔹 4. Features of ADO.NET
- Disconnected architecture using `DataSet`
- XML integration
- Scalability and performance
- Supports multiple database types

---

## 🔹 5. ADO.NET vs JDBC
| Feature        | ADO.NET         | JDBC             |
|----------------|------------------|------------------|
| Platform       | .NET             | Java             |
| Main Class     | SqlConnection    | Connection       |
| XML Support    | Strong           | Limited          |
| Disconnected?  | Yes (DataSet)    | No (Mostly Connected) |

---

## 🔹 6. Best Practices
- Always use `using` statement for resource management
- Use parameterized queries to prevent SQL injection
- Use connection pooling
- Catch exceptions and log errors
- Close connections explicitly (or use `using`)

---

🧠 **Tip:** Always validate and sanitize user input when using queries.

---

## 🔹 7. Common Namespaces in ADO.NET
- `System.Data`
- `System.Data.SqlClient`
- `System.Data.OleDb`
- `System.Data.OracleClient` (deprecated)

---

## 📚 References
- [Microsoft Docs on ADO.NET](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/)
- [ADO.NET Tutorial - TutorialsPoint](https://www.tutorialspoint.com/ado.net/index.htm)

---

✅ Keep exploring to learn about Stored Procedures, LINQ to SQL, Entity Framework, and more!
