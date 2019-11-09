using System.Windows.Forms;

namespace Pong
{
    static class GlobalVariables
    {
        public static playerControls p1, p2;
        public const int ballSize = 30;
        public static Panel gB;
        public static Button tB;
        public static GameForm gF;
        public static int speed = 5;

        public static bool wIsPressed = false;
        public static bool sIsPressed = false;
        public static bool upIsPressed = false;
        public static bool downIsPressed = false;
        //windows message id for hotkey
        public const int WM_HOTKEY_MSG_ID = 0x0312;
    }
}
