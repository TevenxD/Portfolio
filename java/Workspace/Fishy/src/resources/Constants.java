package resources;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Image;
import javax.swing.JFrame;


public class Constants 
{
	public static Image image;
	public static Graphics graphics;
	
	public static int ScreenWidth = 560;
	public static int ScreenHeight = 560;
	
	public static JFrame STAGE = new JFrame() {
		public void paint(Graphics g) {
			g.drawImage(Constants.image, 0, 0, null);
			setBackground(new Color(153, 204, 255));
		}
	};
	
	public static boolean running = true;
}
