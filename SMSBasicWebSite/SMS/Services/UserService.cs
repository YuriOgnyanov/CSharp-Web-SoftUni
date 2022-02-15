using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using SMS.Services.Contracts;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository repo)
        {
            this.repo = repo;
        }

        public (bool isAdded, string error) AddRegister(RegisterFormViewModel model)
        {
            bool isAdded = false;
            string error = null;

            var (isValid, validationError) = ValidateRegisterForm(model);

            if (!isValid) 
            {
                return (isValid, validationError);
            }

            var usernameExists = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .FirstOrDefault();

            var userEmail = repo.All<User>()
                .Where(e => e.Email == model.Email)
                .FirstOrDefault();

            if (usernameExists != null || userEmail != null) 
            {
                error = "A user with such a username or Email already exists!";
                return (isAdded, error);
            }

            Cart cart = new Cart();

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = HashPassword(model.Password),
                Cart = cart
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                isAdded = true;
            }
            catch (Exception)
            {
                error = "Could not save user in DB";
            }

            return (isAdded, error);
        }

        private string HashPassword(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }    

        public (bool isValid, string ErrorMessage) ValidateRegisterForm(RegisterFormViewModel model)
        {
            bool isValid = true;
            StringBuilder ErrorMessage = new StringBuilder();

            if (model == null) 
            {
                isValid = false;
                ErrorMessage.AppendLine("The registration is required!");
            }

            if (string.IsNullOrEmpty(model.Username) || model.Username.Length < 5 || model.Password.Length > 20)
            {
                isValid = false;
                ErrorMessage.AppendLine("The Username is required and must be between 5 and 20 charecters!");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                isValid = false;
                ErrorMessage.AppendLine("The Email is required!");
            }

            if (string.IsNullOrEmpty(model.Password) || model.Password.Length < 6 || model.Password.Length > 20)
            {
                isValid = false;
                ErrorMessage.AppendLine("The Password is required and must be between 6 and 20 charecters!");
            }

            if (string.IsNullOrEmpty(model.ConfirmPassword) || model.ConfirmPassword != model.Password)
            {
                isValid = false;
                ErrorMessage.AppendLine("Confirm password and password is not the same!");
            }

            return (isValid, ErrorMessage.ToString().TrimEnd());
        }

        public (bool isValidLogin, string userId) Login(LoginFormViewModel model)
        {
            bool isValidLogin = true;
            string userId = string.Empty;

            var userExists = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(p => p.Password == HashPassword(model.Password))
                .FirstOrDefault();

            if (userExists is null) 
            {
                isValidLogin = false;
                return (isValidLogin, userId);
            }

            userId = userExists.Id;

            return (isValidLogin, userId);
        }

        public string GetUsername(string userId)
        {
            var usernameId = repo.All<User>()
                .Where(i => i.Id == userId)
                .Select(u => u.Username)
                .FirstOrDefault();

            return usernameId;
        }
    }
}
