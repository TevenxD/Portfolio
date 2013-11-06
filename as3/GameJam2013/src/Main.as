package 
{
	import flash.display.Sprite;
	import flash.display.Stage;
	import flash.events.Event;
	import Screens.Game;
	
	/**
	 * ...
	 * @author Groep3
	 */
	[SWF(width = 380, height = 460, backgroundColor=0x000000)]
	public class Main extends Sprite 
	{
		public static var MAIN:Main;
		public static var STAGE:Stage;
		
		private var game:Game;
		
		public function Main():void 
		{
			MAIN = this;
			STAGE = stage;
			
			if (stage) init();
			else addEventListener(Event.ADDED_TO_STAGE, init);
		}
		
		private function init(e:Event = null):void 
		{
			removeEventListener(Event.ADDED_TO_STAGE, init);
			
			game = new Game();
			
			addEventListener(Event.ENTER_FRAME, loop);
		}
		
		private function loop(e:Event):void 
		{
			game.loop();
		}
		
		public function clearStage():void
		{
			while (this.numChildren > 0) {
				this.removeChildAt(0);
			}
		}
		
	}
	
}