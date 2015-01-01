using RoomBooking.Business.Resources;
using RoomBooking.Core.Interfaces.Repositories;
using RoomBooking.Core.Interfaces.Services;
using RoomBooking.Core.Models;
using System;
using System.Collections.Generic;

namespace RoomBooking.Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private ILogService _logService;
        private INotificationService _notificationService;

        public UserService(IUserRepository repository, ILogService logService, INotificationService notificationService)
        {
            this._repository = repository;
            this._logService = logService;
            this._notificationService = notificationService;
        }

        public User Authenticate(string email, string password)
        {
            // Recupera o usuário
            var user = _repository.GetByEmailAndPassword(email, password);
            if (user == null)
                throw new Exception(ErrorMessages.InvalidEmailOrPassword);

            // Loga a ação
            _logService.Log(String.Format("Usuário {0} se conectou.", user.Email));

            // Retorna o resultado
            return user;
        }

        public void ChangePassword(string currentPassword, string newPassword, string confirmPassword, string email)
        {
            // Tenta recuperar o usuário
            var user = _repository.GetByEmailAndPassword(email, currentPassword);
            if (user == null)
                throw new Exception(ErrorMessages.InvalidEmailOrPassword);

            // Tenta alterar a senha
            user.SetPassword(newPassword, confirmPassword);            

            // Persiste as mudanças
            _repository.Update(user);

            // Loga a ação
            _logService.Log(String.Format("Usuário {0} alterou sua senha.", email));
        }

        public void CreateNewUser(string name, string email, IList<string> roles)
        {
            // Cria uma nova ação
            var user = new User(name, email);

            // Atribui os roles
            foreach (var role in roles)
                user.AddRole(new Role(role));

            // Persiste as informações
            _repository.Create(user);

            // Loga a ação
            _logService.Log(String.Format("Usuário {0} criado.", email));
        }

        public string ResetPassword(string email)
        {
            // Tenta recuperar o usuário
            var user = _repository.GetByEmail(email);
            if (user == null)
                throw new Exception(ErrorMessages.InvalidEmailOrPassword);

            // Tenta resetar a senha
            string password = user.ResetPassword();

            // Persiste as mudanças
            _repository.Update(user);

            // Loga a ação
            _logService.Log(String.Format("Usuário {0} alterou sua senha.", email));

            return password;
        }

        public void UpdateProfile(string name, string email)
        {
            // Tenta recuperar o usuário
            var user = _repository.GetByEmail(email);
            if (user == null)
                throw new Exception(ErrorMessages.InvalidEmailOrPassword);

            // Tenta alterar o nome
            user.ChangeName(name);

            // Persiste as mudanças
            _repository.Update(user);

            // Loga a ação
            _logService.Log(String.Format("Usuário {0} alterou sua senha.", email));
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
