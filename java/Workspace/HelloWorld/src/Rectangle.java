import java.awt.Graphics;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class Rectangle implements KeyListener
{
	public float speed;
	public float x, y;
	public int width, height;
	
	boolean left, right, up, down;
	
	public Rectangle(float x, float y, int width, int height, float speed)
	{
		this.x = x;
		this.y = y;
		this.speed = speed;
		this.width = width;
		this.height = height;
	}
	
	public void Update(long dt)
	{
		UpdateMovement(dt);
	}
	
	public void UpdateMovement(long dt)
	{
		if (left)
			this.x -= speed / 1000 * dt;
		if (right)
			this.x += speed / 1000 * dt;
		if (up)
			this.y -= speed / 1000 * dt;
		if (down)
			this.y += speed / 1000 * dt;
			
	}
	
	public void draw(Graphics g)
	{
		g.fillRect((int)x, (int)y, width, height);
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
}
