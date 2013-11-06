package content.enemys;

import java.awt.Graphics;
import java.util.Random;
import resources.*;
import entity.*;

public class Enemy extends Sprite
{
	private float speed;
	private int direction;
	
	public Enemy()
	{
		super(Images.enFish, 0, 0, 16, 10, 1, 4, 200);
		
		Random generator = new Random();
		
		speed = 80 + generator.nextInt(100);
		size = generator.nextInt(500) / 100 + 0.5f;
		
		if (generator.nextBoolean()) {
			direction = 1;
			x = -width * size;
		}
		else {
			direction = -1;
			x = Constants.ScreenWidth;
		}
		y = generator.nextInt(Constants.ScreenHeight - (int)(height * size));
		
		bounds = new Rectangle((int)x, (int)y, (int)(width * size), (int)(height * size));
	}
	
	public void Update(long dt)
	{
		float currentSpeed = speed / 1000 * dt;
		
		x += currentSpeed * direction;
		
		bounds.x = (int)x;
		bounds.y = (int)y;
		
		super.Update(dt);
	}
	
	public void Draw(Graphics g)
	{
		if (direction > 0)
			g.drawImage(texture, (int)x, (int)y, (int)x + (int)(width * size), (int)y + (int)(height * size), srcX, srcY, srcX + width, height, null);
		else
			g.drawImage(texture, (int)x + (int)(width * size), (int)y, (int)x, (int)y + (int)(height * size), srcX, srcY, srcX + width, height, null);
		
		//g.drawRect(bounds.x, bounds.y, bounds.width, bounds.height);
	}
}
