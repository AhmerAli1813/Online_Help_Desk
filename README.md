# Online_Help_Desk
The project titled "Online help desk" (OHD) is using MS SQL Server, C# with 
onion Architecture.
# Onion-Architecture
Onion Architecture is based on the inversion of control principle. 
Onion Architecture is comprised of multiple concentric layers interfacing
with each other towards the core that represents the domain. 
The architecture does not depend on the data layer as in classic multi-tier architectures but on the actual domain models.
# Domain-Entity-Layer
Domain Entity Layer deepest  level of the Onion Architecture Containing all Application Domain Entities
# Repository-Pattern
Repository Layer (Infrastructure)
The repository layer is between the Services and the model object. All Database migration and application data context object communication occurs here. It consists of a read & writes data access pattern for the database
# Service APIs
Services Layers
Services Layers Consists of exposable APIs, and are responsible for the communication between the Repository Layers and the main project. These layers also contain an entity business logic and the interface is maintained stand-for from the implementation loose coupling and separation.
# UI Main-Project
The user interface (UI) is nothing more than the front-end program that communicates with ApIs (Services)

#Aim of Project
 
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

# Overview:
• This is an Intrnal based application that can be accessed throughout the campus.
• This system can be used to automate the workflow of service requests for the various facilities 
in the campus.
• This is one integrated system that covers different kinds of facilities like class-rooms, 
labs, computer center, hostels faculty club etc.
• Registered users (Admin, Students and Faculty-heads) will be able to log in a request for service 
for any of the supported facilities.
•  We covers Three Department Admin , IT Department , ClassRoom

# Architectural Strategies:
The following tools have been used to develop the system:
❖ MS SQL: is the database where all information/data related to requests records and 
logs are stored.
❖ C#: is programming language used to develop the system to enable it to be webbased application. C# is considered the link used to connect users to databases 
through a user-friendly interface. Additionally SQL server application was used as a 
local server to host C# file to generate them.
❖ Server: is the place that hosts all project code.
# Administrator:
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

# Students:
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

# Facility-Heads:
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

# Database Structure
#Data Table Properties:
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
