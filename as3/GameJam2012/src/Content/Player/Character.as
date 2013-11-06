package src.Content.Player 
{
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.events.KeyboardEvent;
	import flash.events.MouseEvent;
	import flash.ui.Keyboard;
	import src.Main;
	import src.Dependancies.WVector;
	/**
	 * ...
	 * @author Elroy
	 */
	public class Character extends MovieClip
	{
		private var vector:WVector = new WVector(4, 4);
		public var movieclip:MovieClip;
		public var main:Main;
		
		//lifes
		public var lifes:int;
		public var life_mc:MovieClip = new lifes_mc();
		public var heroframe:int;
		public var alive:Boolean;
		
		//tiles
		private var tiles:Array;
		//movement
		private var movementspeed:int;
		private var left:Boolean;
		private var right:Boolean;
		private var down:Boolean;
		private var up:Boolean;
		
		public function Character($main:Main, $character:MovieClip,$tiles:Array, $lifes:int = 3) 
		{
			alive = true;
			heroframe = 1;
			main = $main;
			lifes = $lifes;
			tiles = $tiles;
			
			main.addChild(life_mc);
			life_mc.x = 20;
			life_mc.y = 20;
			
			movieclip = $character;
			movieclip.stop();
			main.stage.addEventListener(KeyboardEvent.KEY_DOWN, keydown);
			main.stage.addEventListener(KeyboardEvent.KEY_UP, keyup);
			main.addChild(movieclip);
			vector.dx = main.stage.stageWidth / 2;
			vector.dy = main.stage.stageHeight / 2;
			
			movementspeed = 6 - heroframe;
		}
		
		public function loop():void
		{
			movementspeed = 6 - heroframe;
			movement();
			
			movieclip.x = vector.dx;
			movieclip.y = vector.dy;
			
		}
		
		public function killplayer()
		{
			movieclip.gotoAndStop("death");
			if (movieclip.animation.currentFrame == movieclip.animation.totalFrames)
			{
				alive = false;
			}
			
		}
		private function movement()
		{
			if (left && movieclip.x > 0)
			{
				movieclip.gotoAndStop("walkleft" + heroframe);
				vector.dx -= movementspeed;
			}
			if (right && movieclip.x < main.stage.stageWidth - movieclip.width)
			{
				movieclip.gotoAndStop("walkright" + heroframe);
				vector.dx += movementspeed;
			}
			if (up && movieclip.y > 0+176)
			{
				movieclip.gotoAndStop("walkback" + heroframe);
				vector.dy -= movementspeed; 
			}
			if (down && movieclip.y < main.stage.stageHeight - movieclip.height/4)
			{
				movieclip.gotoAndStop("walkfront" + heroframe);
				vector.dy += movementspeed;
			}
			if (!left && !right && !up && !down)
			{
				movieclip.gotoAndStop("fat" + heroframe);
			}
			
			for (var i:int = 0; i < tiles.length; i++) 
			{
				while (tiles[i].obstacle && tiles[i].hitTestPoint(movieclip.x - movementspeed, movieclip.y, true )) { // left
					movieclip.x++;
					vector.dx++;
				}
				while (tiles[i].obstacle && tiles[i].hitTestPoint(movieclip.x + movementspeed, movieclip.y, true )) { // right
					movieclip.x--;
					vector.dx--;
				}
				while (tiles[i].obstacle && tiles[i].hitTestPoint(movieclip.x, movieclip.y + movementspeed, true )) { // down
					movieclip.y--;
					vector.dy--;
				}
				while (tiles[i].obstacle && tiles[i].hitTestPoint(movieclip.x, movieclip.y - movementspeed, true )) { // up
					movieclip.y++;
					vector.dy++;
				}
			}
		}
		
		private function keydown(e:KeyboardEvent)
		{
			switch(e.keyCode)
			{
				case Keyboard.UP:
					up = true;
					break;
				case Keyboard.LEFT:
					left = true;
					break;
				case Keyboard.DOWN:
					down = true;
					break;
				case Keyboard.RIGHT:
					right = true;
					break;
					
			}
		}
		//up
		private function keyup(e:KeyboardEvent)
		{
			switch(e.keyCode)
			{
				case Keyboard.UP:
					up = false;
					break;
				case Keyboard.LEFT:
					left = false;
					break;
				case Keyboard.DOWN:
					down = false;
					break;
				case Keyboard.RIGHT:
					right = false;
					break;
					
			}
		}
		
	}
		
}