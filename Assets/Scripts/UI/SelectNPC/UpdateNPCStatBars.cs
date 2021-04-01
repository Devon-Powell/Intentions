using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateNPCStatBars : MonoBehaviour
{
    public static UpdateNPCStatBars instance;
    private NPCData _npcData;
    
    public Image healthBar;
    public Image mentalHealthBar;
    public Image hungerBar;
    public Image energyBar;
    public Image testBar; //del on build

    public Gradient barGradient;

    private float updateTime;

    private void Awake()
    {
        instance = this;
        updateTime = 0.1f;
    }

    public void SetSelectedNPC(NPCData data)
    {
        _npcData = data;
        StartCoroutine("UpdateTimer", updateTime);
    }
    
    public void ClearSelectedNPC()
    {
        StopCoroutine("UpdateTimer");
        
        
    }
    
    private void UpdateStatBars()
    {
        const float statMinimum = 0;
        const float statMaximum = 100;
        const float statNewMinimum = 0;
        const float statNewMaximum = 1;
        
        //Health Bar
        float healthNormalized = Utility.ConvertRange(_npcData.currentHealth, statMinimum, statMaximum, statNewMinimum, statNewMaximum);
        healthBar.fillAmount = healthNormalized;
        healthBar.color = barGradient.Evaluate(healthNormalized);
        
        float mentalHealthNormalized = Utility.ConvertRange(_npcData.currentMentalHealth, statMinimum, statMaximum, statNewMinimum, statNewMaximum);
        mentalHealthBar.fillAmount = mentalHealthNormalized;
        mentalHealthBar.color = barGradient.Evaluate(mentalHealthNormalized);
        
        float hungerNormalized = Utility.ConvertRange(_npcData.currentHunger, statMinimum, statMaximum, statNewMinimum, statNewMaximum);
        hungerBar.fillAmount = hungerNormalized;
        hungerBar.color = barGradient.Evaluate(hungerNormalized);
        
        float energyNormalized = Utility.ConvertRange(_npcData.currentEnergy, statMinimum, statMaximum, statNewMinimum, statNewMaximum);
        energyBar.fillAmount = energyNormalized;
        energyBar.color = barGradient.Evaluate(energyNormalized);

        testBar.color = barGradient.Evaluate(testBar.fillAmount);

    }

    private IEnumerator UpdateTimer(float waitTime)
    {
        while (true)
        {
            UpdateStatBars();
            yield return new WaitForSeconds(waitTime);
        }
    }
}
