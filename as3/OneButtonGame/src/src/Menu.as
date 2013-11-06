package src 
{
	import flash.display.MovieClip;
	import flash.events.KeyboardEvent;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	/**
	 * ...
	 * @author Elroy
	 */
	public class Menu extends MovieClip
	{
		private var text:MovieClip;
		private var ground:MovieClip;
		private var walk:MovieClip;
		private var windup:MovieClip;
		private var timer:Timer;
		private var functie:Function;
		private var Stage:Object;
		
		public function Menu(textclip:Class, walkclip:Class, groundclip:Class, windupclip:Class, startFunction:Function, stageObject:Object, x:Number = 0, y:Number = 0) 
		{
			walk = new walkclip();
			addChild(walk);
			walk.y = 10;
			walk.stop();
			
			ground = new groundclip();
			addChild(ground);
			ground.y = 26
			ground.stop();
			
			windup = new windupclip();
			addChild(windup);
			windup.x = walk.x - 15;
			windup.y = 10;
			
			text = new textclip();
			addChild(text);
			text.stop();
			text.x = 3;
			text.y = 45;
			
			timer = new Timer(100, 0);
			timer.addEventListener(TimerEvent.TIMER, loop);
			timer.start();
			
			Stage = stageObject;
			Stage.addEventListener(KeyboardEvent.KEY_UP, startGame);
			functie = startFunction;
		}
		
		private function startGame(e:KeyboardEvent):void 
		{
			if (e.keyCode == 32){
				functie();
				Stage.removeEventListener(KeyboardEvent.KEY_UP, startGame);
				timer.removeEventListener(TimerEvent.TIMER, loop);
			}
		}
		
		private function loop(e:TimerEvent):void 
		{
			if (text.currentFrame == text.totalFrames) {
				text.gotoAndStop(1);
			} else {
				text.nextFrame();
			}
			
			if (walk.currentFrame == walk.totalFrames) {
				walk.gotoAndStop(1);
			} else {
				walk.nextFrame();
			}
			
			windup.x = walk.x - 15;
			walk.x += 1;
			
			if (walk.x > Stage.stageWidth) {
				walk.x = -8;
			}
		}
		
	}

}