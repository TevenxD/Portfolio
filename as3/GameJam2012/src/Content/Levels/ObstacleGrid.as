package src.Content.Levels
{
	import flash.display.MovieClip;
	/**
	 * ...
	 * @author Elroy
	 */
	public class ObstacleGrid extends MovieClip
	{
		private var chosenGrid:Array = new Array();
		/*
			1 = stoel
			2 = tafel
			3 = bord
			4 = prullebak
			5 = plantenbak
			6 = sombrero
			7 = hond
			
			1: 6 7
			2: 1 2 4
			3: 5 3
		*/
		public var level1:Array = [	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
									[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0],
									[0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
									[0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0],
									[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
									[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7],
									[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];
		
		public var level2:Array = [	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
									[0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0],
									[0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 0, 0],
									[0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0],
									[0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0],
									[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
									[0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];
		
		public var level3:Array = [	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
									[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0],
									[0, 0, 5, 0, 0, 0, 0, 0, 3, 0, 0, 0],
									[0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0],
									[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
									[0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0]];
		public var tiles:Array = new Array();
		
		public function ObstacleGrid(x:int = 0, y:int = 0) 
		{
			this.x = x;
			this.y = y;
		}
		
		public function createGrid($grid:Array):void 
		{	
			for (var i:int = 0; i < $grid.length; i++) 
			{
				chosenGrid.push([]);
				for (var j:int = 0; j < $grid[i].length; j++) 
				{
					var tile:MovieClip;
					switch($grid[i][j])
					{
						default: tile = new MovieClip();	break;
						case 1:	tile = new MC_Obstacle1();	break;
						case 2: tile = new MC_Obstacle2();	break;
						case 3: tile = new MC_Obstacle3();	break;
						case 4: tile = new MC_Obstacle4();	break;
						case 5: tile = new MC_Obstacle5();	break;
						case 6: tile = new MC_Obstacle6();	break;
						case 7: tile = new MC_Obstacle7();	break;
					}
					tile.x = tile.width * j;
					tile.y = tile.width * i;
					
					tiles.push(tile);
					chosenGrid[i].push(tile);
					
					if ($grid[i][j] == 0) {
						tile.obstacle = false;
					} else {
						tile.obstacle = true;
						addChild(chosenGrid[i][j]);
					}
				}
			}
		}
		
	}

}