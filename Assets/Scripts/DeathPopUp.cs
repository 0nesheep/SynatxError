using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathPopUp : MonoBehaviour
{
    public Text deathText;

    void Start()
    {
        if (deathText == null)
        {
            Debug.LogError("DeathText not assigned.");
        }
        gameObject.SetActive(false);
    }

    public void ShowDeathPopup()
    {
        gameObject.SetActive(true);
    }
}
