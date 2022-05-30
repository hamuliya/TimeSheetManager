using System;

namespace TimeSheetDesktopUI.Library.Models
{
    public interface ILoggedInUserModel
    {
        string Cellphone { get; set; }
        DateTime CreateDate { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
        string Token { get; set; }
    }
}