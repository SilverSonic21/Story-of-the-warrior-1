using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class Health : MonoBehaviour
{
 public PlayerControler player;
    public TMP_Text healthText;

    void Update()
    {
        if (player != null)
        {
            healthText.text = "Health: " + player.Health.ToString("0");
        }
    }
}
