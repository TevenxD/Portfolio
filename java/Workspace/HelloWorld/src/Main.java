import javax.swing.JFrame;


public class Main 
{
	public static void main(String[] args)
	{
		new Main();
	}
	
	private static Test test;
	
	public Main()
	{
		Constants.STAGE.setTitle("Lol");
		Constants.STAGE.setUndecorated(true);
		Constants.STAGE.setVisible(true);
		Constants.STAGE.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		Constants.STAGE.setSize(800, 600);
		Constants.STAGE.setLocationRelativeTo(null);
		
		test = new Test();
		
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
				
				//updates aanroepen
				test.update(dt);
				
				Constants.image = Constants.STAGE.createImage(800, 600);
				Constants.graphics = Constants.image.getGraphics();
				
				// draw aanroepen
				test.draw(Constants.graphics);
				
				Constants.STAGE.repaint();
			}
		}
	}
}
