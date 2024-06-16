using BusinessObjects;
using System.Drawing.Printing;

namespace Services
{
    public interface IAccountService
    {
        AccountMember GetAccountById(string accountID);
    }
}
