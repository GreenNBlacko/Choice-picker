using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public static TextMeshProUGUI buttonText;

    public int ID;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(string Text,int ButtonID) {
        Debug.Log("Setup loaded");
        buttonText = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ID = ButtonID;
        buttonText.text = Text;
        gameObject.name = Text;
        Debug.Log("" + Text);
        Debug.Log("ID: " + ButtonID);
    }

    public void remove () {
        GameObject.Find("ScriptHandler").GetComponent<generator>().removeIdea(ID);
        Destroy(gameObject);
    }
}
