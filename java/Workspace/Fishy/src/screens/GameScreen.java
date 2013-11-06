package screens;
import resources.Constants;

import java.awt.Graphics;
import java.util.ArrayList;
import java.util.Random;

import content.player.Player;
import content.enemys.Enemy;

public class GameScreen extends Screen
{
	int maxEnemys = 40;
	float timer;
	Player player;
	ArrayList<Enemy> enemys;
	
	public GameScreen()
	{
		enemys = new ArrayList<Enemy>();
		timer = 5;
		
		player = new Player(100, 100);
		Constants.STAGE.addKeyListener(player);
	}
	
	public void Update(long dt)
	{
		player.Update(dt);
		
		timer -= (float)dt / 100;
		
		if (timer < 0)
		{
			Random random = new Random();
			timer = 2 + random.nextInt(4);
			
			enemys.add(new Enemy());
		}
		
		for (int i = 0; i < enemys.size(); i++)
		{
			Enemy enemy = enemys.get(i);
			
			enemy.Update(dt);
			
			if (enemy.x > Constants.ScreenWidth || enemy.x < -enemy.width*enemy.size)
				enemys.remove(enemy);
			else if (player.bounds.Intersects(enemy.bounds))
			{
				if (enemy.size < player.size)
				{
					player.size += 0.1;
					enemys.remove(enemy);
				}
				else
					ScreenManager.currentScreen = new StartScreen();
			}
		}
		
		if (player.size >= 6)
		{
			// TODO Win
			player.size = 6;
		}
	}
	
	public void Draw(Graphics g)
	{
		player.Draw(g);
		
		for (int i = 0; i < enemys.size(); i++)
			enemys.get(i).Draw(g);
	}
}
