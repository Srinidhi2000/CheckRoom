using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Switching : MonoBehaviour
{

    public Texture tex1;
    public Texture tex0;
    private bool i = true;
    private Material new_mat;
    private MeshRenderer meshRenderer;
    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        //tex0 = transform.parent.GetComponent<MeshRenderer>().sharedMaterial.mainTexture;
        new_mat = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
        new_mat.mainTexture = tex0;
        parent = transform.parent;
        meshRenderer = parent.GetComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new_mat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        SwitchLights();
    }

    private void SwitchLights()
    {
        if (i)
        {
            Plugin.instance.jc.Call("Light", "On");
            meshRenderer.sharedMaterial.mainTexture = tex1;
            parent.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            Plugin.instance.jc.Call("Light", "Off");
            meshRenderer.sharedMaterial.mainTexture = tex0;
            parent.GetChild(0).gameObject.SetActive(true);
        }
        i = !i;
    }
}
