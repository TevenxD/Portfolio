package screens;

import java.awt.Graphics;

public class ScreenManager 
{
	public static Screen currentScreen;
	
	public ScreenManager(Screen screen)
	{
		currentScreen = screen;
	}
	
	public void Update(long dt)
	{
		currentScreen.Update(dt);
	}
	
	public void Draw(Graphics g)
	{
		currentScreen.Draw(g);
	}
}
