import java.awt.Graphics;

public class Test
{
	Rectangle rect;
	
	public Test()
	{
		rect = new Rectangle(100, 100, 16, 16, 80);
		Constants.STAGE.addKeyListener(rect);
	}
	
	public void update(long dt)
	{
		rect.Update(dt);
	}
	
	public void draw(Graphics g)
	{
		rect.draw(g);
	}
}
