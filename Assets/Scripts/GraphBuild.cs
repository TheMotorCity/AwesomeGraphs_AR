using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphBuild : MonoBehaviour
{
    public GameObject DataPoint_Bar;

    // Start is called before the first frame update
    void Start()
    {
        int[] cases = {7,8,9,11,11,11,12,13,13,13,13,15,15,15,15,15,15,15,15,15,15,15,15,15,15,17,21,47,57};
        
        for (int i = 0; i < cases.Length; i++)
        {
            for (int j = 0; j < cases[i]; j++)
            {
                Instantiate(DataPoint_Bar, new Vector3(((i+1f)/9f), (j+1f)/9f, 0f), Quaternion.identity);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
