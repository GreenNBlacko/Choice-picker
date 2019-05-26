using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class generator : MonoBehaviour {
    public static generator instance;
    public string[] ideas;
    public TextMeshProUGUI ideaOut;

    public TMP_InputField SearchTextInputText;

    public GameObject ButtonPreset;

    public Transform ButtonArray;

    // Start is called before the first frame update
    void Start () {
        instance = this;
    }

    // Update is called once per frame
    void Update () {

    }

    public void pickIdea () {
        if(ideas.Length > 0) {
            int i = UnityEngine.Random.Range (0, ideas.Length);
            ideaOut.text = ideas[i];
        }
        
    }

    public void addIdea (TMP_InputField idea) {
        string ideaText = idea.text;
        int i = ideas.Length + 1;
        Array.Resize (ref ideas, i);
        ideas[i - 1] = ideaText;
        GameObject Button = (GameObject) Instantiate (ButtonPreset, transform.position, transform.rotation);
        Button.transform.SetParent (ButtonArray);
        Button.GetComponent<ButtonScript> ().Setup (ideaText, i - 1);
    }

    public void removeIdea (int ID) {
        int i;
        if (ideas.Length - 1 > 0) { i = ideas.Length - 1; } else {
            i = 0;
            ID = 0;
        }
        if(ID >= ideas.Length-1) { ID = i; }
        ideas[ID] = ideas[i];
        foreach (Transform Button in ButtonArray) {
            if(Button.name == ideas[i]) {
                Button.GetComponent<ButtonScript>().ID = ID;
            }
        }
        Array.Resize (ref ideas, i);
    }

    public void removeAllIdeas () {
        Array.Resize (ref ideas, 0);
        foreach (Transform Button in ButtonArray) {
            Button.GetComponent<ButtonScript> ().remove ();
        }
    }

    public void SearchBarRenewData () {
        if (SearchTextInputText.text != "") {
            foreach (Transform Button in ButtonArray)
            {
                for(int i = 0; i < SearchTextInputText.text.Length; i++) {
                    for(int o = 0; o < Button.GetChild(0).GetComponent<TextMeshProUGUI>().text.Length; o++) {
                        if(Button.GetChild(0).GetComponent<TextMeshProUGUI>().text[o] == SearchTextInputText.text[i]) {Button.gameObject.SetActive(true);}
                        else {
                            if(i >= Button.GetChild(0).GetComponent<TextMeshProUGUI>().text.Length) {
                                Button.gameObject.SetActive(false);
                            } else {
                                if(SearchTextInputText.text[i] != SearchTextInputText.text.Length-1 && Button.GetChild(0).GetComponent<TextMeshProUGUI>().text[i] == SearchTextInputText.text[i]) {
                                    Button.gameObject.SetActive(true);
                                } else {
                                    Button.gameObject.SetActive(false);
                                }
                            }
                        }
                    }
                }
            }
        } else {
            foreach (Transform Button in ButtonArray) {
                Button.gameObject.SetActive (true);
            }
        }
    }
}