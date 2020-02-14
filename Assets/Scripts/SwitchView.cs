using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchView : MonoBehaviour
{

    public GameObject room;
    public GameObject ceiling_view;
    private bool i = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchViewBtn()
    {
        if (i)
        {
            room.SetActive(false);
            ceiling_view.SetActive(true);
        }
        else
        {
            room.SetActive(true);
            ceiling_view.SetActive(false);
        }
        i = !i;
    }

}
