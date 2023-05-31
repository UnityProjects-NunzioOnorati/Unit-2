using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    int index = 0;
    void Start()
    {
        transform.position = new Vector3(1, 2, 3);
        
        Material material = Renderer.material;
        
        material.color = new Color(0.81f, 0.24f, 0.25f, 0.4f);
    }
    
    void Update()
    {
        index++;
        float coeff = Mathf.Sin(Mathf.Log(Time.deltaTime*index));
        if(coeff<0) coeff = 0;
        transform.localScale = 10 * Vector3.one * coeff;
        transform.Rotate(19.0f * Time.deltaTime, 0.0f, 0.0f);
    }
}
