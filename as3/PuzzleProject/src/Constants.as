package  
{
	import flash.display.Stage;
	import gameContent.user.GoalPoint;
	import gameContent.user.Player;
	import gameScreens.ScreenManager;
	/**
	 * ...
	 * @author Elroy&Rachel
	 */
	public class Constants 
	{
		public static var STAGE:Stage;
		public static var screenManager:ScreenManager;
		
		public static const gridWidth:int = 64;
		public static const gridHeight:int = 64;
		
		public static var collision:Array;
		
		public static var player:Player;
		public static var goalPoint:GoalPoint;
	}

}