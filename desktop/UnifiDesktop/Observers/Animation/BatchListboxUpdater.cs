using System.Windows.Forms;
using UnifiCommands.CommandInfo;

namespace Unifi.Observers.Animation
{
    /// <summary>
    /// Updates list item text to indicate if it's running or finished running.
    /// </summary>
    internal class BatchListboxUpdater : IObserver
    {
        /// <summary>
        /// Prefix indicating the command has finished running.
        /// </summary>
        private const string PrefixFinished = "✓";

        /// <summary>
        /// Prefix characters that constitute an animation.
        /// </summary>
        private static readonly string[] PrefixRunning = { "|", "/", "-", "\\"};
        private int _animationIndex;
        
        private FullCommandInfo _currentCommand;

        private readonly ListBox _listBox;

        private readonly System.Timers.Timer _statusTimer;

        public BatchListboxUpdater(ListBox listBox)
        {
            _listBox = listBox;
            _statusTimer = new System.Timers.Timer(300);
            _statusTimer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            if (_currentCommand == null) return;

            _animationIndex++;
            if (_animationIndex >= PrefixRunning.Length) _animationIndex = 0;

            int len = PrefixRunning[_animationIndex].Length;
            _currentCommand.DisplayText = PrefixRunning[_animationIndex] + _currentCommand.DisplayText.Substring(len);

            RefreshListBox();
        }

        public void StatusUpdateAtCommandStart(FullCommandInfo info)
        {
            if (_listBox.Items.Count <= 0) return;

            _currentCommand = GetCommandInfo(info);
            if (_currentCommand == null) return;

            _currentCommand.DisplayText = UpdateDisplayText(_currentCommand.DisplayText, PrefixRunning[_animationIndex], PrefixRunning[_animationIndex]);
            RefreshListBox();

            _statusTimer.Start();
        }

        public void StatusUpdateAtCommandEnd(FullCommandInfo info)
        {
            if (_listBox.Items.Count <= 0) return;

            _currentCommand.DisplayText = UpdateDisplayText(_currentCommand.DisplayText,PrefixRunning[_animationIndex], PrefixFinished);
            RefreshListBox();

            _statusTimer.Stop();
        }

        private string UpdateDisplayText(string displayText, string oldPrefix, string newPrefix)
        {
            int len = oldPrefix.Length + 1; // The length includes a space after the prefix.
            if (displayText.StartsWith(oldPrefix))
                return newPrefix + " " + displayText.Substring(len);

            return newPrefix + " " + displayText;
        }

        private void RefreshListBox()
        {
            _listBox.Invoke(new MethodInvoker(() => _listBox.Refresh()));
        }

        private FullCommandInfo GetCommandInfo(FullCommandInfo info)
        {
            foreach (var item in _listBox.Items)
            {
                if (item is FullCommandInfo c && c.DisplayText.Equals(info.DisplayText))
                {
                    return c;
                }
            }

            return null;
        }
    }
}
