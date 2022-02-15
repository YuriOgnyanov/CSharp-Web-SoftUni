using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.Contracts
{
    public interface IUserService
    {
        (bool isValid, string ErrorMessage) ValidateRegisterForm(RegisterFormViewModel model);

        (bool isAdded, string error) AddRegister(RegisterFormViewModel model);

        (bool isValidLogin, string userId) Login(LoginFormViewModel model);

        string GetUsername(string userId);
    }
}
