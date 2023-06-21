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
        if (savedObject.Contains(obj)) // obj �� ����ִ��� Ȯ��
        {
            savedObject.Remove(obj); // �ִٸ� ����

            if (savedObject.Count > 15) // savedObject ����Ʈ�� ���� ������ Ȯ���ϰ�, �� �̻��� ������ ������������
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
