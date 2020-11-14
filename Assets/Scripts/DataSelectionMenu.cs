using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSelectionMenu : MonoBehaviour
{

    public Button InvokeDataSelectionMenu;
    public Toggle ToggleUI;

    String[] criteria = {"Deaths", "Cases", "Recoveries", "Germany", "Italy", "US"};
    // Start is called before the first frame update
    void Start()
    {
        Button btn = InvokeDataSelectionMenu.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){

        for (int i = 0; i < criteria.Length; i++)
        {
            Toggle checkBox = Instantiate(ToggleUI, new Vector3(0,0,0), Quaternion.identity);
            RectTransform recTransform = checkBox.transform.GetComponent<RectTransform>();
            checkBox.transform.SetParent(gameObject.transform);

            float leftBorderPosX = -(gameObject.transform.GetComponent<RectTransform>().sizeDelta.x/2f);
            float bottomBorderPosY = -(gameObject.transform.GetComponent<RectTransform>().sizeDelta.y/2f);

            recTransform.pivot = new Vector2(0,0);
            checkBox.transform.localScale = new Vector3(1,1,1);
            recTransform.localPosition = new Vector3(leftBorderPosX+10,bottomBorderPosY+(80 + i*20),0);
            recTransform.rotation = gameObject.transform.rotation;
            checkBox.transform.GetChild(1).GetComponent<Text>().text = criteria[i];

        }

	}

    // Update is called once per frame
    void Update()
    {
       
    }
}
