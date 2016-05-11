using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Health : NetworkBehaviour {

    [SyncVar (hook = "OnHealthChanged")] public int health = 100;
    private Text healthText;

	void Start ()
    {
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        SetHealthText();
	}

    void SetHealthText()
    {
        if (isLocalPlayer)
        {
            healthText.text = "Health" + health.ToString();
        }
    }

    public void DeductHealth (int dmg)
    {
        health -= dmg;
        Debug.Log(health);
    }

    void OnHealthChanged(int hlth)
    {
        health = hlth;
        SetHealthText();
    }
}
