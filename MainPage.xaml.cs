using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RightClick
{
    public partial class MainPage : ContentPage
    {
        public ICommand RightClickCommand { get; set; }
        public MainPage()
        {
            InitializeComponent();
            MyTab.ItemSource = new ObservableCollection<string>(new()
            {
                "Test 1",
                "Test 2",
                "Test 3"
            });
            RightClickCommand = new Command(RightClick);
            MyTab.RightClick = RightClickCommand;
        }

        async void RightClick()
        {
            await AppShell.Current.DisplayAlert("Warning!", "Mouse right clicked!", "Ok");
        }
    }

}
