using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using Microsoft.Extensions.Configuration;
using MobilityScm.Utilerias;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Next.Utils.Enums;
using Next.Utils.Security;
using NextApi.Models.Models;
using NextBO.DataModel;
using NextBO.Wpf.Properties;
using NextBO.Wpf.ViewModels;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using static Next.Utils.Enums.Enums;

namespace NextBO.Wpf
{
    /// <summary>
    /// Interface of the service that will keep de login information in app
    /// </summary>
    public interface IUserSessionService
    {
        LoginViewModel LoggedUser { get; set; }

        string LastUserLogged { get; set; }

        void Login(LoginViewModel model, IDialogService loginDialog, INextBOUnitOfWork unitOfWork);

    }
    /// <summary>
    /// Service that will keep de login information in app
    /// </summary>
    public class UserSessionService : ServiceBase, IUserSessionService
    {


        private LoginViewModel _loggedUser { get; set; }

        /// <summary>
        /// User Logged in app
        /// </summary>
        public LoginViewModel LoggedUser { get => _loggedUser; set => _loggedUser = value; }
        /// <summary>
        /// Last userName logged, saved in settings of the app.
        /// </summary>
        public string LastUserLogged { get => Settings.Default.LastLoggedUser; set { Settings.Default.LastLoggedUser = value; Settings.Default.Save(); } }

        public string CompanyImage { get => Settings.Default.CompanyImage; set { Settings.Default.CompanyImage = value; Settings.Default.Save(); } }

        /// <summary>
        /// User wants to login
        /// </summary>
        /// <param name="model">POCO created model</param>
        /// <param name="loginDialog">Dialog to show</param>
        /// <param name="unitOfWork">Unit of Work</param>
        public void Login(LoginViewModel model, IDialogService loginDialog, INextBOUnitOfWork unitOfWork)
        {
            LoggedUser = model;
            if (!ShowLoginDialog(loginDialog, unitOfWork))
            {
                //System.Windows.Application.Current.Shutdown();
                Environment.Exit(0);
            };


        }

        /// <summary>
        /// Show login view
        /// </summary>
        /// <param name="loginDialog"></param>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        private bool ShowLoginDialog(IDialogService loginDialog, INextBOUnitOfWork unitOfWork)
        {

            _loggedUser.UserLogin = LastUserLogged;
            _loggedUser.CompanyImage = CompanyImage;
            _loggedUser.AppVersion = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            _loggedUser.Password = string.Empty;

            var okCommand = new UICommand
            {
                Caption = "Aceptar",
                IsCancel = false,
                IsDefault = true,
                Command = new DelegateCommand<CancelEventArgs>(x => { }, x => !string.IsNullOrEmpty(_loggedUser.UserLogin) && !string.IsNullOrEmpty(_loggedUser.Password))
            };

            var cancelCommand = new UICommand
            {
                Caption = "Salir",
                IsCancel = true,
                IsDefault = false,
            };

            var result = loginDialog.ShowDialog(new List<UICommand> { okCommand, cancelCommand }, "Login", _loggedUser);
            if (result == cancelCommand)
                return false;

            while (!Autenticate(unitOfWork))
            {
                result = loginDialog.ShowDialog(new List<UICommand> { okCommand, cancelCommand }, "Login", _loggedUser);
                if (result == cancelCommand)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Autenticate method for logged user
        /// </summary>
        /// <param name="unitOfWork">unir of work</param>
        /// <returns></returns>
        private bool Autenticate(INextBOUnitOfWork unitOfWork)
        {

            //var message = ValidateLicense();

            var dbUser = unitOfWork.GetUserByLogin(new User { UserLogin = _loggedUser.UserLogin });

            //if (!string.IsNullOrEmpty(message))
            //{
            //    LoggedUser.AutenticationMessage = message;
            //    return false;
            //}

            if (dbUser != null)
            {
                var parameter = new Parameter { ParameterGroup = "Image", Name = "CompanyImage" };
                parameter = unitOfWork.GetParameter(parameter);

                if (dbUser.IsActive == 0)
                {
                    LoggedUser.AutenticationMessage = GetStringValue(Next.Enums.Enums.MessageError.LockedError);
                    return false;
                }

                if (parameter != null && !string.IsNullOrEmpty(parameter.Value))
                {
                    CompanyImage = parameter.Value;
                }

                LastUserLogged = LoggedUser.UserLogin;
                LoggedUser.Name = dbUser.Name;
                LoggedUser.Email = dbUser.Email;
                LoggedUser.Image = dbUser.Image;
                LoggedUser.Id = dbUser.Id;
                LoggedUser.RoleId = dbUser.RoleId;
                LoggedUser.RoleName = dbUser.Role?.Name;
                LoggedUser.AppVersion = " Versión: "+ Assembly.GetExecutingAssembly().GetName().Version.ToString();
                LoggedUser.AutenticationMessage = GetStringValue(Next.Enums.Enums.MessageLogin.Correct);

                return true;
            }
            else
            {
                LoggedUser.AutenticationMessage = GetStringValue(Next.Enums.Enums.MessageLogin.Incorrect);
                return false;
            }
        }


        private string ValidateLicense()
        {
            var message = string.Empty;
            try
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                var conf = builder.Build();

                string MacAddres = GetMacAddress();
                string UrlApi = Encrypt.DecryptText(conf.GetSection("URL_API").GetSection("url").Value);
                string Parameters = $"(loginId='{_loggedUser.UserLogin}',password='{_loggedUser.Password}'" +
                    $",codeApp='{GetStringValue(Next.Enums.Enums.CodeApp.Next)}',deviceId='{MacAddres}')";
                string Url = $"{UrlApi}{GetStringValue(ApiOptions.ValidarCredenciales)}{Parameters}";

                var httpResult = Rest.ExecuteGet(Url);
                var json = JObject.Parse(httpResult);
                if(json["error"] == null)
                {
                    return message;
                }

                var error = json["error"].ToString();

                if (!string.IsNullOrEmpty(error))
                {
                    var jsonError = JObject.Parse(error);
                    message = jsonError["message"].Value<string>();
                }
                message = TranslateMessageErrorOfApi(message);
            }
            catch (WebException ex)
            {
                Stream stream = ex.Response.GetResponseStream();
                var response = string.Empty;
                if (stream != null)
                {
                    var reader = new StreamReader(stream);
                    response = reader.ReadToEnd();
                }

                if (!string.IsNullOrEmpty(response))
                {
                    var jsonDeError = JObject.Parse(response);
                    message = jsonDeError["error"]["message"].Value<string>();
                    message = TranslateMessageErrorOfApi(message);
                }
            }
            catch (Exception ex)
            {
                message = GetStringValue(Next.Enums.Enums.MessageError.LicenseError) + ex.Message;
            }
            return message;
        }

        private string GetMacAddress()
        {
            foreach (var address in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (address.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && address.OperationalStatus == OperationalStatus.Up)
                {
                    return address.GetPhysicalAddress().ToString();
                }
                else if (address.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && address.OperationalStatus == OperationalStatus.Up)
                {
                    return address.GetPhysicalAddress().ToString();
                }
            }
            return string.Empty;
        }

        public string TranslateMessageErrorOfApi(string message)
        {
            if (message == GetStringValue(MessageErrorOfApi.ContraseñaIncorrecta))
            {
                message = GetStringValue(MessageErrorOfApiTranslated.ContraseñaIncorrecta);
            }
            else if (message == GetStringValue(MessageErrorOfApi.EmpresaBloqueada))
            {
                message = GetStringValue(MessageErrorOfApiTranslated.EmpresaBloqueada);
            }
            else if (message == GetStringValue(MessageErrorOfApi.LicenciaBloqueada))
            {
                message = GetStringValue(MessageErrorOfApiTranslated.LicenciaBloqueada);
            }
            else if (message == GetStringValue(MessageErrorOfApi.LicenciaExpirada))
            {
                message = GetStringValue(MessageErrorOfApiTranslated.LicenciaExpirada);
            }
            else if (message == GetStringValue(MessageErrorOfApi.SinAcceso))
            {
                message = GetStringValue(MessageErrorOfApiTranslated.SinAcceso);
            }
            else if (message == GetStringValue(MessageErrorOfApi.UsuarioBloqueado))
            {
                message = GetStringValue(MessageErrorOfApiTranslated.UsuarioBloqueado);
            }
            return message;
        }

    }
}
