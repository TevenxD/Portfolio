package src.Content 
{
	import flash.display.MovieClip;
	import flash.events.KeyboardEvent;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	import src.Content.Enemies.HealtyFood;
	import src.Content.Enemies.UnhealtyFood;
	import src.Content.Music.MusicPlayer;
	import src.Content.Player.Character;
	import src.Gamestate.Activestate;
	import src.Gamestate.Basestate;
	import src.Gamestate.Beginstate;
	import flash.events.Event;
	import src.Main;
	/**
	 * ...
	 * @author Bo Hanafy
	 */
	public class Game
	{
		private var main:Main;
		private var startscreen:Beginstate;
		private var corestate:Beginstate;
		private var activestate:Activestate;
		private var musicplayer:MusicPlayer;
		public var done:Boolean;
		//level.done --> activestate.done --> game.done --> main
		
		public function Game($main:Main) 
		{
			main = $main;
			init_start();
			
		}
		public function init_start()
		{
			musicplayer = new MusicPlayer();
			startscreen = new Beginstate(main, this,musicplayer);
			startscreen.activate_intro();
		}
		public function init_game()
		{
			done = false;
			activestate = new Activestate(main);
			main.startloop();
			activestate.init(startscreen.chosenlevel, startscreen.character,startscreen.unlockedlevels,musicplayer);
			
			
			
		}
		public function play_game()
		{
			activestate.loop();
			if(activestate.leveldone)
			{
				startscreen.unlockedlevels = activestate.unlockedlevels;
				trace(startscreen.unlockedlevels);
				trace("leveldone");
				activestate.clear_stage();
				startscreen.activate_intro();
				main.stage.focus = main.stage;
				done = activestate.leveldone;
			}
		}
	}

}