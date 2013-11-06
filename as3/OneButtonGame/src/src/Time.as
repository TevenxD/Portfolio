package src 
{
	import flash.display.MovieClip;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	/**
	 * ...
	 * @author Elroy
	 */
	public class Time extends MovieClip
	{
		public var obj:MovieClip;
		private var clock:Timer;
		private var array:Array;
		
		public function Time(x:Number = 0, y:Number = 0, scale:int = 1) 
		{
			this.x = x;
			this.y = y;
			this.scaleX = scale;
			this.scaleY = scale;
		}
		
		public function timer(lib:Class, stopFunction:Function, repeatFunction:Function = null, repeat:int = 1, delay:int = 1000, startFrame:int = 1, NextFrame:int = 1):void 
		{
			obj = new lib();
			addChild(obj);
			obj.gotoAndStop(startFrame);
			
			clock = new Timer(delay, repeat);
			clock.addEventListener(TimerEvent.TIMER, tik);
			clock.addEventListener(TimerEvent.TIMER_COMPLETE, stopTimer);
			clock.start();
			
			array = new Array(stopFunction, repeatFunction, NextFrame);
		}
		
		private function tik(e:TimerEvent):void 
		{
			obj.gotoAndStop(obj.currentFrame + array[2]);
			if (array[1]) {
				array[1](); 
			}
		}
		
		private function stopTimer(e:TimerEvent):void 
		{
			if (array[0]){
				array[0]();
			}
		}
		
		
	}

}