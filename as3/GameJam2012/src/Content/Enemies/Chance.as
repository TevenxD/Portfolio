package src.Content.Enemies 
{
	/**
	 * ...
	 * @author Elroy
	 */
	public class Chance 
	{
		
		public static function percentage(percChance:int):Boolean
		{
			var chance:Boolean = false;
			var random:int = 1 + Math.random() * 100;
			
			if (random <= percChance) chance = true;
			
			return chance
		}
		public static function randomNumber(lowest:int = 0, highest:int = 100):int
		{
			highest -= lowest;
			var random:int = Math.round(lowest + Math.random() * highest);
			
			return random;
		}
	}

}