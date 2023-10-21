# HostelManagementSystem (In .NET MVC Core)

### Purpose


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
