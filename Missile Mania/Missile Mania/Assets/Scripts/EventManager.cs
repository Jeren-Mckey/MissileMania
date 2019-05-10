using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour 
{
    public delegate void OnHit();
    public static event OnHit onHit;
    
    public static void RaiseOnHit()
    {
        if (onHit != null) onHit();
    }
   
}

