using System.Net.Http;
using System.Threading.Tasks;
using TimeSheetDesktopUI.Library.Models;

namespace TimeSheetDesktopUI.Library.API
{
    public interface IAPIHelper
    {
        HttpClient APIClient { get; }

        Task<AuthenticatedUser> Authenticate(string userName, string password);
        Task GetLoggedInUserInfo(string token);
    }
}