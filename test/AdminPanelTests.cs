using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

[TestClass]
public class AdminPanelTests
{
    [TestMethod]
    public void AddEmployeeAdminPanel()
    {
        AccountManager.AddUser(new User("employee2", "employee2", "employee2@employee2.nl", "employee", AccountManager.users.Last().UserId + 1));
        var employees = AccountManager.users.Where(employee => employee.Role == "employee");
        bool foundNewEmployee = employees.Any(e => e.UserName == "employee2");
        Assert.AreEqual(true, foundNewEmployee);
    }

    [TestMethod]
    public void EditEmployeeAdminPanel_foundAccountbyEmail()
    {
        AccountManager.AddUser(new User("employee2", "employee2", "employee2@employee2.nl", "employee", AccountManager.users.Last().UserId + 1));
        var employees = AccountManager.users.Where(employee => employee.Role == "employee");
        bool foundEmployeeEmail = employees.Any(e => e.Mail == "employee2@employee2.nl");
        Assert.AreEqual(true, foundEmployeeEmail);
    }

    [TestMethod]
    public void EditEmployeeAdminPanel_SuccessfulEditEmployee()
    {
        string editEmployeeMail = "employee2@employee2.nl";

        string editEmployeeNameInsert = "employee3";
        string editEmployeeEmailInsert = "employee3@employee3.nl";
        string editEmployeePasswordInsert = "employee3";

        var foundAccount = AccountManager.users.FirstOrDefault(user => user.Mail == editEmployeeMail);
        AccountManager.users.Remove(foundAccount);
        AccountManager.RemoveUser(foundAccount);
        AccountManager.AddUser(new User(editEmployeeNameInsert, editEmployeePasswordInsert, editEmployeeEmailInsert, "employee", AccountManager.users.Last().UserId + 1));

        var employees = AccountManager.users.Where(employee => employee.Role == "employee");
        bool foundNewEmployee = employees.Any(e => e.UserName == "employee3");
        Assert.AreEqual(true, foundNewEmployee);
    }

    [TestMethod]
    public void DeleteEmployeeAdminPanel()
    {        
        string delEmployeeName = "employee3";
        string delEmployeeEmail = "employee3@employee3.nl";

        User foundAccount = AccountManager.users.FirstOrDefault(user => user.UserName == delEmployeeName && user.Mail == delEmployeeEmail);

        AccountManager.users.Remove(foundAccount);
        AccountManager.RemoveUser(foundAccount);

        var employees = AccountManager.users.Where(employee => employee.Role == "employee");
        bool foundDeletedEmployee = employees.Any(e => e.UserName == "employee3");

        Assert.AreEqual(false, foundDeletedEmployee);
    }
}