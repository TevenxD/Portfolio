package
{
	import flash.display.MovieClip;
	import flash.events.KeyboardEvent;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	import src.Background;
	import src.Menu;
	import src.PressBar;
	import src.Race;
	import src.ScoreBar;
	import src.ScoreBoard;
	import src.Time;
	import src.WinLose;
	/**
	 * ...
	 * @author Elroy
	 */
	public class Main extends MovieClip
	{
		private var menu:Menu;
		private var player1:Race;
		private var player2:Race;
		private var back:Background;
		private var timer:Timer;
		private var score:ScoreBoard;
		private var winlose:WinLose;
		private var scorebar1:ScoreBar;
		private var scorebar2:ScoreBar;
		private var pressbar:PressBar;
		
		private var turn:int = 1;
		private var points1:int;
		private var points2:int;
		
		public function Main()
		{
			this.scaleX = 2;
			this.scaleY = 2;
			
			back = new Background();
			addChild(back);
			
			init();
		}
		
		public function init():void 
		{
			menu = new Menu(libPressToPlay, libWhitePlayer, libWhiteGround, libWindUpWhite, startGame, stage);
			addChild(menu);
		}
		
		public function startGame():void
		{
			removeChild(menu);			
			player1 = new Race(libWhitePlayer, libWindUpWhite, libWhiteGround, libWhiteDigit, secondTurn, 0, 0, 0x000000);
			addChild(player1);
		}
		
		public function secondTurn():void 
		{
			player2 = new Race(libBlackPlayer, libWindUpBlack, libBlackGround, libBlackDigit, end, 0, 32, 0xFFFFFF);
			addChild(player2);
		}
		
		
		public function end():void 
		{
			timer = new Timer(2000, 1);
			timer.addEventListener(TimerEvent.TIMER_COMPLETE, results);
			timer.start();
		}
		
		private function results(e:TimerEvent):void 
		{
			points1 = player1.steps;
			points2 = player2.steps;
			
			removeChild(player1);
			removeChild(player2);
			timer.removeEventListener(TimerEvent.TIMER_COMPLETE, results);
			
			points1 = points1 / 3;
			scorebar1 = new ScoreBar(60, 32, points1, 0x000000, 4);
			addChild(scorebar1);
			
			points2 = points2 / 3;
			scorebar2 = new ScoreBar(60, 64, points2, 0xFFFFFF, 4);
			addChild(scorebar2);
			
			if (player1.steps > player2.steps)
			{
				winlose = new WinLose(libWinResults, 1, 4, 14, 8, 0, 32)
				addChild(winlose);
			}
			else if (player1.steps < player2.steps)
			{
				winlose = new WinLose(libWinResults, 3, 2, 14, 8, 0, 32)
				addChild(winlose);
			}
			else
			{
				winlose = new WinLose(libWinResults, 1, 2, 14, 8, 0, 32)
				addChild(winlose);
			}
			
			stage.addEventListener(KeyboardEvent.KEY_UP, restart);
		}
		
		private function restart(e:KeyboardEvent):void 
		{
			if (e.keyCode == 32) {
				stage.removeEventListener(KeyboardEvent.KEY_UP, restart);
				removeChild(winlose);
				removeChild(scorebar1);
				removeChild(scorebar2);
				
				points1 = 0;
				points2 = 0;
				
				init();
			}
		}
		
	}

}