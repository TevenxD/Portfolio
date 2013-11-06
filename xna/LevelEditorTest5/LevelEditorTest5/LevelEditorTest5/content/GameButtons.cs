using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LevelEditorTest5.content.objects;

namespace LevelEditorTest5.content
{
    class GameButtons
    {
        // buttons that are only used once
        public static Button save = new Button(Main.MAIN.Content.Load<Texture2D>("content\\buttons\\saveButton"), new Vector2(0, 0), new Rectangle(0, 0, 48, 16));
        public static Button load = new Button(Main.MAIN.Content.Load<Texture2D>("content\\buttons\\LoadButton"), new Vector2(0, 0), new Rectangle(0, 0, 48, 16));
        public static Button newButton = new Button(Main.MAIN.Content.Load<Texture2D>("content\\buttons\\newButton"), new Vector2(0, 0), new Rectangle(0, 0, 48, 16));

        public static Button fill = new Button(Main.MAIN.Content.Load<Texture2D>("content\\buttons\\fillButton"), new Vector2(0, 0), new Rectangle(0, 0, 80, 16));
        public static Button empty = new Button(Main.MAIN.Content.Load<Texture2D>("content\\buttons\\EmptyButton"), new Vector2(0, 0), new Rectangle(0, 0, 80, 16));
        public static Switch eraser = new Switch(Main.MAIN.Content.Load<Texture2D>("content\\buttons\\EraserButton"), new Vector2(0, 0), 80, 16);

        // buttons that are used more than one time
        public static Texture2D upTex = Main.MAIN.Content.Load<Texture2D>("content\\buttons\\NormalArrowButtons");//, new Vector2(0, 0), 16, 16);
        public static Texture2D rightTex = Main.MAIN.Content.Load<Texture2D>("content\\buttons\\NormalArrowButtons");//, new Vector2(0, 0), 16, 16, 1);
        public static Texture2D downTex = Main.MAIN.Content.Load<Texture2D>("content\\buttons\\NormalArrowButtons");//, new Vector2(0, 0), 16, 16, 2);
        public static Texture2D leftTex = Main.MAIN.Content.Load<Texture2D>("content\\buttons\\NormalArrowButtons");//, new Vector2(0, 0), 16, 16, 3);

        public static Rectangle srcUp = new Rectangle(0, 0, 16, 16);
        public static Rectangle srcRight = new Rectangle(16, 0, 16, 16);
        public static Rectangle srcDown = new Rectangle(32, 0, 16, 16);
        public static Rectangle srcLeft = new Rectangle(48, 0, 16, 16);

        public static Texture2D grayLeftTex = Main.MAIN.Content.Load<Texture2D>("content\\buttons\\ArrowButtonsGray");//, new Vector2(0, 0), 16, 16);
        public static Texture2D grayRightTex = Main.MAIN.Content.Load<Texture2D>("content\\buttons\\ArrowButtonsGray");//, new Vector2(0, 0), 16, 16, 1);

        public static Rectangle srcGrayLeft = new Rectangle(0, 0, 16, 16);
        public static Rectangle srcGrayRight = new Rectangle(16, 0, 16, 16);

        // switch button (on/off)
        public static Switch layer1 = new Switch(Main.MAIN.Content.Load<Texture2D>("content\\buttons\\layer1switch"), new Vector2(0, 0), 60, 16);
        public static Switch layer2 = new Switch(Main.MAIN.Content.Load<Texture2D>("content\\buttons\\layer2switch"), new Vector2(0, 0), 60, 16);
        public static Switch layer3 = new Switch(Main.MAIN.Content.Load<Texture2D>("content\\buttons\\layer3switch"), new Vector2(0, 0), 60, 16);
        public static Texture2D layerVisible = Main.MAIN.Content.Load<Texture2D>("content\\buttons\\layerSwitchOnOff");
    }
}
