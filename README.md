# PersonalNotes

## Client
In order to install client dependencies, you should access "PersonalNotesClient" folder and run "npm install" command.
Once you have all done, just run the project using "ng serve". It will start the server on port "4200".

### Features
The client has an interceptor to send the JWT every time it communicates with the API. Also, it has a guard that does not allow unlogged users to access private events. It also display the errors to the users, so they can be aware about what went wrong in the operations.

## Server
To have the server up and running, you should just restore all the package dependencies for PersonalNotes folder (it will probably happen when building the project).
This project will run on port "44353".
The database used is SQL local database. To create the database for the project, in the Nuget Package Manager console, run the command "Update-Database".
There are some unit tests that are testing services, that contains the main business logic.

###
The server follows an Hexagonal architecture, following the template pattern to design the use cases and also some Facade patterns in some parts of the code. Once you run it, you can do fast tests via Swagger documentation. It uses JWT authentication, protecting all routes that are not allows for general public.
