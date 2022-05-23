using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPaintChanger : MonoBehaviour
{

    public Color[] Colors; //choose your favorite colors here

    // Start is called before the first frame update
    void Start()
    {
        int carcolor = Random.Range(0, Colors.Length);

        foreach (Transform carpart in transform)
        {
            
            if (carpart.GetComponent<MeshRenderer>().material.name.Contains("carpaint"))
            {
                carpart.GetComponent<MeshRenderer>().material = new Material(carpart.GetComponent<MeshRenderer>().material);
                carpart.GetComponent<MeshRenderer>().material.color = Colors[carcolor];
            }
               

        }
    }

 
}
