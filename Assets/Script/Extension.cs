using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension 
{
    
    public static Vector3  MousePosition()
    {
        Vector3 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseInput.z = 0;
        return mouseInput;
    }

    public static Vector3 RandomPos()
    {
        return new Vector3(
            Random.Range(-2, 2),
            Random.Range(-2, 2));
    }
}
