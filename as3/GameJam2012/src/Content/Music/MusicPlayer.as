package src.Content.Music 
{
	import flash.media.Sound;
	import flash.media.SoundChannel;
	/**
	 * ...
	 * @author Bo Hanafy
	 */
	public class MusicPlayer
	{
		private var file:Sound;
		private var channel:SoundChannel;
		public function MusicPlayer() 
		{
			file = new start_mp3();
			channel = file.play(0, 999999);
		}
		public function music(song:String)
		{
			switch(song)
			{
				case "startmenu":
					channel.stop();
					file = new start_mp3();
					channel = file.play(0, 999999);
					break;
				case "character":
					channel.stop();
					file = new character_mp3();
					channel = file.play(0, 999999);
					break;
				case "levelselect":
					channel.stop();
					file = new levelselect_mp3();
					channel = file.play(0, 999999);
					break;
				case "help":
					channel.stop();
					file = new help_mp3();
					channel = file.play(0, 999999);
					break;
				case "level1":
					channel.stop();
					file = new level1_mp3();
					channel = file.play(0, 999999);
					break;
				case "level2":
					channel.stop();
					file = new level2_mp3();
					channel = file.play(0, 999999);
					break;
				case "level3":
					channel.stop();
					file = new level3_mp3();
					channel = file.play(0, 999999);
					break;
					
			}
		}
		
	}

}