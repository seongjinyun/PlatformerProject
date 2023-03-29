using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DontDestroyObj { 
    public static List<Object> savedObject = new List<Object>();

    public static void DontDestroyOnLoad(this Object obj)
    {
        savedObject.Add(obj);
        Object.DontDestroyOnLoad(obj);
    }
    public static void Destroy(this Object obj)
    {
        Destroy(obj);
        savedObject.RemoveRange(0,15);
    }

    public static List<Object> GetSaveObjects()
    {
        return new List<Object>(savedObject);
    }

}
