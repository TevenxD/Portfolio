using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LevelEditorTest5.content.objects;

namespace LevelEditorTest5.content.menus
{
    class EditMenu
    {
        Button fill;
        Button empty;

        Switch layer1Switch;
        Switch layer2Switch;
        Switch layer3Switch;

        public List<TileMap> map;
        public List<Switch> layerSwitch = new List<Switch>();
        public int layer = 0;

        Vector2 position;
        Texture2D menu;

        public EditMenu(Vector2 position, List<TileMap> map)
        {
            this.position = position;
            this.menu = GameUsage.EditMenu;
            this.map = map;

            // layerSwitch switching
            layer1Switch = GameButtons.layer1;
            layer2Switch = GameButtons.layer2;
            layer3Switch = GameButtons.layer3;

            layer1Switch.Click += new SwitchEvent(layer1SwitchClick);
            layer2Switch.Click += new SwitchEvent(layer2SwitchClick);
            layer3Switch.Click += new SwitchEvent(layer3SwitchClick);

            layer1Switch.pressed = true;

            layer1Switch.position = new Vector2(position.X + 52, position.Y + 28);
            layer2Switch.position = new Vector2(position.X + 52, position.Y + 50);
            layer3Switch.position = new Vector2(position.X + 52, position.Y + 72);

            // layerSwitch visible
            layerSwitch.Add(new Switch(GameButtons.layerVisible, new Vector2(position.X + 32, position.Y + 28), 16, 16)); // 0
            layerSwitch.Add(new Switch(GameButtons.layerVisible, new Vector2(position.X + 32, position.Y + 50), 16, 16)); // 1
            layerSwitch.Add(new Switch(GameButtons.layerVisible, new Vector2(position.X + 32, position.Y + 72), 16, 16)); // 2

            // buttons
            fill = GameButtons.fill;
            empty = GameButtons.empty;

            fill.position = new Vector2(position.X + 32, position.Y + 94);
            empty.position = new Vector2(position.X + 32, position.Y + 116);

            fill.Click += new ClickEvent(FillMap);
            empty.Click += new ClickEvent(EmptyMap);
        }

        public void FillMap(Object sender)
        {
            if (!layerSwitch[layer].pressed) map[layer].FillMap();
        }
        public void EmptyMap(Object sender)
        {
            if (!layerSwitch[layer].pressed) map[layer].EmptyMap();
        }

        public void layer1SwitchClick(Object sender)
        {
            layer = 0;

            if (!layer1Switch.pressed)
            {
                layer2Switch.pressed = false;
                layer3Switch.pressed = false;
            }
            else
                layer1Switch.pressed = false;
        }
        public void layer2SwitchClick(Object sender)
        {
            layer = 1;

            if (!layer2Switch.pressed)
            {
                layer1Switch.pressed = false;
                layer3Switch.pressed = false;
            }
            else
                layer2Switch.pressed = false;
        }
        public void layer3SwitchClick(Object sender)
        {
            layer = 2;

            if (!layer3Switch.pressed)
            {
                layer1Switch.pressed = false;
                layer2Switch.pressed = false;
            }
            else
                layer3Switch.pressed = false;
        }

        public void Update()
        {
            layer1Switch.Update();
            layer2Switch.Update();
            layer3Switch.Update();

            layerSwitch[0].Update();
            layerSwitch[1].Update();
            layerSwitch[2].Update();

            fill.Update();
            empty.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(menu, position, Color.White);
            spriteBatch.End();

            layer1Switch.Draw(spriteBatch);
            layer2Switch.Draw(spriteBatch);
            layer3Switch.Draw(spriteBatch);

            layerSwitch[0].Draw(spriteBatch);
            layerSwitch[1].Draw(spriteBatch);
            layerSwitch[2].Draw(spriteBatch);

            fill.Draw(spriteBatch);
            empty.Draw(spriteBatch);
        }
    }
}
