package src.Content.Enemies 
{
	import flash.display.MovieClip;
	import src.Content.Player.Character;
	import src.Main;
	
	/**
	 * ...
	 * @author Elroy
	 */
	public class Spawner extends MovieClip
	{
		private var player:MovieClip;
		private var character:Object;
		private var lifeframe:int = 6;
		private var maxlifes = 3;
		
		public var objectenArray:Array = new Array();
		
		public function Spawner($player:MovieClip, $character:Object) 
		{
			player = $player;
			character = $character;
			lifeframe = 4;
			character.life_mc.gotoAndStop(lifeframe);
			
			
		}
		
		public function moveObjects($width:int = 640, $height:int = 480):void 
		{
			character.life_mc.gotoAndStop(lifeframe);
			for (var i:int = 0; i < objectenArray.length; i++) 
			{
				objectenArray[i].x += objectenArray[i].speedX;
				objectenArray[i].y += objectenArray[i].speedY;
				
				objectenArray[i].rotation += objectenArray[i].rotationSpeed;
				
				if (player.hitTestPoint(objectenArray[i].x, objectenArray[i].y, true)) 
				{
					if (objectenArray[i].foodType == "Unhealty")
					{
						character.heroframe ++;
						character.lifes --;
						character.life_mc.gotoAndStop(lifeframe--);
					}
					if (objectenArray[i].foodType == "Healty")
					{
						
						if (character.lifes < maxlifes)
						{
							character.heroframe --;
							character.lifes ++;
							character.life_mc.gotoAndStop(lifeframe++);
						}
					}
					
					removeChild(objectenArray[i]);
					objectenArray.splice(i, 1);
					break;
				}
				
				if (objectenArray[i].speedX > 0 && objectenArray[i].x > $width || 
					objectenArray[i].speedX < 0 && objectenArray[i].x < 0 - objectenArray[i].width ||
					objectenArray[i].speedY > 0 && objectenArray[i].y > $height ||
					objectenArray[i].speedY < 0 && objectenArray[i].y < 0 - objectenArray[i].height)
				{
					removeChild(objectenArray[i]);
					objectenArray.splice(i, 1);
				}
			}
		}
		
		public function addNewObject(obj:Object, place:int = 1, $width:int = 640, $height:int = 480, chanceRotate:int = 10, limit:int = 100):void 
		{
			if (objectenArray.length < limit)
			{
				objectenArray.push(obj);
				var i:int = objectenArray.length - 1;
				
				switch(place)
				{
					case 1: // left
					default:
						objectenArray[i].x = -objectenArray[i].width;
						objectenArray[i].y = Chance.randomNumber(0, $height - objectenArray[i].height);
						
						objectenArray[i].speedY = 0;
						if (Chance.percentage(chanceRotate)) {
							objectenArray[i].rotationSpeed = objectenArray[i].speedX
						}
						break;
					case 2: // up
						objectenArray[i].x = Chance.randomNumber(0, $width - objectenArray[i].width);
						objectenArray[i].y = -objectenArray[i].height;
						
						objectenArray[i].speedX = 0;
						if (Chance.percentage(chanceRotate)) {
							objectenArray[i].rotationSpeed = objectenArray[i].speedY;
						}
						break;
					case 3: // right
						objectenArray[i].x = $width;
						objectenArray[i].y = Chance.randomNumber(0, $height - objectenArray[i].height);
						
						objectenArray[i].speedX = -objectenArray[i].speedX;
						objectenArray[i].speedY = 0;
						if (Chance.percentage(chanceRotate)) {
							objectenArray[i].rotationSpeed = objectenArray[i].speedX;
						}
						break;
					case 4: // down
						objectenArray[i].x = Chance.randomNumber(0, $width - objectenArray[i].width);
						objectenArray[i].y = $height;
						
						objectenArray[i].speedY = -objectenArray[i].speedY;
						objectenArray[i].speedX = 0
						if (Chance.percentage(chanceRotate)) {
							objectenArray[i].rotationSpeed = objectenArray[i].speedY;
						}
						break;
				}
				addChild(objectenArray[i]);
			}
		}
		
	}

}