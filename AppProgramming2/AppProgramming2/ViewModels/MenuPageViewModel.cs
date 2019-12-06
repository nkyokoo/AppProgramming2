using System.Threading.Tasks;
using System.Windows.Input;
using AppProgramming2.Models;
using AppProgramming2.ViewModels;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppProgramming2.Services
{
    public class MenuPageViewModel : BaseViewModel
    {
        private User _user;

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private Authentication auth;
        public MenuPageViewModel()
        {
            
            auth = new Authentication();
            User = new User();
        }
        
        public ICommand GetUserCommand => new Command(GetUser);

        private async void GetUser()
        {
            var token = await SecureStorage.GetAsync("auth_token");
             string user = await auth.getUser(token);
             User = JsonConvert.DeserializeObject<User>(user);
        }
    }
}