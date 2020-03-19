using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int ctr = 0;

    public List<bool> states;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Plugin.instance.runner();

        states = new List<bool>();
        ArrayList ar = Plugin.instance.jc.Call<ArrayList>("getStateInit");
        // To Test using rpi/hardware/mqtt
        
        for (int i = 0; i < ar.Count; i++)
        {
            states.Add((String)ar[i] == "1" ? true : false);
        }
        
/*
        // To Test in Unity
        states.Add(true);
        states.Add(false);
        states.Add(true);
        states.Add(false);
        states.Add(true);
        states.Add(true);
        states.Add(false);
        states.Add(true);
        states.Add(false);
        states.Add(true);
        states.Add(true);
        states.Add(false);
        states.Add(true);
        states.Add(false);
        states.Add(true);
*/
       for (int i = 0; i < states.Count; i++)
            Debug.Log(states[i]);
  }

    void Update()
    {

    }
}
