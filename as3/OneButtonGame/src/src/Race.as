package src 
{
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.events.KeyboardEvent;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	/**
	 * ...
	 * @author Elroy
	 */
	public class Race extends MovieClip
	{
		private var player:Player;
		private var ground:Player;
		private var score:ScoreBoard;
		private var countdown:Time;
		private var windup:WindUp;
		private var timer:Timer;
		private var numbers:Class;
		private var functie:Function;
		private var pressbar:PressBar;
		private var countRepeat:int;
		private var obj:Object;
		public var steps:int;
		
		private var color:uint;
		
		public function Race(libplayer:Class, libwindup:Class, libground:Class, libnumber:Class, resultFunction:Function, x:Number = 0, y:Number = 0, colorStage:uint = 0x000000) 
		{
			this.x = x;
			this.y = y;
			
			functie = resultFunction;
			numbers = libnumber;
			steps = 0;
			
			player = new Player(libplayer, 16, 10);
			addChild(player);
			windup = new WindUp(libwindup, player.x - 16, player.y);
			addChild(windup);
			ground = new Player(libground, 0, player.y + 16)
			addChild(ground);
			
			countdown = new Time(26, 8);
			addChild(countdown);
			countdown.timer(numbers, null, repeat, 5, 1000, 4, -1);
			
			color = colorStage;
		}
		
		public function repeat():void 
		{	
			if (countdown.obj.currentFrame == 10) {
				removeChild(countdown);
			}
			if (countdown.obj.currentFrame == 1) {
				countdown.obj.gotoAndStop(11);
				init();
			}
		}
		
		public function init():void	//	//	//	//	init function	//	//	//	//
		{ // speler begint met drukken //
			stage.addEventListener(KeyboardEvent.KEY_UP, press);
			
			pressbar = new PressBar(stage, 0, 24, color, 2);
			addChild(pressbar);
			
			timer = new Timer(1000, 2);
			timer.addEventListener(TimerEvent.TIMER_COMPLETE, startCountDown);
			timer.start();
		}
		
		private function press(e:KeyboardEvent):void //	// keyboard function // // 
		{
			if (e.keyCode == 32)
			{
				steps += 1;
				windup.spin();
			}
		}
		
		private function startCountDown(e:TimerEvent):void
		{
			countdown = new Time(26, 8);
			addChild(countdown);
			countdown.timer(numbers, walk, null, 3, 1000, 4, -1);
		}
		
		public function walk():void 	// speler begint met lopen //
		{
			pressbar.destroy = true;
			removeChild(pressbar);
			removeChild(countdown);
			stage.removeEventListener(KeyboardEvent.KEY_UP, press);
			
			if (steps > 0) {
				stage.addEventListener(Event.ENTER_FRAME, loop);
				windup.obj.play();
				
				player.startWalk(results, steps, 1, 1, 24);
				ground.startWalk(null, steps, 1, 0, 0);
			} else {
				results();
			}
			
		}
		
		private function loop(e:Event):void 
		{
			windup.x = player.x - 15;
		}
		
		public function results():void 
		{
			stage.removeEventListener(Event.ENTER_FRAME, loop);
			windup.obj.gotoAndStop(1);
			player.obj.gotoAndStop(1);
			ground.obj.stop();
			
			score = new ScoreBoard(32, 8);
			addChild(score);
			score.showScore(numbers, steps, 9);
			
			functie();
		}
	}

}