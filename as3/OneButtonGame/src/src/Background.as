package src 
{
	import flash.display.Sprite;
	/**
	 * ...
	 * @author Elroy
	 */
	public class Background extends Sprite
	{
		
		public function Background() 
		{
			graphics.beginFill(0xFFFFFF);
			graphics.drawRect(0, 0, 64, 32);
			graphics.endFill();
			
			graphics.beginFill(0x000000);
			graphics.drawRect(0, 32, 64, 32);
			graphics.endFill();
		}
		
	}

}