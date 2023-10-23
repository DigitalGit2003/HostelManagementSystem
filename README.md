# HostelManagementSystem (In .NET MVC Core)

## Purpose

Our System provide structured user interface & Services for hostel so they can easily manage students details in the system with rooms that is assigned to the student.We have implemented **Role Based authentication** using **Identity** of **EntityFrameworkCore(.NET MVC Core)** .

## Roles & Functionality

### Admin

> Add & Manage Rooms

- Admin will be able to create room by providing room details.
- Admin will be able to change the data of a room and also will be able to delete a room.

> Register student & assign room to that student

- If a student want to have a room in our hostel, he will need to approach admin. Admin will enter the data given by student and assign the room to that student as per his choice or room availability.
- student will be given password by admin at the time of registration.

### Student

> View Profile

- Student will be able to see the profile in which room details of that student will be displayed along will all room-mates.

## How to Run this project ?

> Clone this Repository

```
git clone https://github.com/DigitalGit2003/HostelManagementSystem.git
```

### 1. appsettings.json

```json
"ConnectionStrings": {
  "ConnectionName": "server=SERVERNAME;database=DATABASENAME;Integrated Security=true;"
},
```

### 2. Install Nuget Packages

```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design

Microsoft.AspNetCore.Identity.EntityFrameworkCore
```

### 3. Create Database Model

> You can go with only **update-database** if you have **Migrations** folder

```
add-migration "message"
update-database
```

## Tech Stack

| Application        | Tech                  |
| ------------------ | --------------------- |
| Backend / Frontend | ASP .NET 7 / Boostrap |
| DataBase           | SQL (SSMS)            |

> Team members

<center>
<table>
  <tr>
    <td align="center">
        <a href="https://github.com/DigitalGit2003/HostelManagementSystem
/graphs/contributors">
            <img src="https://github.com/DigitalGit2003.png" width="100px;" alt=""/>
            <br />
            <sub><b>Gautam Lathiya</b></sub>
        </a>
        <br />
    </td>
    <td align="center">
        <a href="https://github.com/DigitalGit2003/HostelManagementSystem
/graphs/contributors">
            <img src="https://github.com/Sandip-Kanzariya.png" width="100px;" alt=""/>
            <br />
            <sub><b>Sandip Kanzariya</b></sub>
        </a>
        <br />
    </td>
    </tr>
</table>
</center>