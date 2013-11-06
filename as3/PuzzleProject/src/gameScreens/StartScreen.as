package gameScreens 
{
	import flash.display.MovieClip;
	import flash.events.MouseEvent;
	/**
	 * ...
	 * @author Elroy&Rachel
	 */
	public class StartScreen extends MC_StartScreen
	{
		
		
		public function StartScreen() 
		{
			startButton.addEventListener(MouseEvent.CLICK, startGame);
		}
		
		private function startGame(e:MouseEvent):void 
		{
			Constants.screenManager.openNewScreen(1); // game screen
		}
		
		public function init():void 
		{
			
		}
		
		public function loop():void 
		{
			
		}
		
	}

}