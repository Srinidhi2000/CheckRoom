using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnController : MonoBehaviour
{

    public GameObject prop_prefab;
    private Vector3 sc;
    private Transform prop_clone;
    public Transform ceiling;
    public float distanceFromWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            prop_clone.eulerAngles += new Vector3(0, 90, 0);
        }
    }

    public void SpawnProp()
    {

        prop_clone = Instantiate(prop_prefab).transform;
        prop_clone.name = "sw" + GameManager.instance.ctr;
        if (prop_clone.GetChild(0).name.StartsWith("Capsule"))
        {
            Debug.Log("asdfgh");
            Fan_rotation fan_Rotation = prop_clone.GetChild(1).GetComponent<Fan_rotation>();
            fan_Rotation.isTap = !GameManager.instance.states[GameManager.instance.ctr];
            fan_Rotation.MouseDownHelper();
        }
        else if (prop_clone.GetChild(0).name.StartsWith("Point"))
        {
            Debug.Log("asdfgh");
            Light_Switching light_Switching = prop_clone.GetChild(1).GetComponent<Light_Switching>();
            light_Switching.i = !GameManager.instance.states[GameManager.instance.ctr];
            light_Switching.SwitchLights();
        }
        GameManager.instance.ctr++;
        prop_clone.parent = ceiling;
    }

    private void OnMouseDown()
    {
        SpawnProp();
    }

    private void OnMouseDrag()
    {
        //light_clone.transform.position = 
        // -------------- FOR ANDROID --------------
        /*
        if (Input.touchCount > 0)
        {
            sc = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            sc.z = 0;
            light_clone.transform.position = sc;
        }
        */
        // -------------- FOR EDITOR --------------
        GetInput();

        sc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        sc.y = ceiling.position.y + 5.3f;

        sc.x = Mathf.RoundToInt(sc.x);
        sc.z = Mathf.RoundToInt(sc.z);

        Debug.Log(sc);
        prop_clone.position = sc;
        
    }

    private void OnMouseUp()
    {
        Debug.Log(prop_clone.localPosition.x + " and " + (ceiling.GetChild(0).localScale.x / 2 - distanceFromWall));
        Debug.Log(prop_clone.localPosition.z + " and " + (ceiling.GetChild(0).localScale.z / 2 - distanceFromWall));
        if( Mathf.Abs(prop_clone.localPosition.x) > Mathf.Abs(ceiling.GetChild(0).localScale.x / 2 - distanceFromWall) ||
            Mathf.Abs(prop_clone.localPosition.z) > Mathf.Abs(ceiling.GetChild(0).localScale.z / 2 - distanceFromWall))
        {
            Destroy(prop_clone.gameObject); //use polling system later if needed
        }
        else
        {
            prop_clone.localPosition = new Vector3(prop_clone.localPosition.x, 5.3f, prop_clone.localPosition.z);
        }
    }

}
