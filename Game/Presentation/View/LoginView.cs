using DominionProtocol.Presentation.Presenter;
using DominionProtocol.Presentation.View;
using Godot;

public partial class LoginView : MarginContainer, ILoginView
{

    [Export] private LineEdit? _usernameField;
    [Export] private LineEdit? _passwordField;
    [Export] private Button? _signInButton;
    [Export] private Button? _signUpButton;
    [Export] private Button? _guestButton;
    [Export] private Label? _quickMessageLabel;

    private LoginPresenter _presenter = default!;

    public override void _Ready()
    {
        _presenter = PresenterFactory.CreateLoginPresenter(this);

        _signInButton!.Pressed += OnSignInPressed;
        _signUpButton!.Pressed += OnSignUpPressed;
        _guestButton!.Pressed += OnGuestPressed;
    }

    private void OnSignInPressed()
    {
        _presenter.OnSignInPressed(_usernameField!.Text, _passwordField!.Text);
    }

    private void OnSignUpPressed()
    {
        _presenter.OnSignUpPressed(_usernameField!.Text, _passwordField!.Text);
    }

    private void OnGuestPressed()
    {
        _presenter.OnGuestPressed();
    }

    public void ShowError(string message)
    {
        _quickMessageLabel.Text = message;
    }

    public void NavigateToMainMenu()
    {
        GetTree().ChangeSceneToFile("res://Game/Presentation/View/MainMenu.tscn");
    }

}
