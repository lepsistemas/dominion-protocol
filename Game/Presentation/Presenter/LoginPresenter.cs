namespace DominionProtocol.Presentation.View;

public class LoginPresenter
{
    private readonly ILoginView _view;

    public LoginPresenter(ILoginView view)
    {
        _view = view;
    }

    public void OnSignInPressed(string username, string password)
    {
        var success = true;
        if (success)
            _view.NavigateToMainMenu();
        else
            _view.ShowError("Credenciais inválidas.");
    }

    public void OnSignUpPressed(string username, string password)
    {
        var success = true;
        if (success)
            _view.NavigateToMainMenu();
        else
            _view.ShowError("Não foi possível cadastrar.");
    }

    public void OnGuestPressed()
    {
        _view.NavigateToMainMenu();
    }
}
