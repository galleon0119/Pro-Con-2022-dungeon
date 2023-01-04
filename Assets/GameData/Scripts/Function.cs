using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function
{
    public static Function instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Tryori()
    {
        Debug.Log("AA");
    }
  

    public void Move_UP()
    {
        
    }
}