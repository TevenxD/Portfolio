package src 
{
	import flash.display.MovieClip;
	/**
	 * ...
	 * @author Elroy
	 */
	public class ScoreBoard extends MovieClip
	{
		private var positie:Number = 0;
		private var frame:Number = 0;
		private var deelGetal:Number = 1;
		private var obj:MovieClip;
		
		public function ScoreBoard(x:int, y:int, scale:int = 1) 
		{
			this.x = x;
			this.y = y;
			this.scaleX = scale;
			this.scaleY = scale;
		}
		
		public function showScore(lib:Class, score:Number = 0, afstand:Number = 8):void 
		{
			if (score < 1) {
				obj = new lib();
				addChild(obj);
				obj.gotoAndStop(1);
			}//if end
			
			for (var j:Number = 1; j <= score; j)
			{
				j = j * 10;
				deelGetal = deelGetal * 10;
			}//for end
			deelGetal = deelGetal / 10;
			
			
			for (var i:Number = 1; deelGetal >= i; i)
			{
				frame = score;
				frame = frame / deelGetal;
				frame = Math.floor(frame);
				
				obj = new lib();
				addChild(obj);
				obj.gotoAndStop(frame + 1);
				obj.x = positie * afstand;
				
				positie += 1;
				frame = frame * deelGetal;
				score -= frame;
				deelGetal = deelGetal / 10;
			}//for end
		}//	//	//	//	Einde showScore Functie
		
	}

}