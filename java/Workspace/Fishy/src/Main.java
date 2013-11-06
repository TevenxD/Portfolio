import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.JFrame;
import screens.*;
import resources.*;

public class Main 
{
	private static ScreenManager screenManager;
	
	public static void main(String[] args)
	{
		new Main();
	}
	
	public Main()
	{
		Constants.STAGE.setTitle("Fishy");
		Constants.STAGE.setUndecorated(true);
		Constants.STAGE.setVisible(true);
		Constants.STAGE.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Constants.STAGE.setSize(Constants.ScreenWidth, Constants.ScreenHeight);
		Constants.STAGE.setLocationRelativeTo(null);
		
		String url = "C://Users//" + System.getProperty("user.name") + "//Documents//school//Java//Images//Fishy//";
		try {
			Images.fish = ImageIO.read(new File(url + "fish.png"));
			Images.enFish = ImageIO.read(new File(url + "enFish.png"));
			Images.startScreenBackground = ImageIO.read(new File(url + "startscreen.png"));
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		screenManager = new ScreenManager(new StartScreen());
		//ScreenManager.currentScreen);
		
		loop();
	}
	
	private static void loop()
	{
		long dt = 0;
		long last = System.currentTimeMillis();
		
		while(Constants.running)
		{
			dt = System.currentTimeMillis() - last;
			
			if (dt > 10)
			{
				last = System.currentTimeMillis();
				
				// updates
				screenManager.Update(dt);
				
				Constants.image = Constants.STAGE.createImage(Constants.ScreenWidth, Constants.ScreenHeight);
				Constants.graphics = Constants.image.getGraphics();
				
				// draws
				screenManager.Draw(Constants.graphics);
				
				Constants.STAGE.repaint();
			}
		}
	}
}
