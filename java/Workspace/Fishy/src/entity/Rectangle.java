package entity;

public class Rectangle 
{
	public int x, y, width, height;
	
	public int Left() { return x; }
	public int Right() { return x + width; }
	public int Top() { return y; }
	public int Bottom() { return y + height; }
	
	public Rectangle()
	{
		this.x = 0;
		this.y = 0;
		this.width = 0;
		this.height = 0;
	}
	
	public Rectangle(int x, int y, int width, int height)
	{
		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height;
	}
	
	public boolean Intersects(Rectangle rect)
	{
		return	(x > rect.x && x < rect.Right() && y > rect.y && y < rect.Bottom()) || // left up corner
				(this.Right() > rect.x && this.Right() < rect.Right() && y > rect.y && y < rect.Bottom()) || // right up corner
				(x > rect.x && x < rect.Right() && this.Bottom() > rect.y && this.Bottom() < rect.Bottom()) || // down left corner
				(this.Right() > rect.x && this.Right() < rect.Right() && this.Bottom() > rect.y && this.Bottom() < rect.Bottom()) || // down right corner
				
				(rect.x > x && rect.x < this.Right() && rect.y > y && rect.y < this.Bottom()) || // left up corner
				(rect.Right() > x && rect.Right() < this.Right() && rect.y > y && rect.y < this.Bottom()) || // right up corner
				(rect.x > x && rect.x < this.Right() && rect.Bottom() > y && rect.Bottom() < this.Bottom()) || // down left corner
				(rect.Right() > x && rect.Right() < this.Right() && rect.Bottom() > y && rect.Bottom() < this.Bottom()); // down right corner
	}
	
	public boolean IsOnLeft(Rectangle rect, int offset) {
		return (this.Right() >= rect.Left() && this.Right() <= rect.Left() + offset && this.Bottom() > rect.Top() && this.Top() < rect.Bottom());
	}
	public boolean IsOnRight(Rectangle rect, int offset) {
		return (this.Left() <= rect.Right() && this.Left() >= rect.Right() + offset && this.Bottom() > rect.Top() && this.Top() < rect.Bottom());
	}
	public boolean IsOnTopOf(Rectangle rect, int offset) {
		return (this.Bottom() >= rect.Top() && this.Bottom() <= rect.Top() + offset && this.Right() > rect.Left() && this.Left() < rect.Right());
	}
	public boolean IsUnder(Rectangle rect, int offset) {
		return (this.Top() <= rect.Bottom() && this.Top() >= rect.Bottom() + offset && this.Right() > rect.Left() && this.Left() < rect.Right());
	}
}
