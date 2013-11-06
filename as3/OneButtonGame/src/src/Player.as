package src 
{
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	/**
	 * ...
	 * @author Elroy
	 */
	public class Player extends MovieClip
	{
		private var array:Array;
		private var timer:Timer;
		public var obj:MovieClip;
		
		public function Player(lib:Class ,x:Number = 0, y:Number = 0, scale:int = 1) 
		{
			this.x = x;
			this.y = y;
			this.scaleX = scale;
			this.scaleY = scale;
			
			obj = new lib();
			addChild(obj);
			obj.stop();
		}
		
		public function startWalk(stopFunction:Function, steps:Number = 0, walkSpeed:int = 1, pixPerSteps:int = 1, limitX:Number = 32):void
		{
			timer = new Timer(walkSpeed * 100, steps);
			timer.addEventListener(TimerEvent.TIMER, walk);
			if (stopFunction != null){
				timer.addEventListener(TimerEvent.TIMER_COMPLETE, end);
			}
			timer.start();
			
			array = new Array(stopFunction, pixPerSteps, limitX);
			
		}
		
		private function walk(e:TimerEvent):void 
		{
			if (this.x < array[2]) {
				this.x += array[1];
			}
			if (obj.currentFrame == obj.totalFrames) {
				obj.gotoAndStop(1);
			} else {
				obj.nextFrame();
			}
		}
		
		private function end(e:TimerEvent):void 
		{
			array[0]();
		}
		
	}

}