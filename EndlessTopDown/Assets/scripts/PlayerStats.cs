using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Entity
{
    //variables
    private int level;
    private float currentExp;
    private float expGoal;

    //methods
    void Start()
    {
        levelUp();
    }
    public void AddExperience(float exp)//allows for exp gain
    {
        currentExp += exp;
        if(currentExp >= expGoal)//when you meet an experience goal, level up
        {
            currentExp -= expGoal;
            levelUp();
        }

        Debug.Log("Exp: " + currentExp + "Level: " + level);
    }

    private void levelUp()//adds 1 level to current. 
    {
        level++;
        expGoal = level * 50 + Mathf.Pow(level * 2, 2);//pushes exp goal back

        AddExperience(0);

    }
}
