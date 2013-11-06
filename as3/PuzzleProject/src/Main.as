package
{
	import flash.display.Sprite;
	import flash.events.Event;
	import gameScreens.ScreenManager;
	
	/**
	 * ...
	 * @author Elroy&Rachel
	 */
	[SWF(width = 800, height = 600, backgroundColor=0xFFFFFF)]
	public class Main extends Sprite 
	{
		private var screenManager:ScreenManager;
		
		public function Main():void 
		{
			Constants.STAGE = this.stage;
			
			if (stage) init();
			else addEventListener(Event.ADDED_TO_STAGE, init);
		}
		
		private function init(e:Event = null):void 
		{
			removeEventListener(Event.ADDED_TO_STAGE, init);
			
			this.screenManager = new ScreenManager();
			Constants.screenManager = this.screenManager;
			
			addEventListener(Event.ENTER_FRAME, loop);
		}
		
		private function loop(e:Event):void 
		{
			screenManager.loop();
		}
		
	}
	
}