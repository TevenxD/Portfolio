package src.Gamestate 
{
	import flash.display.MovieClip;
	import flash.display.SimpleButton;
	import flash.events.KeyboardEvent;
	import flash.ui.Keyboard;
	import flash.events.MouseEvent;
	import src.Content.Game;
	import src.Content.Music.MusicPlayer;
	import src.Content.Startscreen.Selection;
	import src.Content.Player.Character;
	import src.Main;
	
	
	/**
	 * ...
	 * @author Bo Hanafy
	 */
	public class Beginstate extends Basestate
	{
		private var characterselection:Selection;
		private var game:Game;
		private var musicplayer:MusicPlayer;
		public var character:MovieClip;
		public var chosenlevel:int;
		public var unlockedlevels:int;
		
		private var buttonmenu:MovieClip = new startscreen_mc();
		private var levelmenu:MovieClip = new levelselection_mc();
		private var creditsmenu:MovieClip = new creditscreen_mc();
		private var helpmenu:MovieClip = new helpscreen_mc();
		
		public function Beginstate($main:Main, $game:Game, $musicplayer:MusicPlayer)
		{
			
			main = $main;
			game = $game;
			musicplayer = $musicplayer;
			
		}
		public function activate_intro()
		{
			main.addChild(buttonmenu);
			buttonmenu.x = 0;
			buttonmenu.y = 0;
			buttonmenu.buttons_mc.addEventListener(MouseEvent.CLICK, clickables);
			musicplayer.music("startmenu");
			
		}
		
		override public function clear_stage()
		{
			while ( main.numChildren > 0 )
			{
				main.removeChildAt(0);
			}
			buttonmenu.buttons_mc.removeEventListener(MouseEvent.CLICK, clickables);
		}
		private function clickables(e:MouseEvent)
		{
			var button:SimpleButton = e.target as SimpleButton;
			
			switch(button.name)
			{
				case "start":
					if (character == null)
					{
						trace("You haven't chosen a character");
					}else {
						select("level");
					}
					break;
				case "selection":
					
					select("player");
					break;
				case "credits":
					select("credits");
					break;
				case "help":
					select("help");
					break;
			}
		}
		private function select(selectwhat:String)
		{
			if (selectwhat == "player")
			{
				clear_stage();
				character = null;
				trace(character);
				characterselection = new Selection(main);
				characterselection.buttons_mc.addEventListener(MouseEvent.CLICK, characterselect);
				musicplayer.music("character");
			}else if (selectwhat == "level") {
				
				clear_stage();
				main.addChild(levelmenu);
				levelmenu.x = 0;
				levelmenu.y = 0;
				levelmenu.buttons_mc.addEventListener(MouseEvent.CLICK, levelselect);
				musicplayer.music("levelselect");
				
			}else if (selectwhat == "credits") {
				clear_stage();
				main.addChild(creditsmenu);
				creditsmenu.x = 0;
				creditsmenu.y = 0;
				creditsmenu.buttons_mc.addEventListener(MouseEvent.CLICK, creditsselect);
				
			}else if (selectwhat == "help") {
				clear_stage();
				main.addChild(helpmenu);
				helpmenu.x = 0;
				helpmenu.y = 0;
				helpmenu.buttons_mc.addEventListener(MouseEvent.CLICK, helpselect);
				musicplayer.music("help");
			}
		}
		private function helpselect(e:MouseEvent)
		{
			var button:SimpleButton = e.target as SimpleButton;
			if (button.name == "back")
			{
				clear_stage();
				main.stage.focus = main.stage;
				activate_intro();
				helpmenu.buttons_mc.removeEventListener(MouseEvent.CLICK, creditsselect);
			}
		}
		//credits
		private function creditsselect(e:MouseEvent)
		{
			var button:SimpleButton = e.target as SimpleButton;
			if (button.name == "back")
			{
				clear_stage();
				main.stage.focus = main.stage;
				activate_intro();
				creditsmenu.buttons_mc.removeEventListener(MouseEvent.CLICK, creditsselect);
			}
		}
		//levelselect
		private function levelselect(e:MouseEvent)
		{
			var button:SimpleButton = e.target as SimpleButton;
			
			switch(button.name)
			{
				case "level1":
					clear_stage();
					chosenlevel = 1;
					main.stage.focus = main.stage;
					trace("level1");
					//temp eventlistener fix
					levelmenu.buttons_mc.removeEventListener(MouseEvent.CLICK, levelselect);
					game.init_game();
					
					break;
				case "level2":
					if (unlockedlevels >= 2)
					{
						clear_stage();
						chosenlevel = 2;
						main.stage.focus = main.stage;
						//temp eventlistener fix
						levelmenu.buttons_mc.removeEventListener(MouseEvent.CLICK, levelselect);
						game.init_game();
					}else {
						trace("you haven't unlocked this level yet");
					}
					
					break;
				case "level3":
					if (unlockedlevels >= 3)
					{
						clear_stage();
						chosenlevel = 3;
						main.stage.focus = main.stage;
						//temp eventlistener fix
						levelmenu.buttons_mc.removeEventListener(MouseEvent.CLICK, levelselect);
						game.init_game();
					}else {
						trace("you haven't unlocked this level yet.");
					}
					break;
			}
		}
		
		//playerselect
		private function characterselect(e:MouseEvent)
		{
			
			var button:SimpleButton = e.target as SimpleButton;
			
			switch(button.name)
			{
				case "arnold":
					clear_stage();
					main.stage.focus = main.stage;
					character = new walter_mc();
					activate_intro();
					trace(character);
					//temp eventlistener fix
					characterselection.buttons_mc.removeEventListener(MouseEvent.CLICK, characterselect);
					
					
					break;
				case "peter":
					clear_stage();
					main.stage.focus = main.stage;
					character = new peter_mc();
					activate_intro();
					trace(character);
					//temp eventlistener fix
					characterselection.buttons_mc.removeEventListener(MouseEvent.CLICK, characterselect);
					break;
				case "joker":
					clear_stage();
					main.stage.focus = main.stage;
					character = new joker_mc();
					activate_intro();
					trace(character);
					//temp eventlistener fix
					characterselection.buttons_mc.removeEventListener(MouseEvent.CLICK, characterselect);
					break;
				case "rick":
					clear_stage();
					main.stage.focus = main.stage;
					character = new rick_mc();
					activate_intro();
					trace(character);
					//temp eventlistener fix
					characterselection.buttons_mc.removeEventListener(MouseEvent.CLICK, characterselect);
					break;
				case "afro":
					clear_stage();
					main.stage.focus = main.stage;
					character = new afro_mc();
					activate_intro();
					trace(character);
					//temp eventlistener fix
					characterselection.buttons_mc.removeEventListener(MouseEvent.CLICK, characterselect);
					break;
				case "angel":
					clear_stage();
					main.stage.focus = main.stage;
					character = new angel_mc();
					activate_intro();
					trace(character);
					//temp eventlistener fix
					characterselection.buttons_mc.removeEventListener(MouseEvent.CLICK, characterselect);
					break;
				case "back":
					clear_stage();
					main.stage.focus = main.stage;
					activate_intro();
					//temp eventlistener fix
					characterselection.buttons_mc.removeEventListener(MouseEvent.CLICK, characterselect);
					break;
			}
		}
		
	}
}