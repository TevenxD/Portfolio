package src 
{
	import flash.display.MovieClip;
	/**
	 * ...
	 * @author Elroy
	 */
	public class WindUp extends MovieClip
	{
		public var obj:MovieClip;
		
		public function WindUp(lib:Class, x:Number = 0, y:Number = 0, scale:int = 1) 
		{
			this.x = x;
			this.y = y;
			this.scaleX = scale;
			this.scaleY = scale;
			
			obj = new lib();
			addChild(obj);
			obj.stop();
		}
		
		public function spin():void 
		{
			if (obj.currentFrame == obj.totalFrames) {
				obj.gotoAndStop(1);
			} else {
				obj.nextFrame();
			}
		}
		
	}

}