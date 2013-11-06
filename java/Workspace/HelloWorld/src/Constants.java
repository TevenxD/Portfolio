import java.awt.Graphics;
import java.awt.Image;
import javax.swing.JFrame;


public class Constants 
{
	public static Image image;
	public static Graphics graphics;
	
	public static JFrame STAGE = new JFrame() {
		public void paint(Graphics g) {
			g.drawImage(Constants.image, 0, 0, null);
		}
	};
	
	public static boolean running = true;
}
