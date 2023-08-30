# Online Help Desk System Documentation

## Table of Contents

1. Introduction
2. System Architecture
3. Onion Architecture Overview
4. Layers of Onion Architecture
   - 4.1 Presentation Layer
   - 4.2 Application Layer
   - 4.3 Domain Layer
   - 4.4 Infrastructure Layer
5. Implementation
6. Aim and Objective
7. Overview
8. Architectural Strategies
9. Administrator
10. Students
11. Faclity-head
12. Database Structure
13. Conclusion
14. References

---

## 1. Introduction

The Online Help Desk System is a web-based application designed to provide efficient customer support and issue resolution. This documentation outlines the system architecture and its implementation using the Onion Architecture pattern in ASP.NET Core. The Onion Architecture promotes separation of concerns and modular design to enhance maintainability, scalability, and testability of software applications.

## 2. System Architecture

The system follows the Onion Architecture, a variant of layered architecture, which emphasizes a clear separation of concerns and dependency flow. It consists of concentric layers, each having distinct responsibilities, and dependencies always point inwards. This minimizes coupling between layers and allows easy testing and modifications.

## 3. Onion Architecture Overview

The Onion Architecture consists of four primary layers:

1. **Presentation Layer**: This is the outermost layer that handles user interface interactions. It includes web controllers, views, and other UI-related components.

2. **Service Layer**: This layer contains application-specific logic and acts as an intermediary between the presentation and domain layers. It coordinates actions, performs validations, and handles data transformation.

3. **Domain Layer**: The domain layer represents the core business logic and entities. It encapsulates the business rules, validation logic, and domain objects.

4. **Infrastructure Layer**: This layer deals with external concerns such as data storage, database access, and external services. It contains implementations of repositories, data access, and other infrastructure-related components.

## 4. Layers of Onion Architecture

### 4.1 Presentation Layer

- Responsible for handling HTTP requests and generating responses.
- Contains controllers, view models, and UI-related logic.
- References the Application Layer.
- Has minimal business logic and delegates most tasks to the Application Layer.

### 4.2 Services Layer

- Orchestrates the application's use cases and workflows.
- Contains application services that handle user actions and interactions.
- Performs data validation, transformation, and coordination between different parts of the system.
- References both the Domain and Infrastructure Layers.

### 4.3 Domain Layer

- Represents the core business logic and entities.
- Contains domain models, business rules, and validation logic.
- Independent of other layers and has no external dependencies.

### 4.4 Infrastructure Layer

- Handles external concerns and technical details.
- Implements data access, repositories, caching, and other infrastructure services.
- Can integrate with databases, third-party APIs, and other external services.
- References the Domain Layer but is not referenced by any other layer.

## 5. Implementation

To implement the Online Help Desk System using Onion Architecture in ASP.NET Core, follow these steps:

1. **Create Solution and Projects**:
   - Create a new ASP.NET Core solution.
   - Add separate projects for each layer: Presentation, Application, Domain, and Infrastructure.

2. **Define Domain Models**:
   - In the Domain Layer, define the core domain models representing the entities and business logic of the system.

3. **Implement Application Services**:
   - In the Application Layer, implement application services that handle use cases and interact with domain models.
   - Application services coordinate actions, enforce business rules, and transform data.

4. **Implement Infrastructure Services**:
   - In the Infrastructure Layer, implement data access services, repositories, and external integrations.
   - Use Dependency Injection to inject infrastructure services into the Application Layer.

5. **Develop Controllers and Views**:
   - In the Presentation Layer, create controllers to handle HTTP requests and render views.
   - Controllers should use application services to perform actions and retrieve data.

6. **Dependency Injection Configuration**:
   - Configure Dependency Injection in the Startup class to inject dependencies through the layers.

7. **Testing**:
   - Write unit tests for each layer, focusing on testing individual components in isolation.
   - Use mocking frameworks to isolate dependencies and create controlled test scenarios.

8. **Deployment**:
   - Deploy the application to a web server, ensuring that the necessary infrastructure components (database, third-party services) are properly configured.


This documentation provides an overview of implementing the Online Help Desk System using the Onion Architecture pattern in ASP.NET Core. Remember that the architecture's effectiveness lies in its adherence to separation of concerns and maintaining a clear dependency flow between layers.
## 9. Aim of Project
 
This project is aimed at developing an Online Help Desk for the facilities in 
the campus. This is an Internet based application that can be accessed 
throughout the campus. This system can be used to automate the 
workflow of service requests for the various facilities in the campus. This is 
one integrated system that covers different kinds of facilities like classrooms, Labs, Hostels, Mess, Computer Center faculty club etc. Registered 
users (Students, Faculty-head, and Admin) will be able to log in a request 
for service for any of the supported facilities. These requests will be sent to 
the concerned people, who are also valid users of the system, to get 
them resolved. There are attractive features like online notice board, chat 
box, query resolution etc.
Ther are registered people in the system (students, faculty and admin). 
Some of them are responsible for maintaining the facilities (like, admin is 
responsible for keeping the records of all the queries and send it to 
particular faculty head, the students can make queries to any department 
faculty head, faculty-head, faculty head will responsible for answering all 
the queries sent by students or admin etc.

## 10. Overview:
• This is an Intrnal based application that can be accessed throughout the campus.
• This system can be used to automate the workflow of service requests for the various facilities 
in the campus.
• This is one integrated system that covers different kinds of facilities like class-rooms, 
labs, computer center, hostels faculty club etc.
• Registered users (Admin, Students and Faculty-heads) will be able to log in a request for service 
for any of the supported facilities.
•  We covers Three Department Admin , IT Department , ClassRoom

# 11. Architectural Strategies:
The following tools have been used to develop the system:
❖ MS SQL: is the database where all information/data related to requests records and 
logs are stored.
❖ C#: is programming language used to develop the system to enable it to be webbased application. C# is considered the link used to connect users to databases 
through a user-friendly interface. Additionally SQL server application was used as a 
local server to host C# file to generate them.
❖ Server: is the place that hosts all project code.
#12. Administrator:
i. Login to the first page.
ii. Create new faculty account.
iii. View all student details.
iv. View all faculty details.
v. Check request sent by the user.
vi. Forward request to the faculty as per requirement.
vii. View all queries.
viii. View new queries.
ix. Reply/delete queries.
x. Add new notice for students.
xi. Add new notice for faculty.
xii. Logout.

## 13. Students:
i. Register Him/Her.
ii. Login to the first page.
iii. Change the password after login into the system.
iv. Edit user details.
v. Create queries in the system.
vi. View the status of the query.
vii. View the list of queries created by him/her over the 
past.
viii. Edit and delete query created by him/her.
xi. Logout.

## 14. Facility-Heads:
i. Login to the first page.
ii. Change the password after login into the page..
iii. Edit details of his/her profile..
iv. View all queries.
v. View new queries..
vi. See the queries created by the users and assigned by the 
Admin.
vii. Work on the queries assigned to them.
viii. Reply/Remarks the query..
ix. View replied queries..
x. Add new notice for students.
xi. View all notice..
xii. Logout.

## 15. Database Structure
** Data Table Properties:
The System database is normalized and designed with the needed table that store 
the needed information inside columns. Also the need for developing the system 
capabilities and functionalities has been taken in to account.
#Database table created with the following structure:
1. Each table column is assigned with suitable data type.
2. Each table column is assigned with suitable data auto increment primary Key.
3. For each table a foreign key is assigned when necessary plus its constraint type on.
Delete and on Update
4. For each table an index and its type is assigned when necessary.
5. For each column a default value is set when necessary.

## 16. Conclusion

The Online Help Desk System implemented using Onion Architecture in ASP.NET Core follows a modular and maintainable design. The separation of concerns in different layers enhances testability and scalability. The architecture provides a clear structure for building complex applications while maintaining flexibility and adaptability.
The Online Help Desk Project is the small step to reduce the communication 
distance between the staff and the students.
As the growing use of computers and other electronic devices would mean the 
growing demand on rapid and quick technical support, this Help Desk Support 
System is carefully designed to fit with the rapid technical support. It not only 
helps reducing the time of recording and tracking inquires and problems 
traditionally, but also improves quality and accuracy of data produced by the 
system which can lead to more facilitation of decision making process in time.
OHD is designed to accommodate future upgrading and development without 
the need for building a new system to fit with the growing needs and demands 
of the system. Having this system hosted online means the ability of both 
technicians and administrator to track and respond to demands of students at 
any time beyond the boundaries and walls of college which add one more 
advantage to replacing the paper-based style
## 17. References
---Ahmer ALi
---
