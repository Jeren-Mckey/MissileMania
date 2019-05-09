using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GlobalControl : MonoBehaviour
{
    private static int points;
    private static int progress;
    private static Slider slider;
    public Slider temp;
    public Button temp2;
    public static Button triggerStrike;   //reference for button
    private static bool isTriggerStrike = false; //flag to see if progress full

    public static GlobalControl Instance;

    void Awake ()   
    {
        points = 0;
        progress = 0;
        isTriggerStrike = false;
        triggerStrike = temp2;
        slider = temp;
        triggerStrike.gameObject.SetActive(false);
        if (slider != null) slider.value = 0;
        
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

    public static void addPoints(int num)
    {
        points = num;
    }

    public static void addProgress()
    {
        //if player triggers fire object and health is greater than 0
        if(slider.value <= 100){
            slider.value += 5f;  //increase progress to explosion
        }
        else{
            isTriggerStrike = true;   
            triggerStrike.gameObject.SetActive(true);
        }
    }

    public static int getPoints(){ return points; }
}
