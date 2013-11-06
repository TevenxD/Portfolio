package entity;

import java.awt.Graphics;
import java.awt.Image;

public class Sprite 
{
	public float x, y;
	public float size;
	public int srcX, srcY;
	public int width, height;
	public Rectangle bounds;
	
	public int currentFrame, totalFrames;
	public float interval;
	protected float timer;
	
	protected Image texture;
	
	public Sprite(Image texture, float x, float y, int width, int height)
	{
		this.x = x;
		this.y = y;
		
		this.width = width;
		this.height = height;
		
		this.texture = texture;
		
		this.currentFrame = 1;
		this.size = 1;
	}
	
	public Sprite(Image texture, float x, float y, int width, int height, float size)
	{
		this.x = x;
		this.y = y;
		
		this.width = width;
		this.height = height;
		
		this.texture = texture;
		
		this.currentFrame = 1;
		this.size = size;
	}
	
	public Sprite(Image texture, float x, float y, int width, int height, float size, int totalFrames, float interval)
	{
		this.x = x;
		this.y = y;
		
		this.width = width;
		this.height = height;
		
		this.texture = texture;
		
		this.interval = interval;
		this.totalFrames = totalFrames;
		this.currentFrame = 1;
		this.size = size;
	}

	public void Update(long dt)
	{
		timer += dt;
		
		if (timer > interval) {
			currentFrame++;
			timer = 0;
		}
		if (currentFrame > totalFrames)
			currentFrame = 1;
		
		srcX = (currentFrame - 1) * width;
	}
	
	public void Draw(Graphics g)
	{
		g.drawImage(texture, (int)x, (int)y, (int)x + (int)(width * size), (int)y + (int)(height * size), srcX, srcY, srcX + width, height, null);
	}
}
