using System.Windows.Threading;
namespace WPFStartupLibrary;
//still needed this class because the portable music processes require this.  otherwise, gives threading error.
public class WPFThread : IUIThread
{
    private readonly Dispatcher _dispatcher;
    private void ValidateDispatcher()
    {
        if (_dispatcher == null)
            throw new InvalidOperationException("Not initialized with dispatcher.");
    }
    public WPFThread()
    {
        _dispatcher = Dispatcher.CurrentDispatcher;
    }
    private bool CheckAccess()
    {
        return _dispatcher == null || _dispatcher.CheckAccess();
    }
    void IUIThread.BeginOnUIThread(Action action)
    {
        ValidateDispatcher();
        _dispatcher.BeginInvoke(action);
    }
    void IUIThread.OnUIThread(Action action)
    {

        if (CheckAccess())
            action();
        else
        {
            Exception? exception = null;
            void method()
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }
            _dispatcher.Invoke(method);
            if (exception != null)
            {
                throw new System.Reflection.TargetInvocationException("An error occurred while dispatching a call to the UI Thread", exception);
            }
        }
    }
    Task IUIThread.OnUIThreadAsync(Func<Task> action)
    {
        ValidateDispatcher();
        return _dispatcher.InvokeAsync(action).Task.Unwrap();
    }
}