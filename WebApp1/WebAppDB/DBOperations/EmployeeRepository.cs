using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebAppDB.DBOperations
{
    public class EmployeeRepository // this should be declared public
    {
        // This function is used to add Employees and their records in the database.
        public int AddEmployee(EmployeModel model)
        {
            using(var context = new EmployeeDBEntities())
            {
                Employee emp = new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Code = model.Code
                };

                // Here we have used the foriegn Key Address to map value of address with Employee
                // Also this saves data in Both Address and Employee table at the same time.
                if(model.Address != null)
                {
                    emp.Address = new Address()
                    {
                        Address1 = model.Address.Address1,
                        State = model.Address.State,
                        Country = model.Address.Country
                    };
                }

                context.Employee.Add(emp);

                context.SaveChanges();

                return emp.ID;
            }
        }

        // This fuction returns record of all the employees in the database
        public List<EmployeModel> GetAllEmployees()
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employee.Select(x => new EmployeModel() // Here Employee is the name of our database from which the data is taken and EmployeModel is the name of Model class
                {
                    ID = x.ID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Code = x.Code,
                    AddressID = x.AddressID,
                    // For obtaining address we can either use Navigational property or use Join for tables
                    Address = new AddressModel() // This way is called Navigational way for fetching data
                    {
                        ID = x.Address.ID,
                        Address1 = x.Address.Address1,
                        Country = x.Address.Country,
                        State = x.Address.State
                    }
                }).ToList();

                return result;
            }
        }

        // function to check details of a particular employee
        public EmployeModel GetEmployee(int id)
        {
            using (var context = new EmployeeDBEntities())
            {
                var result = context.Employee
                    .Where(x=> x.ID == id)
                    .Select(x => new EmployeModel() // Here Employee is the name of our database from which the data is taken and EmployeModel is the name of Model class
                    {
                        ID = x.ID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        Code = x.Code,
                        AddressID = x.AddressID,
                        // For obtaining address we can either use Navigational property or use Join for tables
                        Address = new AddressModel() // This way is called Navigational way for fetching data
                        {
                            ID = x.Address.ID,
                            Address1 = x.Address.Address1,
                            Country = x.Address.Country,
                            State = x.Address.State
                        }
                    }).FirstOrDefault();

                return result;
            }
        }

        //function to update details of an employee
        public bool UpdateEmployee(int id, EmployeModel model)
        {
            using (var context = new EmployeeDBEntities()) // here we created an instance of Database entity
            {
                // Here we can also use Where clause for condition, but FirstOrDefault is faster than Where, coz it selects the first records and returns unlike Where clause
                var employee = context.Employee.FirstOrDefault(x => x.ID == id); // We have selected first record in our table inside the database where our criteria meet
                if(employee != null)
                {
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;
                    employee.Email = model.Email;
                    employee.Code = model.Code;
                    //In this we didn't updated address, same we have removed it in the View too.
                }

                context.SaveChanges();
                return true;
            }
        }

        //function to delete the record of an employee
        public bool DeleteEmployee(int id)
        {
            using(var context = new EmployeeDBEntities())
            {
                // Below written way hits Database for two times, first when getting employee, second when removing employee and saving changes.
                // This can increase the burden on DB and make it slow.
                //var employee = context.Employee.FirstOrDefault(x => x.ID == id);
                //if(employee != null)
                //{
                //    context.Employee.Remove(employee);
                //    context.SaveChanges();
                //    return true;
                //}

                // Single hit way - faster
                var emp = new Employee() // instance of table in which record has to be deleted
                {
                    ID = id
                };
                // Using EntityState to Delete that record from the table
                context.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
    }
}
