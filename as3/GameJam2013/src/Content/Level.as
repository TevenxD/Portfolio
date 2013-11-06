package Content 
{
	import flash.display.MovieClip;
	import flash.geom.Point;
	/**
	 * ...
	 * @author Groep3
	 */
	public class Level extends MovieClip
	{
		public var background:MovieClip = new MC_Level();
		public var ball:MovieClip = new MC_Ball();
		
		private var levelState:int;
		public var previousMouse:Point;
		
		public function Level() 
		{
			Main.STAGE.addChild(background);
			Main.STAGE.addChild(ball);
			
			ball.x = Main.STAGE.stageWidth / 2;
			ball.y = Main.STAGE.stageHeight / 2;
			ball.stop();
			
			background.x = Main.STAGE.stageWidth / 2;
			background.y = Main.STAGE.stageHeight / 2;
			
			levelState = 0;
			
			background.collision.alpha = 0;
			background.hole.alpha = 0;
			background.start.alpha = 0;
		}
		
		public function setMouse():void {
			previousMouse = new Point(mouseX, mouseY);
		}
		
		public function loop():void
		{
			if (levelState != 1) {
				levelState = 1;
			}
			
			//position.X += (float)Math.Round(Math.Cos(direction * (Math.PI / 180)) * speed * elapsed);
            //position.Y += (float)Math.Round(Math.Sin(direction * (Math.PI / 180)) * speed * elapsed);
			//hoek = (float)Math.Atan2(-(wijzer.position.Y - mouseState.Y), -(wijzer.position.X - mouseState.X));
			
			if (!ball.hitTestPoint(mouseX, mouseY, true))
			{
				/*var speedX:Number = (Main.STAGE.stageWidth / 2 - mouseX);
				if (speedX < 0) speedX *= -1;
				if (speedX > 4) speedX = 4;
				
				var speedY:Number = (Main.STAGE.stageHeight / 2 - mouseY);
				if (speedY < 0) speedY *= -1;
				if (speedY > 4) speedY = 4;*/
				
				var dir:Number = Math.atan2(Main.STAGE.stageHeight / 2 - mouseY, Main.STAGE.stageWidth / 2 - mouseX);
				dir = dir * 180 / Math.PI;
				background.x += Math.round(Math.cos(dir * (Math.PI / 180)) * 4);
				background.y += Math.round(Math.sin(dir * (Math.PI / 180)) * 4);
			}
			
			/*if (background.x > Main.STAGE.stageWidth) {
				background.x = Main.STAGE.stageWidth
			}
			if (background.y > Main.STAGE.stageHeight) {
				background.y = Main.STAGE.stageHeight
			}
			if (background.x < 0) {
				background.x = 0
			}
			if (background.y < 0) {
				background.y = 0
			}*/
			
			var ballPoints:Array = [
				background.collision.hitTestPoint(ball.x + (ball.width / 2), ball.y, true),
				background.collision.hitTestPoint(ball.x - (ball.width / 2), ball.y, true),
				background.collision.hitTestPoint(ball.x, ball.y + (ball.height / 2), true),
				background.collision.hitTestPoint(ball.x, ball.y - (ball.height / 2), true),
			]
			
			for (var i:int = 0; i < ballPoints.length; i++)
			{
				if (ballPoints[i])
				{
					levelState = 2;
				}
			}
			
			var holePoints:Array = [
				background.hole.hitTestPoint(ball.x + (ball.width / 2), ball.y, true),
				background.hole.hitTestPoint(ball.x - (ball.width / 2), ball.y, true),
				background.hole.hitTestPoint(ball.x, ball.y + (ball.height / 2), true),
				background.hole.hitTestPoint(ball.x, ball.y - (ball.height / 2), true),
			]
			
			for (var j:int = 0; j < ballPoints.length; j++)
			{
				if (!holePoints[j]) break;
				else if (j == holePoints.length -1) {
					levelState = 3;
				}
			}
			
			/*if (previousMouse.x - mouseX > 50 || previousMouse.x - mouseX < -50 ||
				previousMouse.y - mouseY > 50 || previousMouse.y - mouseY < -50) {
				levelState = 2;
			}*/
			
			previousMouse.x = mouseX;
			previousMouse.y = mouseY;
		}
		
		public function getState():int
		{
			return levelState;
		}
	}

}