using RoomBooking.Business.Resources;
using RoomBooking.Business.Security;
using RoomBooking.Core.Interfaces.Repositories;
using RoomBooking.Core.Interfaces.Services;
using RoomBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoomBooking.Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private ILogService _logService;
        private INotificationService _notificationService;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, ILogService logService, INotificationService notificationService)
        {
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            this._logService = logService;
            this._notificationService = notificationService;
        }

        public void ChangePassword(string currentPassword, string newPassword, string confirmPassword, string email)
        {
            // Tenta recuperar o usuário
            var user = _userRepository.GetByEmailAndPassword(email, EncryptHelper.Encrypt(currentPassword));
            if (user == null)
                throw new Exception(ErrorMessages.InvalidEmailOrPassword);

            // Tenta alterar a senha
            user.SetPassword(EncryptHelper.Encrypt(newPassword), EncryptHelper.Encrypt(confirmPassword));

            // Persiste as mudanças
            _userRepository.Update(user);

            // Loga a ação
            _logService.Log(String.Format("Usuário {0} alterou sua senha.", email));
        }

        public User Register(string name, string email, string password, string confirmPassword, IList<string> roles)
        {
            // Cria um novo usuário
            var user = new User(name, email);

            // Recupera os roles
            var rolesFromDatabase = _roleRepository.GetAll();

            // Atribui os roles
            foreach (var role in roles)
            {
                user.AddRole(rolesFromDatabase.Where(x => x.Name.ToLower() == role.ToLower()).FirstOrDefault());
            }

            // Atribui a senha
            user.SetPassword(EncryptHelper.Encrypt(password), EncryptHelper.Encrypt(confirmPassword));

            // Persiste as informações
            _userRepository.Create(user);

            // Loga a ação
            _logService.Log(String.Format("Usuário {0} criado.", email));

            return user;
        }

        public string ResetPassword(string email)
        {
            // Tenta recuperar o usuário
            var user = _userRepository.GetByEmail(email);
            if (user == null)
                throw new Exception(ErrorMessages.InvalidEmailOrPassword);

            // Tenta resetar a senha
            string password = user.ResetPassword();

            // Envia por E-mail a senha
            _notificationService.SendNotification(user.Name, user.Email);

            // Encripta a senha
            user.SetPassword(EncryptHelper.Encrypt(password), EncryptHelper.Encrypt(password));

            // Persiste as mudanças
            _userRepository.Update(user);

            // Loga a ação
            _logService.Log(String.Format("Usuário {0} alterou sua senha.", email));

            return password;
        }

        public void UpdateProfile(string name, string email)
        {
            // Tenta recuperar o usuário
            var user = _userRepository.GetByEmail(email);
            if (user == null)
                throw new Exception(ErrorMessages.InvalidEmailOrPassword);

            // Tenta alterar o nome
            user.ChangeName(name);

            // Persiste as mudanças
            _userRepository.Update(user);

            // Loga a ação
            _logService.Log(String.Format("Usuário {0} alterou sua senha.", email));
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}
