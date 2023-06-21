using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Change_dash()
    {
        gameObject.layer = 16; // 16레이어로 바뀜
        StartCoroutine("dash_layer");
    }


    IEnumerator dash_layer()
    {
        yield return new WaitForSeconds(1f);
        gameObject.layer = 6;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
