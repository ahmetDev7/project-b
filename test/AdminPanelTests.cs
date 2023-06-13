using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

[TestClass]
public class AdminPanelTests
{
    [TestMethod]
    public void AddEmployeeAdminPanel()
    {
        AccountManager.AddUser(new User("employee2", "employee2@employee2.nl", "employee2", "employee", AccountManager.users.Last().UserId + 1));
        var employees = AccountManager.users.Where(employee => employee.Role == "employee");
        bool foundNewEmployee = employees.Any(e => e.UserName == "employee2");
        Assert.AreEqual(true, foundNewEmployee);
    }
}