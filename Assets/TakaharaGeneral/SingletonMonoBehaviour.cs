using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)(object)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    Debug.Log(typeof(T) + "がシーンに存在しません");
                }


            }
            return instance;
        }
    }
}
