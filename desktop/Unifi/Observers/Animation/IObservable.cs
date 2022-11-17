using UnifiCommands.Commands;

namespace Unifi.Observers.Animation
{
    /// <summary>
    /// Interface that registers BatchCommandExecutor as an observable so it can send command start and end notification
    /// to BatchListBoxUpdater.
    /// </summary>
    interface IObservable
    {
        void RegisterObserver(IObserver observer);
        
        void NotifyObserverCommandStart(CommandInfo info);

        void NotifyObserverCommandEnd(CommandInfo info);
    }

    /// <summary>
    /// Interface implemented by BatchListBoxUpdater so it can receive the command start and end notification
    /// and update the animation of a command.
    /// </summary>
    interface IObserver
    {
        void StatusUpdateAtCommandStart(CommandInfo info);
        
        void StatusUpdateAtCommandEnd(CommandInfo info);
    }
}
