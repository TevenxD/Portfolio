package src.Content.Enemies 
{
	import flash.display.MovieClip;
	import src.Main;
	/**
	 * ...
	 * @author Elroy
	 */
	public class UnhealtyFood extends Food
	{
		private var movieclip:MovieClip
		private var foodID:int;
		
		public function UnhealtyFood(main:Main, sortFood:String = "spaans", $speed:int = 4) 
		{
			super(main);
			
			speedX = $speed;
			speedY = $speed;
			foodType = "Unhealty";
			
			if (sortFood == "spaans") foodID = Chance.randomNumber(1, 7);
			if (sortFood == "fastfood") foodID = Chance.randomNumber(8, 14);
			if (sortFood == "bakery") foodID = Chance.randomNumber(15, 27);
			
			switch(foodID)
			{
				// spaans
				case 1:
				default:
						movieclip = new _Buritto();		break;
				case 2: movieclip = new _Churros();		break;
				case 3: movieclip = new _Quesadillas();	break;
				case 4: movieclip = new _Enchilada();	break;
				case 5: movieclip = new _Nacho();		break;
				case 6: movieclip = new _Guacamole();	break;
				case 7: movieclip = new _Rijstschotel();break;
				// fastfood
				case 8: movieclip = new _Hamburger();	break;
				case 9: movieclip = new _Hotdog();		break;
				case 10: movieclip = new _Kipnuggets();	break;
				case 11: movieclip = new _Patat();		break;
				case 12: movieclip = new _Soda();		break;
				case 13: movieclip = new _Milkshake();	break;
				case 14: movieclip = new _Pizza();		break;
				// bakery
				case 15: movieclip = new _Donut1();		break;
				case 16: movieclip = new _Donut2();		break;
				case 17: movieclip = new _Ijs();		break;
				case 18: movieclip = new _Muffin();		break;
				case 19: movieclip = new _Muffinchoco();break;
				case 20: movieclip = new _Appeltaart();	break;
				case 21: movieclip = new _Bananasplit();break;
				case 22: movieclip = new _Brownie();	break;
				case 23: movieclip = new _Cookie();		break;
				case 24: movieclip = new _Cupcake();	break;
				case 25: movieclip = new _Icecream();	break;
				case 26: movieclip = new _Pudding();	break;
				case 27: movieclip = new _Puddingbrood();break;
			}
			addChild(movieclip);
		}
		
	}

}