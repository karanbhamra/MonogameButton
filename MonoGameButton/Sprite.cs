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
    class Sprite
    {
        Texture2D texture;
        Vector2 pos;
        int width;
        int height;
        Rectangle hitbox => new Rectangle((int)pos.X, (int)pos.Y, width, height);
        public Sprite(Texture2D sprite, int x, int y, int w, int h)
        {
            texture = sprite;
            pos = new Vector2(x, y);
            width = w;
            height = h;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, hitbox, Color.White);
        }

        public bool IsColliding(Sprite other)
        {
            return hitbox.Intersects(other.hitbox);
        }

    }
}
