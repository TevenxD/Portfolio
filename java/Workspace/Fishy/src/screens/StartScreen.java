package screens;

import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import resources.*;

public class StartScreen extends Screen implements KeyListener
{
	private Image background;
	
	private float timer;
	private boolean show;
	
	public StartScreen()
	{
		Constants.STAGE.addKeyListener(this);
		background = Images.startScreenBackground;
		timer = 60;
	}
	
	public void Update(long dt)
	{
		timer -= dt / 10;
		
		if (timer < 0) {
			timer = 60;
			show = !show;
		}
	}
	
	public void Draw(Graphics g)
	{
		g.drawImage(background, 0, 0, 560, 560, 0, 0, 560, 560, null);
		if (show)
			g.drawString("Press Enter to play", 224, 280);
	}
	
	@Override
	public void keyPressed(KeyEvent ke) 
	{
		
	}
	
	@Override
	public void keyReleased(KeyEvent ke) 
	{
		// 10 = Enter
		if (ke.getKeyCode() == 10) ScreenManager.currentScreen = new GameScreen();
	}
	
	@Override
	public void keyTyped(KeyEvent arg0) {
		// TODO Auto-generated method stub
		
	}
}
