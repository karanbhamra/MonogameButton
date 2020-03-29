using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameButton
{
    class Button
    {
        public static int NumButtons = 0;
        public string Text { get; set; }
        public Size Size { get; set; }
        public Point Location { get; set; }
        public event Action<object, MouseEventArgs> Clicked;
        public Rectangle Hitbox => new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);
        public SpriteFont SpriteFont { get; set; }
        public Color TextColor { get; set; }
        public String Name => $"Button {NumButtons}";
        public Texture2D Background { get; set; }

        private MouseState prevMouseState;


        public Button(int x, int y, int width, int height, string text, SpriteFont spriteFont, Texture2D background)
        {
            NumButtons++;
            Text = text;
            Size = new Size(width, height);
            Location = new Point(x, y);
            SpriteFont = spriteFont;
            TextColor = Color.Black;
            prevMouseState = Mouse.GetState();
            Background = background;
        }

        public void Draw(SpriteBatch sb)
        {
            Update();
            sb.Draw(Background, Hitbox, Color.White);

            Vector2 MiddlePoint = new Vector2(Hitbox.X + Hitbox.Width / 2, Hitbox.Y + Hitbox.Height / 2);


            var textSize = this.SpriteFont.MeasureString(Text);
            Vector2 TextMiddlePoint = new Vector2(textSize.X / 2, textSize.Y / 2);


            Vector2 textPosition = new Vector2((int)(MiddlePoint.X - textSize.X), (int)(MiddlePoint.Y - textSize.Y));

            sb.DrawString(SpriteFont, Text, textPosition, TextColor);
        }

        public void Update()
        {
            var mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && Hitbox.Contains(mouseState.Position))
            {
                if (mouseState != prevMouseState)
                {
                    Clicked?.Invoke(this, new MouseEventArgs(mouseState.Position));
                }
            }

            prevMouseState = mouseState;
        }
    }
}
