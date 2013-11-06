package content.player;

import resources.Constants;
import resources.Images;
import entity.*;

import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class Player extends Sprite implements KeyListener
{
	public float speed;
	private float accelX=0, accelY=0;
	boolean left, right, up, down;
	
	public Player(float _x, float _y)
	{
		super(Images.fish, _x, _y, 16, 10, 1, 4, 200);
		
		bounds = new Rectangle((int)x, (int)y, (int)(width * size), (int)(height * size));
		speed = 180;
	}
	
	public Player(float _x, float _y, int _width, int _height, float _speed)
	{
		super(Images.fish, _x, _y, _width, _height, 1, 4, 200);
		
		speed = _speed;
	}
	
	public Player(Image tex, float _x, float _y, int _width, int _height, float _speed, int _totalFrames)
	{
		super(tex, _x, _y, _width, _height, 1, _totalFrames, 200);
		
		speed = _speed;
	}
	
	public Player(Image tex, float _x, float _y, int _width, int _height, float _speed, int _totalFrames, float _interval)
	{
		super(tex, _x, _y, _width, _height, 1, _totalFrames, _interval);
		
		speed = _speed;
	}
	
	public void Update(long dt)
	{
		float currentSpeed = speed / 1000 * dt;
		
		if (right)
			accelX += .034f;
		else if (left)
			accelX -= .034f;
		else if (accelX > 0)
			accelX -= .034f;
		else if (accelX < 0)
			accelX += .034f;
		if (accelX < .034f && accelX > -.034f)
			accelX = 0;
		
		if (accelX > 1)
			accelX = 1;
		if (accelX < -1)
			accelX = -1;
		
		if (down)
			accelY += .034f;
		else if (up)
			accelY -= .034f;
		else if (accelY > 0)
			accelY -= .034f;
		else if (accelY < 0)
			accelY += .034f;
		if (accelY < .034f && accelY > -.034f)
			accelY = 0;
		
		if (accelY > 1)
			accelY = 1;
		if (accelY < -1)
			accelY = -1;
		
		this.x += currentSpeed * accelX;
		this.y += currentSpeed * accelY;
		
		if (x < 0)
			x = 0;
		if (y < 0)
			y = 0;
		if (x > Constants.ScreenWidth - bounds.width)
			x = Constants.ScreenWidth - bounds.width;
		if (y > Constants.ScreenHeight - bounds.height)
			y = Constants.ScreenHeight - bounds.height;
		
		bounds.x = (int)x;
		bounds.y = (int)y;
		bounds.width = (int)(width * size);
		bounds.height = (int)(height * size);
		
		super.Update(dt);
	}
	
	@Override
	public void keyPressed(KeyEvent ke) 
	{
		//System.out.println(ke.getKeyCode());
		
		if (ke.getKeyCode() == 37) left = true;
		if (ke.getKeyCode() == 38) up = true;
		if (ke.getKeyCode() == 39) right = true;
		if (ke.getKeyCode() == 40) down = true;
			
	}
	
	@Override
	public void keyReleased(KeyEvent ke) 
	{
		if (ke.getKeyCode() == 37) left = false;
		if (ke.getKeyCode() == 38) up = false;
		if (ke.getKeyCode() == 39) right = false;
		if (ke.getKeyCode() == 40) down = false;
	}
	
	@Override
	public void keyTyped(KeyEvent arg0) {
		// TODO Auto-generated method stub
		
	}
	
	public void Draw(Graphics g)
	{
		if (accelX > 0)
			g.drawImage(texture, (int)x, (int)y, (int)x + (int)(width * size), (int)y + (int)(height * size), srcX, srcY, srcX + width, height, null);
		else
			g.drawImage(texture, (int)x + (int)(width * size), (int)y, (int)x, (int)y + (int)(height * size), srcX, srcY, srcX + width, height, null);
		
		//g.drawRect(bounds.x, bounds.y, bounds.width, bounds.height);
	}
}
