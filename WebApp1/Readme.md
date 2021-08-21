In this Project I have used a layered approach for MVC app.
The first layers is Controller layer, which has HomeController which handles all the requests. It has reference of both the other layers added into it.
The second layer is DB layer which using Entity Framework Database first approach and connects our database with the project. It has reference of Model layer added too.
The third layer is Model layer. This layer intracts with the DB Layer and passes the view to the controller.

For Adding Reference :- Goto Refernces of the Project and if it is another layer select it from Project tab and if it is new library to be added like (Entity or Identity etc) then Use Nuget Package manager to install it from Browse tab

Read the comments in App.Config of DB layer and Web.Config of Controller layer. In EmployeeRepository class file in DBOperations folder in DB layer and in HomeController for better understanding.

I have taken all the help from Nitish Sir WebGentle Youtube Channel.
