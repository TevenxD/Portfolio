package src 
{
	import flash.display.MovieClip;
	/**
	 * ...
	 * @author Elroy
	 */
	public class WinLose extends MovieClip
	{
		public var obj1:MovieClip;
		public var obj2:MovieClip;
		
		public function WinLose(libResults:Class, player1Frame:int, player2Frame:int, x:Number = 0, y:Number = 0, distanceX:Number = 0, distanceY:Number = 0) 
		{
			this.x = x;
			this.y = y;
			
			obj1 = new libResults();
			obj2 = new libResults();
			
			obj1.gotoAndStop(player1Frame);
			obj2.gotoAndStop(player2Frame);
			
			addChild(obj1);
			addChild(obj2);
			
			obj2.x = distanceX;
			obj2.y = distanceY;
		}
		
	}

}