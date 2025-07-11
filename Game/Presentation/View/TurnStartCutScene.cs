using Godot;
using System.Threading.Tasks;

public partial class TurnStartCutScene : CanvasLayer
{
    private Label _messageLabel = default!;

    public override void _Ready()
    {
        _messageLabel ??= GetNode<Label>("MessageLabel");
    }

    public async Task Play(string message)
    {
        _messageLabel.Text = message;

        // _animationPlayer.Play("fade_in");
        // await ToSignal(_animationPlayer, "animation_finished");

        await Task.Delay(2000);

        // _animationPlayer.Play("fade_out");
        // await ToSignal(_animationPlayer, "animation_finished");

        QueueFree();
    }
}
