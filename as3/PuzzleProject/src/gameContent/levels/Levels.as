package gameContent.levels 
{
	import gameContent.user.GoalPoint;
	import gameContent.user.Player;
	/**
	 * ...
	 * @author Groep3
	 */
	public class Levels 
	{
		// 0 = nothing
		// 1 = wall
		// 2 = player
		// 3 = goal
		
		private static var testLevel:Array = [
			[1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
			[1, 0, 0, 0, 0, 1, 0, 0, 0, 1],
			[1, 0, 0, 0, 0, 0, 0, 0, 0, 1],
			[1, 0, 0, 0, 1, 0, 0, 0, 1, 1],
			[1, 1, 0, 0, 0, 0, 0, 0, 0, 1],
			[1, 0, 0, 0, 0, 0, 0, 0, 0, 1],
			[1, 2, 0, 0, 0, 1, 3, 1, 0, 1],
			[1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
		];
		
		public static function createLevel(level:int):void
		{
			Constants.collision = new Array();
			
			for (var y:int = 0; y < testLevel.length; y++)
			{
				
				for (var x:int = 0; x < testLevel[y].length; x++)
				{
					switch(testLevel[y][x])
					{
						case 1: // wall
							Constants.collision.push(new Wall(x * Constants.gridWidth, y * Constants.gridHeight));
							break;
						case 2: // player
							Constants.player = new Player(x * Constants.gridWidth, y * Constants.gridHeight);
							break;
						case 3: // goal
							Constants.goalPoint = new GoalPoint(x * Constants.gridWidth, y * Constants.gridHeight);
							break;
					}
				}
			}
		}
		
	}

}