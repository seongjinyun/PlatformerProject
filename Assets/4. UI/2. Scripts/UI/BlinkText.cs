using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class BlinkText : MonoBehaviour
{
	public float time;

    void Update()
    {
        if (time < 0.75f)
        {
            GetComponent<Text>().color = new Color(1, 1, 1, 1 - time);
        }
        else
        {
            GetComponent<Text>().color = new Color(1, 1, 1, time);
            if (time > 1.5f)
            {
                time = 0;
            }
        }

        time += Time.deltaTime;

    }
}
