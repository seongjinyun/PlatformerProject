using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gemstone : MonoBehaviour
{
    public Sprite GroundGem, IceGem, FireGem ,WindGem;
    public Image GroundGemimg, IceGemimg, FireGemimg ,WindGemimg;
    // Update is called once per frame
    void Update()
    {   
        if (BoolManager.FirstStageBossDie == true)
        {
            GroundGemimg.sprite = GroundGem;
        }
        /*else
        {
            GroundGemimg.sprite = null;
        }*/
        if (BoolManager.SecondStageBossDie)
        {
            IceGemimg.sprite = IceGem;
        }
        if (BoolManager.ThirdStageBossDie)
        {
            FireGemimg.sprite = FireGem;
        }
        if (BoolManager.FourthStageBossDie)
        {
            WindGemimg.sprite = WindGem;
        }
    }
}
