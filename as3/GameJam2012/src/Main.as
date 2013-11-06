package src 
{
	import flash.display.MovieClip;
	import flash.events.Event;
	import src.Content.Game;
	/**
	 * ...
	 * @author Bo Hanafy
	 */
	public class Main extends MovieClip
	{
		private var game:Game;
		
		public function Main() 
		{
			game = new Game(this);
		}
		public function startloop()
		{
			this.addEventListener(Event.ENTER_FRAME, gameloop);
		}
		private function gameloop(e:Event)
		{
			game.play_game();
			if (game.done)
			{
				this.removeEventListener(Event.ENTER_FRAME, gameloop);
				game.done = false;
			}
		}
	}

}