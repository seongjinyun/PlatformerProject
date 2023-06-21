using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneAlpha : MonoBehaviour
{
    public GameObject EasyStone,HardStone;
    public CanvasGroup easy, hard;

    Mode_Select mode;
    // Update is called once per frame

    private void Start()
    {
        mode = FindObjectOfType<Mode_Select>();
    }
    void Update()
    {
        if (BoolManager.BonginCom == true)
        {
            if(mode.Easy == true)
            { 
                easy.alpha += 0.01f;
            }
            else if(mode.Hard == true)
            {
                hard.alpha += 0.01f;
            }
        }
        else if(BoolManager.BonginCom == false)
        {
            easy.alpha = 0;
            hard.alpha = 0;
        }
    }
}
