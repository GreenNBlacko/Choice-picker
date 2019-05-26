using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Menu2;

    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(true);
        Menu2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int MenuNumber { private get; set; }
    public void SwitchMenu() {
        if(MenuNumber == 0) {
            Menu.SetActive(true);
            Menu2.SetActive(false);
        } else {
            Menu.SetActive(false);
            Menu2.SetActive(true);
        }
        gameObject.GetComponent<Animator>().SetTrigger("FadeOut");
    }
}
