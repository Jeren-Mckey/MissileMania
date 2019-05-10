using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GlobalControl : MonoBehaviour
{
    private static int points;
    public static GlobalControl Instance;

    void Awake ()   
    {
        points = 0;
        
       
        
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }

    public static void addPoints()
    {
        points++;
    }

    public static int getPoints(){ return points; }
}
