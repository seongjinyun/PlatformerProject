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
        /*Object.Destroy(obj);
        savedObject.RemoveRange(0,15);*/
        if (savedObject.Contains(obj)) // obj 가 들어있는지 확인
        {
            savedObject.Remove(obj); // 있다면 삭제

            if (savedObject.Count > 15) // savedObject 리스트의 원소 개수를 확인하고, 그 이상의 범위를 지정하지않음
            {
                savedObject.RemoveRange(0, savedObject.Count - 15);
            }
        }

        Object.Destroy(obj);
    }

    public static List<Object> GetSaveObjects()
    {
        return new List<Object>(savedObject);
    }

}
