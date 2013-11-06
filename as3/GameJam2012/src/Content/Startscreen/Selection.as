package src.Content.Startscreen 
{
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.events.MouseEvent;
	import flash.display.SimpleButton;
	import src.Main;
	/**
	 * ...
	 * @author Bo Hanafy
	 */
	public class Selection extends selection_lib
	{
		
		private var main:Main;
		
		public function Selection($main:Main) 
		{
			main = $main;
			main.addChild(this);
			this.x = 0;
			this.y = 0;
		}
		
	}

}