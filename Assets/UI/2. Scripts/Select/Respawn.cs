using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject[] charPrebabs;
    public GameObject player;
    void Start()
    {
        player = Instantiate(charPrebabs[(int)DataMgr.instance.currentCharacter]);
        player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
