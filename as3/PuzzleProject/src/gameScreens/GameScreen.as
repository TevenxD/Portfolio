package gameScreens 
{
	import flash.display.MovieClip;
	import gameContent.levels.Levels;
	import gameContent.user.GoalPoint;
	import gameContent.user.Player;
	/**
	 * ...
	 * @author Elroy&Rachel
	 */
	public class GameScreen extends MovieClip
	{
		private var player:Player;
		private var goalPoint:GoalPoint;
		
		public function GameScreen() 
		{
			
		}
		
		public function init():void 
		{
			Levels.createLevel(0);
			
			player = Constants.player;
			addChild(player);
			
			goalPoint = Constants.goalPoint;
			addChild(goalPoint);
			
			for (var i:int = 0; i < Constants.collision.length; i++)
				addChild(Constants.collision[i]);
		}
		
		public function loop():void 
		{
			
		}
	}

}