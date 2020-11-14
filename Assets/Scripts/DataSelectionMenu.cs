using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSelectionMenu : MonoBehaviour
{

    public Button InvokeDataSelectionMenu;
    public Toggle ToggleUI;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = InvokeDataSelectionMenu.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
		Toggle checkBox = Instantiate(ToggleUI, new Vector3(0,0,0), Quaternion.identity);
        checkBox.transform.SetParent(gameObject.transform);
        checkBox.transform.localScale = new Vector3(1,1,1);
        RectTransform recTransform = checkBox.transform.GetComponent(typeof(RectTransform)) as RectTransform;
        recTransform.anchoredPosition = new Vector3(0,0,0);
        Debug.Log(recTransform.anchoredPosition);
        recTransform.anchorMax = new Vector2(0,0);
        recTransform.anchorMin = new Vector2(0,0);
        recTransform.position = new Vector3(50,100,0);
      
	}

    // Update is called once per frame
    void Update()
    {
       
    }
}
