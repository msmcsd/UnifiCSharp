using System.Windows.Forms;
using UnifiCommands.CommandInfo;

namespace Unifi.Observers.Animation
{
    /// <summary>
    /// Updates list item text to indicate if it's running or finished running.
    /// </summary>
    internal class BatchListViewUpdater : IObserver
    {
        /// <summary>
        /// Prefix indicating the command has finished running.
        /// </summary>
        private const string PrefixFinished = "✓";

        /// <summary>
        /// Prefix characters that constitute an animation.
        /// </summary>
        private static readonly string[] PrefixRunning = { "|", "/", "-", "\\" };
        private int _animationIndex;

        private ListViewItem _currentItem;
        private readonly ListView _listView;

        private readonly System.Timers.Timer _statusTimer;

        public BatchListViewUpdater(ListView listView)
        {
            _listView = listView;
            _statusTimer = new System.Timers.Timer(300);
            _statusTimer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            if (_currentItem == null) return;

            _animationIndex++;
            if (_animationIndex >= PrefixRunning.Length) _animationIndex = 0;

            UpdateAnimationText(PrefixRunning[_animationIndex]);
        }

        public void StatusUpdateAtCommandStart(FullCommandInfo info)
        {
            if (_listView.Items.Count <= 0) return;

            _currentItem = GetListViewItem(info);
            if (_currentItem == null) return;

            UpdateAnimationText(PrefixRunning[_animationIndex]);
            _statusTimer.Start();
        }

        public void StatusUpdateAtCommandEnd(FullCommandInfo info)
        {
            if (_listView.Items.Count <= 0) return;

            UpdateAnimationText(PrefixFinished);
            _statusTimer.Stop();
        }

        private void UpdateAnimationText(string newText)
        {
            _listView.Invoke(new MethodInvoker(() => _currentItem.SubItems[0].Text = newText));
        }

        private ListViewItem GetListViewItem(FullCommandInfo info)
        {
            foreach (ListViewItem item in _listView.Items)
            {
                if (item.SubItems[1].Text.Equals(info.DisplayText, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    return item;
                }
            }

            return null;
        }
    }
}
