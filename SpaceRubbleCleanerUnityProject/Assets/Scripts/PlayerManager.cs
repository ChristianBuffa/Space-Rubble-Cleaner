using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text rubbishText;
    [SerializeField] 
    private Canvas menuCanvas;
    [SerializeField] 
    private Canvas uiCanvas;
    
    private int collectedRubbish;

    private void Start()
    {
        rubbishText.text = "Collected Rubbish " + collectedRubbish;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rubbish")
        {
            collectedRubbish++;
            Destroy(other.gameObject);
            rubbishText.text = "Collected Rubbish " + collectedRubbish;
        }

        if (other.gameObject.tag == "planet")
        {
            gameObject.SetActive(false);
            uiCanvas.gameObject.SetActive(false);
            menuCanvas.gameObject.SetActive(true);
        }
    }
}
