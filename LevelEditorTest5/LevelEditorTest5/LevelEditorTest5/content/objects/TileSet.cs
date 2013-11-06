using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditorTest5.content.objects
{
    class TileSet
    {
        public Texture2D texture;
        public int tileWidth, tileHeight;
        public int lengthX, lengthY;
        public int interspace;

        public TileSet(Texture2D texture, int width, int height, int lengthX, int lengthY, int interspace)
        {
            this.texture = texture;
            this.tileWidth = width;
            this.tileHeight = height;
            this.lengthX = lengthX;
            this.lengthY = lengthY;
            this.interspace = interspace;
        }
    }
}
