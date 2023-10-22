# HostelManagementSystem (In .NET MVC Core)

### Purpose

  Our System provide structured user interface & Services for hostel so they can easily manage students details in the system with rooms that is assigned to the student.We have implemented **Role Based authentication** using **Identity**.

### Roles & Funcationality 

#### Admin 

#### Student 



### How to Run this project

Clone this Repository

```
git clone https://github.com/DigitalGit2003/HostelManagementSystem.git
```

#### appsettings.json

```json
"ConnectionStrings": {
  "ConnectionName": "server=SERVERNAME;database=DATABASENAME;Integrated Security=true;"
},
```

#### Nuget Packages

```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design

Microsoft.AspNetCore.Identity.EntityFrameworkCore
```

#### Create Database Model
> You can go with only **update-database** if you have Migrations folder

```
add-migration "message"
update-database
```

### Tech Stack

| Application        | Tech                  |
| ------------------ | --------------------- |
| Backend / Frontend | ASP .NET 7 / Boostrap |
| DataBase           | SQL (SSMS)            |

> Team members

<a href="https://github.com/DigitalGit2003/HostelManagementSystem
/graphs/contributors">
<img src="https://contrib.rocks/image?repo=DigitalGit2003/HostelManagementSystem" />
</a>
