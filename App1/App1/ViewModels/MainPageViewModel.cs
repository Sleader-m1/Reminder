using App1.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public readonly ILocalNotificationsService localNotificationsService;

        public ICommand ShowNotificationCommand { get; private set; }
        public MainPageViewModel()
        {
            Title = "App1";

            localNotificationsService = DependencyService.Get<ILocalNotificationsService>();
            ShowNotificationCommand = new DelegateCommand(ShowNotification);
        }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "App1";

            localNotificationsService = DependencyService.Get<ILocalNotificationsService>();
            ShowNotificationCommand = new DelegateCommand(ShowNotification);
        }

        private void ShowNotification()
        {
            localNotificationsService.ShowNotification("Напоминание!", "Вы находитесь рядом с местом напоминания", new Dictionary<string, string>());
        }
    }
}