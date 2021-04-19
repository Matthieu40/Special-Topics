using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Entity
{
    //variables
    private int level;
    private float currentExp;
    private float expGoal;

    //UI
    public Image healthBar;
    public Image expBar;
    private float healthVal;
    public Text levelText;

    //methods
    void Start()
    {
        healthVal = health;
        levelUp();//Starts player at level1
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0,healthVal);
        updateHealthUI();
        
    }

    public void updateHealthUI()
    {
        float fill = healthBar.fillAmount;
        float hFraction = health / healthVal;
        if(fill > hFraction)
        {
            healthBar.fillAmount = hFraction;
        }
    }

    
    public void AddExperience(float exp)//allows for exp gain
    {
        currentExp += exp;
        float fillE = expBar.fillAmount;
        float eFraction = currentExp / expGoal;
        if (fillE < eFraction)
        {
            expBar.fillAmount = eFraction;
        }

        if(currentExp >= expGoal)//when you meet an experience goal, level up
        {
            currentExp -= expGoal;
            levelUp();
            expBar.fillAmount = 0;
        }

        levelText.text = "" + level;

    }

    private void levelUp()//adds 1 level to current. 
    {
        level++;
        expGoal = level * 50 + Mathf.Pow(level * 2, 2);//pushes exp goal back

        AddExperience(0);

    }
}
