using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentRoomNumber;
    public int cointCount;
    public GameObject hammerUpgrade;
    public GameObject swordUpgrade;
    public bool newSword = false;
    public bool newHammer = false;

    public GameObject scene0;
    public GameObject scene1;

    public TMP_Text coinText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = cointCount.ToString();
        if (currentRoomNumber == 0)
        {
            scene0.SetActive(true);
            scene1.SetActive(false);
        }
        if (currentRoomNumber == 1)
        {
            scene0.SetActive(false);
            scene1.SetActive(true);
        }
    }

    public void addCoin()
    {
        cointCount++;
    }
    public void buyHammer()
    {
        if (cointCount >= 10)
        {
            hammerUpgrade.SetActive(true);
            newHammer = true;
        }
    }
    public void buySword()
    {
        if (cointCount >= 10)
        {
            swordUpgrade.SetActive(true);
            newSword = true;
        }
    }
}