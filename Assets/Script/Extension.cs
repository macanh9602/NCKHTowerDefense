using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension 
{
    
    public static Vector3  MousePosition()
    {
        Vector3 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mouseInput;
    }
}
