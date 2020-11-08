using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GraphBuild : MonoBehaviour
{
    private int[,] cases = {{1,7,8,9,11,11,11,12,13,13,13,13,15,15,15,15,15,15,15,15,15,15,15,15,15,15,17,21,47,57},{111,129,157,196,262,400,684,847,902,1139,1296,1567,2369,3062,3795,4838,6012,7156,8198,14138,18187,21463,24774,29212,31554,36508,42288,48582,52547,57298}};
    public GameObject DataPoint;
    float timer = 1;
    int idHighlightDataPoint = 1;
    // Start is called before the first frame update
    void Start()
    {
        Renderer grapthRender = gameObject.GetComponent(typeof(Renderer)) as Renderer;
        Vector3 graphSize = grapthRender.bounds.size;
        float maxElement = cases.Cast<int>().Max();
        for (int z = 0; z < cases.Length/30; z++)
        {
            for (int x = 0; x < 30; x++)
            {
                GameObject dataPoint = Instantiate(DataPoint, new Vector3(0,0,0), Quaternion.identity);
                float dataPointXscale = (float)(graphSize.x/((cases.Length)));
                float dataPointYscale = (float)(graphSize.y/maxElement) * cases[z,x];
                float dataPointZscale = (float)(graphSize.z/((cases.Length)));

                dataPoint.transform.localScale = new Vector3(dataPointXscale, dataPointYscale, dataPointZscale);
                dataPoint.transform.parent = gameObject.transform;
                Vector3 dataPointSize = dataPoint.transform.localScale;
                float dataPointXpos = (-1/2f)+(dataPointSize.x/2f);
                float dataPointYpos = (-1/2f)+(dataPointSize.y/2f);
                float dataPointZpos = (-1/2f)+(dataPointSize.z/2f);
                dataPoint.transform.localPosition = new Vector3(dataPointXpos + ((dataPoint.transform.localScale.x*2)*x), dataPointYpos, dataPointZpos + ((dataPoint.transform.localScale.z*2)*z));
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        GameObject caseCountText = gameObject.transform.GetChild(0).gameObject;
        
        if(timer > 0.1)
        {
            timer = 0;
            
           
            if(idHighlightDataPoint < gameObject.transform.childCount)
            {
                GameObject currentChild = gameObject.transform.GetChild(idHighlightDataPoint).gameObject;
                currentChild.GetComponent<Renderer>().material.color = Color.green;
                if(idHighlightDataPoint > 1)
                {
                    GameObject lastChild = gameObject.transform.GetChild(idHighlightDataPoint-1).gameObject;
                    lastChild.GetComponent<Renderer>().material.color = Color.red;
                }
                idHighlightDataPoint++;
            }
            else
            {
                GameObject currentChild = gameObject.transform.GetChild(idHighlightDataPoint-1).gameObject;
                currentChild.GetComponent<Renderer>().material.color = Color.red;
                idHighlightDataPoint = 1;
            }
            caseCountText.GetComponent<TextMesh>().text = cases.Cast<int>().ToArray()[idHighlightDataPoint-1].ToString();
        }

    }
}
