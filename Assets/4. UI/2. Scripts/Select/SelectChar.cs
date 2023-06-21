using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public Character character;
    void Start()
    {
    }

    public void CharSelect()
    {   
        DataMgr.instance.currentCharacter = character;
    }
}
