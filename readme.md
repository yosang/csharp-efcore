# Project

This practice-project demonstrates how we can configure `Entity Framework Core` with `.NET 9` to connect to a `MySQL` database and perform some basic `CRUD` operations.

This project is built using the NuGet package: `MySql.EntityFrameworkCore`.

**Database Prerequisites**
- This project assumes you have a `MySQL` server instance running.
- Create a database named `testdb`.
- Create a user named `testuser` identified by password `p@ssword`.
- Grant `testuser` the necessary permissions on `testdb`.
- If you prefer to use an existing db and user, feel free to change the connection strig on line 27 in [HardWareStoreContext](Data/HardWareStoreContext.cs)

# The Repository Pattern
- Adds separation of concerns
- Adds abstraction over EF Core
- Adds Interface-based design
- Adds cleaner main program

# Usage

1. Clone the repo
2. Install the necessary `Microsoft.EntityFrameworkCore` package files with `dotnet restore`.
3. Run it with `dotnet run`
# Author
[Yosmel Chiang](https://github.com/yosang)