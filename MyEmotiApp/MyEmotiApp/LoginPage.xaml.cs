namespace MyEmotiApp;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnRegiBtnClicked(object? sender, EventArgs e)
    {
        var username = UsernameEntry.Text;
        var password = PasswordEntry.Text;

        if (await App.UserRepo.Register(username, password))
            await DisplayAlert("You registered!", "Ok", "Cancel");
        else await DisplayAlert("Error while registering!", "Ok", "Cancel");

    }

    private async void OnLoginBtnClicked(object? sender, EventArgs e)
    {
        var username = UsernameEntry.Text;
        var password = PasswordEntry.Text;

        var user = await App.UserRepo.Login(username, password);
        if(user.Username!=null)
            await DisplayAlert($"Welcome, {user.Username}", "Ok", "Cancel");
    }
}