using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ImageTaimer HarvestTaimer;
    public ImageTaimer EatingTimer;
    public Image RaidTimerImg;
    public Image PeasantTimerImg;
    public Image WarriorTimerImg;
    public Button peasantButton;
    public Button wariorButton;

    public TMP_Text resourcesText;

    public int peasantCount;
    public  int warriorsCount;
    public int wheatCount;

    public int wheatPerPeasant;
    public int wheatToWarriors;

    public int peasantCost;
    public int warriorCost;

    public float peasantCreateTime;
    public float warriorCreateTime;
    public float raidMaxTime;
    public  int raidIncrease;
    public int nextRaid;
    public GameObject GameOverScreen;
    private float peasantTimer = -2;
    private float warriorTimer = -2;
    private float raidTimer;
    private int statisticWarrior = 0;
    public TMP_Text statisticWarriorText;
     private int statisticPeasant = 0;
    public TMP_Text statisticPeasantText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
        raidTimer = raidMaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        raidTimer -= Time.deltaTime;
        RaidTimerImg.fillAmount = raidTimer / raidMaxTime;
        

        if (raidTimer <= 0)
        {
            raidTimer = raidMaxTime;
            warriorsCount -= nextRaid;
            nextRaid += raidIncrease;
        }
        if (HarvestTaimer.Tick)
        {
            wheatCount += peasantCount * wheatPerPeasant;
        }

        if (EatingTimer.Tick)
        {
            wheatCount -= warriorsCount * wheatToWarriors;
        }
        
        if (peasantTimer > 0)
        {
            peasantTimer -= Time.deltaTime;
            PeasantTimerImg.fillAmount = peasantTimer / peasantCreateTime;
        }
        else if (peasantTimer > -1)
        {
            PeasantTimerImg.fillAmount = 1;
            peasantButton.interactable = true;
            peasantCount += 1;
            peasantTimer = -2;
        }

        if (warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            WarriorTimerImg.fillAmount = warriorTimer / warriorCreateTime;
        }

        else if(warriorTimer > -1)
        {
            WarriorTimerImg.fillAmount = 1;
            wariorButton.interactable = true;
            warriorsCount +=1;
            warriorTimer = -2;
        }

        StatisticWarriorText();
        StatisticPeasantText();

        UpdateText();

        if (warriorsCount < 0)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
    }

    public void CreatePeasant()
    {
        wheatCount -= peasantCost;
        peasantTimer = peasantCreateTime;
        statisticPeasant +=1;
        peasantButton.interactable = false;
    }

    public void CreateWarrior()
    {
        wheatCount -= warriorCost;
        warriorTimer = warriorCreateTime;
        statisticWarrior +=1;
        wariorButton.interactable = false;
        
    }

    private void UpdateText()
    {
        resourcesText.text = peasantCount + "\n" + warriorsCount + "\n\n" + wheatCount;
    }
    private void StatisticWarriorText()
    {
        statisticWarriorText.text = statisticWarrior.ToString();
    }

    private void StatisticPeasantText()
    {
        statisticPeasantText.text = statisticPeasant.ToString();
    }
}
