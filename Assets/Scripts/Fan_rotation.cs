using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_rotation : MonoBehaviour
{
    public Transform rotatable_part;
    float spinSpeed = 400.0f;
    bool isTap = false;
    // Start is called before the first frame update
     void OnMouseDown()
    {
        isTap = !isTap;
    }
    void Start()
    {
        spinSpeed = Random.Range(300, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTap)
        { 
            rotatable_part.Rotate(0, spinSpeed * Time.deltaTime, 0);
            Plugin.instance.jc.Call("Fan", "On");
        }
        else
        {
            Plugin.instance.jc.Call("Fan", "Off");
        }
        // else { transform.Rotate(0, 0, 0); }

    }
}
