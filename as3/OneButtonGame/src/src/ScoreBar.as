package src 
{
	import flash.display.Sprite;
	/**
	 * ...
	 * @author Elroy
	 */
	public class ScoreBar extends Sprite
	{
		
		public function ScoreBar(x:Number = 0, y:Number = 0, score:int = 0, barColor:uint = 0x000000, barWidth:Number = 1) 
		{	
			this.x = x;
			this.y = y;
			
			graphics.beginFill(barColor);
			graphics.drawRect(0, 0, barWidth, -score);
			
			graphics.drawRect( -3, 0, 1, -30);
			for (var i:int = -5; i > -32; i){
				graphics.drawRect( -2, i, 2, 1);
				i = i - 5;
			}
			graphics.endFill();
		}
		
	}

}