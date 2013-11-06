package src.Gamestate 
{
	import src.Main;
	/**
	 * ...
	 * @author Bo Hanafy
	 */
	public class Basestate
	{
		protected var main:Main;
		
		public function Basestate() 
		{
		}
		
		public function clear_stage()
		{
			while ( main.numChildren > 0 )
			{
				main.removeChildAt(0);
			}
		}
		
	}

}