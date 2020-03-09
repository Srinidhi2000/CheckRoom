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
        for (int i = 0; i < ar.Count; i++)
        {
            states[i] = (bool)ar[i];
        }
        Plugin.instance.jc.Call("unsubscribe");
    }

    void Update()
    {

    }
}
