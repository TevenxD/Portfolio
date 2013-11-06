package Screens 
{
	import Content.Level;
	import flash.events.Event;
	import flash.events.MouseEvent;
	import flash.events.TimerEvent;
	import flash.text.AntiAliasType;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	import flash.text.TextFormatAlign;
	import flash.ui.Mouse;
	import flash.utils.Timer;
	
	/**
	 * ...
	 * @author Groep3
	 */
	public class Game 
	{
		private var level:Level;
		private var started:Boolean;
		private var tFields:Array;
		
		private var time:int;
		private var timeMs:int;
		private var timer:Timer = new Timer(100);
		private var timeDisp:TextField;
		
		public function Game() 
		{
			level = new Level();
			started = false;
			tFields = [];
			time = 0;
			timeMs = 0;
			timeDisp = null;
			
			tFields.push(addText("Click the ball to start", 10, 10));
				
			timer.addEventListener(TimerEvent.TIMER, updateTime);
			level.ball.addEventListener(MouseEvent.CLICK, start);
		}
		
		private function start(e:MouseEvent):void
		{
			level.ball.removeEventListener(MouseEvent.CLICK, start);
			level.background.start.removeEventListener(MouseEvent.CLICK, start);
			
			started = true;
			timer.start();
			
			for (var i:int = tFields.length - 1; i >= 0; i--)
			{
				Main.STAGE.removeChild(tFields[i]);
				tFields.splice(tFields.indexOf(i), 1);
			}
			
			timeDisp = addText("Time: " + time.toString(), 10, 430, 20, false);
			tFields.push(timeDisp);
			
			level.setMouse();
			level.ball.addEventListener(MouseEvent.CLICK, pause);
		}
		
		public function pause(e:MouseEvent):void
		{
			level.ball.removeEventListener(MouseEvent.CLICK, pause);
				
			started = false;
			timer.stop();
			
			tFields.push(addText("Paused", 130, 10, 40, false));
			tFields.push(addText("Click the ball to resume", 31, 50, 30));
			
			if (level.ball.hitTestObject(level.background.start))
			{
				level.ball.addEventListener(MouseEvent.CLICK, start);
			}
			
			level.ball.addEventListener(MouseEvent.CLICK, start);
		}
		
		public function gameOver():void
		{
			Mouse.show();
			Main.STAGE.removeChild(level.background);
			Main.STAGE.removeChild(level.ball);
			
			level = new Level();
			
			timer.stop();
			time = 0;
			
			tFields.push(addText("Game over!", 85, 10, 40, false));
			tFields.push(addText("Click the ball to start", 10, 50));
			
			level.ball.addEventListener(MouseEvent.CLICK, start);
		}
		
		public function gameWon():void
		{
			Mouse.show();
			Main.STAGE.removeChild(level.background);
			Main.STAGE.removeChild(level.ball);
			
			level = new Level();
			
			timer.stop();
			
			tFields.push(addText("You won!", 94, 10, 40, false));
			tFields.push(addText("Time: " + time.toString(), 190 / 2 + 10, 50, 40, false));
			tFields.push(addText("Click the ball to start", 10, 90));
			
			time = 0;
			
			level.ball.addEventListener(MouseEvent.CLICK, start);
		}
		
		public function addText(text:String, x:int, y:int, size:uint = 40, blink:Boolean = true):TextField
		{
			var ticks:int = 0;
			
			function blinkText(e:Event):void
			{
				ticks++;
				
				if (ticks == 20)
				{
					if (t.alpha == 1)
					{
						t.alpha = 0;
					}
					else
					{
						t.alpha = 1;
					}
					
					ticks = 0;
				}
			}
			
			var f:TextFormat = new TextFormat();
			var t:TextField = new TextField();
			
			f.font = "Arial";
			f.size = size;
			f.color = 0xffffff;
			f.align = TextFormatAlign.LEFT;
			
			t.selectable = false;
			t.mouseEnabled = false;
			t.gridFitType = "pixel"
			t.antiAliasType = AntiAliasType.ADVANCED;
			t.autoSize = TextFieldAutoSize.LEFT;
			t.sharpness = 400;
			t.x = x;
			t.y = y;
			t.text = text;
			
			t.setTextFormat(f);
			
			Main.STAGE.addChild(t);
			
			if (blink)
			{
				t.addEventListener(Event.ENTER_FRAME, blinkText);
			}
			
			return t;
		}
		
		public function updateTime(e:TimerEvent):void
		{
			timeMs++;
			
			if (timeMs >= 10)
			{
				time++;
				timeMs = 0;
				
				if (timeDisp)
				{
					Main.STAGE.removeChild(tFields[tFields.indexOf(timeDisp)]);
					tFields.splice(tFields.indexOf(timeDisp), 1);
				}
				
				timeDisp = addText("Time: " + time.toString(), 10, 430, 20, false);
				
				tFields.push(timeDisp);
			}
		}
		
		public function loop():void
		{
			var levelState:int;
			
			if (started)
			{
				level.loop();
				
				levelState = level.getState();
				
				if (levelState == 2)
				{
					started = false;
					gameOver();
				}
				
				if (levelState == 3)
				{
					started = false;
					level.ball.play();
				}
			}
			
			if (level.getState() == 3 && level.ball.currentFrame == level.ball.totalFrames)
			{
				level.ball.gotoAndStop(1);
				gameWon();
			}
		}
	}

}