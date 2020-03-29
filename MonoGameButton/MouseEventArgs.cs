using System;
using Microsoft.Xna.Framework;

namespace MonoGameButton
{
    public class MouseEventArgs : EventArgs
    {
        public Point Location { get; private set; }
        public MouseEventArgs(Point loc)
        {
            Location = loc;
        }
    }
}
