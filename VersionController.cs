using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VersionController : MonoBehaviour
{

    public string VersionNumber = "1.0";

    public TextMeshProUGUI VersionText;

    void Update()
    {
        VersionText.text = "Version: " + VersionNumber;
    }
}
