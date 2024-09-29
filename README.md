
# Project Documentation

## Overview

This project is a WPF application designed for managing user information. It allows users to create, edit, and delete records in a database.

### Prerequisites

MySQL Database Server: Ensure you have MySQL installed.
Visual Studio: Recommended for running the WPF application.

### Setup Instructions

**1. Create the Database and clone repository**  
**1.1:** First clone the repository using the command:
```git
git clone -b teste-login --single-branch https://github.com/kevincamussi/study_c-.git
```

**1.2**: To create the database named users, execute the following SQL command in your MySQL environment:

```sql
CREATE DATABASE users;
```

**2. Create the usuarios Table**

After creating the database, use the following command to create the usuarios table:

```sql
USE users;

CREATE TABLE usuarios (
    id INT NOT NULL,
    nome VARCHAR(255),
    email VARCHAR(255),
    cidade VARCHAR(255),
    regiao VARCHAR(255),
    cep VARCHAR(20),
    pais VARCHAR(100),
    telefone VARCHAR(20),
    PRIMARY KEY (id)
);
```

**3. Running the Application**

**Open the Project:** Open the project in Visual Studio 2022.
**Build the Project:** Make sure to build the solution by going to Build > Build Solution.
**Start the Application:** Run the application by pressing F5 or clicking the Start button.

**4. Using the Application**

**Add User:** Enter the user details in the provided fields and click the "Add" button.  
**Edit User:** Select a user from the list, modify the details, and click "Edit" to save changes.  
**Delete User:** Select a user from the list and click the "Delete" button.  
 
**5. Notes**
Ensure that the MySQL service is running before starting the application.
Make sure to handle database connection errors appropriately.

**Conclusion**


This project serves as a simple user management system, allowing easy manipulation of user data stored in a MySQL database. If you encounter any issues, please refer to the troubleshooting section or contact the project maintainer.