package src.Gamestate 
{
	import flash.display.MovieClip;
	import src.Content.Music.MusicPlayer;
	import src.Main;
	import src.Content.Player.Character;
	import flash.events.TimerEvent;
	import src.Content.Enemies.Spawner;
	import src.Content.Enemies.Chance;
	import flash.utils.Timer;
	import src.Content.Enemies.HealtyFood;
	import src.Content.Enemies.UnhealtyFood;
	import src.Content.Levels.Levels;
	/**
	 * ...
	 * @author Bo Hanafy
	 */
	public class Activestate extends Basestate
	{
		private var hero:Character;
		private var spawn:Spawner;
		private var spawntime:Timer;
		private var character:MovieClip;
		public var levelinfo:Levels;
		public var unlockedlevels:int
		private var level:int;
		
		public var leveldone:Boolean;
		
		public function Activestate($main:Main) 
		{
			main = $main;
			leveldone = false;
		}
		public function init($level:int,$character:MovieClip, $currentlevel:int, $musicplayer:MusicPlayer)
		{
			//level
			level = $level;
			levelinfo = new Levels(main, level,$currentlevel,$musicplayer);
			levelinfo.createlevel();
			levelinfo.leveldone = false;
			trace(leveldone);
			trace(levelinfo.leveldone);
			
			//character
			character = $character;
			hero = new Character(main, character, levelinfo.grid.tiles);
			
			//enemy
			spawn = new Spawner(character, hero);
			main.addChild(spawn);
			spawntime = new Timer(levelinfo.respawnrate, 0);
			spawntime.addEventListener(TimerEvent.TIMER, addNewSpawnObject);
			spawntime.start();
		}
		override public function clear_stage()
		{
			while ( main.numChildren > 0 )
			{
				main.removeChildAt(0);
			}
			spawntime.removeEventListener(TimerEvent.TIMER, addNewSpawnObject);
			level = 0;
		}
		private function addNewSpawnObject(e:TimerEvent)
		{
			var obj:Object;
			
			if (Chance.percentage(20))
			{
				obj = new HealtyFood(main, levelinfo.foodSpeed);
			}else {
				obj = new UnhealtyFood(main, levelinfo.sortFood, levelinfo.foodSpeed);
			}
			
			spawntime.delay = levelinfo.spawnRate;
			spawn.addNewObject(obj, Chance.randomNumber(1, 4), 640, 480, levelinfo.foodRotateChance, levelinfo.foodLimit);
		}
		//main active loop
		public function loop()
		{
			leveldone = levelinfo.leveldone;
			
			if (!levelinfo.pause)
			{
				hero.loop();
				spawn.moveObjects(640, 480);
			}else {
				spawntime.stop();
			}
			if (hero.lifes <= 0)
			{
				hero.killplayer();
				trace(hero.heroframe);
				levelinfo.backtostart();
				if (!hero.alive)
				{
					hero.lifes = 3;
				}
				
			}
			unlockedlevels = levelinfo.levelsunlocked;
			
		}
		public function kill(target:MovieClip)
		{
			main.removeChild(target);
		}
	}

}