using UnityEngine;

public class MuncherAttributes
{
    int health;
    int maxHealth;
    int score;

    public MuncherAttributes(int startHealth, int startMaxHealth, int startScore)
    {
        health = startHealth;
        maxHealth = startMaxHealth;
        score = startScore;
    }


    public int getHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getScore() 
    {
        return score;
    }

    public void setHealth(int newHealth) 
    {
        health = newHealth;
    }

    public void setMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
    }

    public void setScore(int newScore)
    {
        score = newScore;
    }

}
