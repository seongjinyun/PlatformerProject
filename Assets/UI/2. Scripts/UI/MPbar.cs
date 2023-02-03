using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPbar : MonoBehaviour
{

    public Slider mpbar;

    private int maxmp = 100;
    public float curmp;

    // Start is called before the first frame update
    void Start()
    {
       // curmp = Player_Anim.Skill_gauge;
        mpbar.value = (float)curmp / (float)maxmp;

    }

    // Update is called once per frame
    void Update()
    {
      //  curmp = Player_Anim.Skill_gauge;
        handleMp();

    }

    private void handleMp()
    {
        mpbar.value = (float)curmp / (float)maxmp;
    }
}
