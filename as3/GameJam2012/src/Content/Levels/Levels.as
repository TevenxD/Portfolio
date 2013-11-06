package src.Content.Levels 
{
	import flash.display.MovieClip;
	import src.Main;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	import flash.events.MouseEvent;
	import src.Content.Music.MusicPlayer;
	/**
	 * ...
	 * @author Bo Hanafy
	 */
	public class Levels 
	{
		private var main:Main;
		private var endscreen_mc:MovieClip;
		
		//level
		private var level:int;
		public var grid:ObstacleGrid = new ObstacleGrid();
		
		private var duration:Timer;
		private var currenttime:int;
		private var background:MovieClip;
		
		public var respawnrate:int;
		public var enemyspeed:int;
		public var requiredtime:int;
		
		public var pause:Boolean;
		public var leveldone:Boolean;
		public var levelsunlocked:int = 1;
		
		// level chose
		private var moreFoodTime:int;
		private var fasterFoodTime:int;
		private var musicplayer:MusicPlayer;
		
		public var foodSpeed:int;
		public var sortFood:String;
		public var foodLimit:int;
		public var foodRotateChance:int;
		public var spawnRate:int;
		
		public function Levels($main:Main, $level:int, $currentlevel:int, $musicplayer:MusicPlayer) 
		{
			levelsunlocked = $currentlevel;
			main = $main;
			level = $level;
			musicplayer = $musicplayer;
		}
		public function createlevel()
		{
			pause = false;
			duration = new Timer(1000, 0);
			switch(level)
			{
				case 1:
					grid = new ObstacleGrid(0, 178);
					background = new level1_background_mc();
					requiredtime = 40;
					grid.createGrid(grid.level1);
					musicplayer.music("level1");
					
					//level setters
					foodSpeed = 3;
					sortFood = "spaans";
					foodLimit = 5;
					foodRotateChance = 10;
					spawnRate = 240;
					
					moreFoodTime = 3;
					fasterFoodTime = 10;
					break;
				case 2: // // //
					grid = new ObstacleGrid(0, 178);
					background = new level2_background_mc();
					requiredtime = 33;
					grid.createGrid(grid.level2);
					musicplayer.music("level2");
					
					//level setters
					foodSpeed = 3;
					sortFood = "fastfood";
					foodLimit = 10;
					foodRotateChance = 50;
					spawnRate = 280;
					
					moreFoodTime = 2;
					fasterFoodTime = 8;
					break;
				case 3: // // //
					grid = new ObstacleGrid(0, 178);
					background = new level3_background_mc();
					requiredtime = 1;
					grid.createGrid(grid.level3);
					musicplayer.music("level3");
					
					//level setters
					foodSpeed = 4;
					sortFood = "bakery";
					foodLimit = 80;
					foodRotateChance = 50;
					spawnRate = 180;
					
					moreFoodTime = 2;
					fasterFoodTime = 6;
					break;
			}
			duration.addEventListener(TimerEvent.TIMER, time);
			duration.start();
			main.addChild(background);
			background.x = 0;
			background.y = 0;
			main.addChild(grid);
			
		}
		
		private function time(e:TimerEvent)
		{
			currenttime++;
			background.counttime_txt.text = currenttime;
			
			switch (level)
			{
				case 1:
					if (currenttime == fasterFoodTime)
					{
						if (foodSpeed < 8) foodSpeed ++;
						
						fasterFoodTime += 14;
					}
					if (currenttime == moreFoodTime)
					{
						if (foodLimit < 100) foodLimit += 4;
						if (spawnRate > 90) spawnRate -= 20;
						else spawnRate = 90;
						
						moreFoodTime += 10;
					}
					break;
				case 2: // // //
					if (currenttime == fasterFoodTime)
					{
						if (foodSpeed < 9) foodSpeed ++;
						
						fasterFoodTime += 14;
					}
					if (currenttime == moreFoodTime)
					{
						if (foodLimit < 120) foodLimit += 5;
						if (spawnRate > 80) spawnRate -= 10;
						else spawnRate = 80;
						
						moreFoodTime += 2;
					}
					break;
				case 3: // // //
					if (currenttime == fasterFoodTime)
					{
						if (foodSpeed < 9) foodSpeed ++;
						
						fasterFoodTime += 13;
					}
					if (currenttime == moreFoodTime)
					{
						if (foodLimit < 140) foodLimit += 5;
						if (spawnRate > 70) spawnRate -= 4;
						else spawnRate = 70;
						
						moreFoodTime += 2;
					}
					break;
			}
			trace(foodLimit, foodSpeed, spawnRate);
		}
		
		public function backtostart()
		{	
			
			duration.removeEventListener(TimerEvent.TIMER, time);
			//pause game
			pause = true;
			
			// endscreen
			endscreen_mc = new scorescreen_lib();
			main.addChild(endscreen_mc);
			endscreen_mc.x = 0;
			endscreen_mc.y = 0;
			endscreen_mc.backbutton_btn.addEventListener(MouseEvent.CLICK, clickstart);
			
			//score check
			if (currenttime >= requiredtime)
			{
				endscreen_mc.score_txt.text = currenttime + "seconds";
				endscreen_mc.result_txt.text = " Congratulations. You lasted long enough to advance to the next level.";
				if (level == 1 && levelsunlocked == 2 || level == 2 && levelsunlocked == 3)
				{
					levelsunlocked = levelsunlocked;
				}else{
					levelsunlocked++;
				}
				
			}else {
				endscreen_mc.score_txt.text = currenttime + "seconds";
				endscreen_mc.result_txt.text = currenttime + " Oh, that's too bad. You need: " + requiredtime + " to advance to the next level.";
			}
		}
		private function clickstart(e:MouseEvent)
		{
			endscreen_mc.backbutton_btn.removeEventListener(MouseEvent.CLICK, clickstart);
			leveldone = true;
		}
	}

}