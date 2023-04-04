using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePortal : MonoBehaviour
{
    public GameObject Portal;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Monster") ==  null)
        {
            Portal.gameObject.SetActive(true);
        }
        else
        {
            
        }

    }
}
