using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerManager : MonoBehaviour
{
    public GameObject hungerBar;
    public GameObject fill;
    public Vector3 offsetPosition;
    public int hungerPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        offsetPosition = new Vector3(0,4f,0);
        hungerPoints = 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(hungerPoints == 3)
        {
            var instantiatedBar = Instantiate(hungerBar, transform.position, transform.rotation);
            instantiatedBar.transform.parent = gameObject.transform;
            instantiatedBar.transform.position = gameObject.transform.position + offsetPosition;
            instantiatedBar.transform.localScale *= 10; 
        }
        addFill();
        hungerPoints--;
        if(hungerPoints == 0)
        {
            Destroy(gameObject);
        }
    }

    void addFill()
    {
        var instantiatedBar = GameObject.Find("HungerBar(Clone)");
        var barRenderer = instantiatedBar.GetComponent<Renderer>();
        var instantiatedFill = Instantiate(fill, transform.position, instantiatedBar.transform.rotation);
        instantiatedFill.transform.parent = instantiatedBar.transform;
        var fillRenderer = instantiatedFill.GetComponent<Renderer>();
        float barWidth = barRenderer.bounds.size[0];
        float fillWidth = fillRenderer.bounds.size[0]*10;

        if(transform.rotation[1] == -1)
        {
            instantiatedFill.transform.position = instantiatedBar.transform.position + new Vector3(barWidth/2,0.1f,0) + new Vector3(-fillWidth/2-(3-hungerPoints)*fillWidth,0,0);
        }
        else
        {
            barWidth = barRenderer.bounds.size[2];
            fillWidth = fillRenderer.bounds.size[2]*10;
            if (transform.rotation[1] > 0)
            {
                instantiatedFill.transform.position = instantiatedBar.transform.position + new Vector3(0,0.1f,barWidth/2) + new Vector3(0,0,-fillWidth/2-(3-hungerPoints)*fillWidth);
            }
            else if (transform.rotation[1] < 0)
            {
                instantiatedFill.transform.position = instantiatedBar.transform.position + new Vector3(0,0.1f,-barWidth/2) + new Vector3(0,0,fillWidth/2+(3-hungerPoints)*fillWidth);
            }
        }
        instantiatedFill.transform.localScale *= 10; 
    }
}
