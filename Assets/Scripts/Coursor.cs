using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coursor : MonoBehaviour
{
    public bool cursor;
    // Start is called before the first frame update
    void Start()
    {
        if (cursor)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!cursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }

    
}
