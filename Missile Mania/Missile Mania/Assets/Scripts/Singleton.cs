using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    public static T _instance;

    public static T Instance
    {
        get
        {
            //Check if instance is null
            if (_instance == null)
            {
                //First try to find the object already in the scene
                _instance = GameObject.FindObjectOfType<T>();

                if (_instance == null)
                {
                    //Couldn't find the singleton instance so instantiate it
                    GameObject singleton = new GameObject(typeof(T).Name);
                    _instance = singleton.AddComponent<T>();
                    return _instance;
                }
                return _instance;
            }
            return _instance;
        }
    }
}
