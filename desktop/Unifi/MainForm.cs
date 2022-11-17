using Unifi.Forms;

namespace Unifi
{
    /// <summary>
    /// Sets the main form to be a global instance so it doesn't have to be passed as an argument.
    /// </summary>

    internal class MainForm
    {
        private static TestTool _testTool;

        public static void Initialize(TestTool testTool)
        {
            _testTool = testTool;
        }

        public static TestTool Instance => _testTool;
    }
}
