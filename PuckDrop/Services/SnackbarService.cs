using MudBlazor;

namespace PuckDrop.Services;

public interface ISnackbarService
{
    public void AddSuccess(string message, Action<SnackbarOptions>? configure = null, string? key = null);
    public void AddError(string message, Action<SnackbarOptions>? configure = null, string? key = null);
    public void AddInfo(string message, Action<SnackbarOptions>? configure = null, string? key = null);
}
public class SnackbarService : ISnackbarService
{
    private readonly ISnackbar _snackbar;

    public SnackbarService(ISnackbar snackbar)
    {
        _snackbar = snackbar;
    }

    public void AddSuccess(string message, Action<SnackbarOptions>? configure = null, string? key = null)
    {
        _snackbar.Add(message, Severity.Success, configure, key);
    }

    public void AddError(string message, Action<SnackbarOptions>? configure = null, string? key = null)
    {
        _snackbar.Add(message, Severity.Error, configure, key);
    }

    public void AddInfo(string message, Action<SnackbarOptions>? configure = null, string? key = null)
    {
        _snackbar.Add(message, Severity.Info, configure, key);
    }
}
