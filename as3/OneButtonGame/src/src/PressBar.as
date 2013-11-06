package src 
{
	import flash.display.Sprite;
	import flash.events.KeyboardEvent;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	/**
	 * ...
	 * @author Elroy
	 */
	public class PressBar extends Sprite
	{
		private var timer:Timer;
		private var score:int = 1;
		private var g:Sprite = new Sprite;
		private var array:Array;
		private var Stage:Object;
		public var destroy:Boolean = false;
		
		public function PressBar(obj:Object, x:Number = 0, y:Number = 0, color:uint = 0x000000, barWidth:int = 2) 
		{
			this.x = x;
			this.y = y;
			
			Stage = obj;
			array = new Array(color, barWidth);
			
			for (var i:int = 0; i > -20; i)
			{
				graphics.beginFill(color);
				graphics.drawRect(0, i, 2, -1);
				graphics.endFill();
				
				i = i - 2;
			}
			addChild(g);
			g.graphics.beginFill(color);
			g.graphics.drawRect(2, 0, barWidth, -1);
			g.graphics.endFill();
			
			Stage.addEventListener(KeyboardEvent.KEY_UP, press);
			
			timer = new Timer(200, 0);
			timer.addEventListener(TimerEvent.TIMER, tik);
			timer.start();
		}
		
		private function tik(e:TimerEvent):void 
		{
			if (score > 0) {
				score -= 1;
				
				removeChild(g);
				g = new Sprite(); 
				addChild(g);
				
				g.graphics.beginFill(array[0]);
				g.graphics.drawRect(2, 0, array[1], -score);
				g.graphics.endFill();
			}
			if (score > 10) {
				score -= 1;
			}
			if (score > 15) {
				score -= 1;
			}
			if (score > 20) {
				score -= 1;
			}
			
			if (destroy) {
				timer.removeEventListener(TimerEvent.TIMER, tik);
				Stage.removeEventListener(KeyboardEvent.KEY_UP, press);
			}
		}
		
		private function press(e:KeyboardEvent):void 
		{
			if (e.keyCode == 32)
			{
				score += 1;
				
				removeChild(g);
				g = new Sprite(); 
				addChild(g);
				
				g.graphics.beginFill(array[0]);
				g.graphics.drawRect(2, 0, array[1], -score);
				g.graphics.endFill();
			}
		}
		
	}

}