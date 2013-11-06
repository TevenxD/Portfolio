package gameScreens 
{
	/**
	 * ...
	 * @author Elroy&Rachel
	 */
	public class ScreenManager 
	{
		public var screens:Array;
		private var current:int;
		
		public function ScreenManager() 
		{
			screens = new Array();
			screens.push(new StartScreen());
			screens.push(new GameScreen());
			
			current = 0;
			Constants.STAGE.addChild(screens[current]);
			screens[current].init();
		}
		
		public function openNewScreen(index:int):void
		{
			Constants.STAGE.removeChild(screens[current]);
			
			screens[index].init();
			Constants.STAGE.addChild(screens[index]);
			current = index;
		}
		
		public function loop():void
		{
			screens[current].loop();
		}
	}

}