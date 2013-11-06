package src.Content.Enemies 
{
	import flash.display.MovieClip;
	import src.Main;
	/**
	 * ...
	 * @author Elroy
	 */
	public class HealtyFood extends Food
	{
		private var movieclip:MovieClip
		private var chancetorotate:int;
		private var foodID:int;
		
		public function HealtyFood(main:Main, $speed:int = 4) 
		{
			super(main);
			
			speedX = $speed;
			speedY = $speed;
			foodType = "Healty";
			foodID = Chance.randomNumber(1, 5);
			
			switch(foodID)
			{
				case 1:
				default: 
						movieclip = new _Salade(); 		break;
				case 2: movieclip = new _FruitSalade();	break;
				case 3: movieclip = new _Apple();		break;
				case 4: movieclip = new _Watermeloen();	break;
				case 5: movieclip = new _Wortel();		break;
			}
			addChild(movieclip);
			
			
		}
	}

}