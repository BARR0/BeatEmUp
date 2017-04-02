using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public string number;

    private PlayerMove player;
    private Slider slider;
    private Text text;
	// Use this for initialization
	void Start () {
        Transform sliderTransform = transform.GetChild(0);
        slider = sliderTransform.GetComponent<Slider>();

        Transform textTransform = transform.GetChild(1);
        text = textTransform.GetComponent<Text>();

        List<PlayerMove> players = GameController.players;
        foreach(PlayerMove pm in players)
        {
            if(pm.inputAxis == number)
            {
                player = pm; 
            }
        }
        if(player == null)
        {
            Destroy(gameObject);
        }

        slider.maxValue = player.life;
        slider.minValue = 0;
        text.text = "Player " + player.inputAxis;
		
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = player.life;
	}
}
