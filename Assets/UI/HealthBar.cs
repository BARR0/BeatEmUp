using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public string number;

    private PlayerController player;
    private Slider slider;
    private Text text;
    // Use this for initialization
    void Start() {
        if(this.number == "1")
        {
            this.number = "";
        }
        Transform sliderTransform = transform.GetChild(0);
        slider = sliderTransform.GetComponent<Slider>();
        player = null;
        Transform textTransform = transform.GetChild(1);
        text = textTransform.GetComponent<Text>();

        foreach (PlayerController pc in GameController.players) {   
            if (pc.inputAxis == number)
            {
                player = pc;
                break;
            }
        }
        if (player == null)
        {
            Debug.Log(gameObject.name + " was destroyed");
            Destroy(gameObject);
            return;
        }
        slider.maxValue = player.maxlife;
        //Debug.Log(player.inputAxis + " " + player.life + " " + player.Level);
        slider.minValue = 0;
        text.text = "Player " + player.inputAxis + " Level " + (player.Level);
	}
	
	// Update is called once per frame
	void Update () {
		slider.maxValue = player.maxlife;
        slider.value = player.life;
        text.text = "Player " + player.inputAxis + " Level " + (player.Level);
    }
}
