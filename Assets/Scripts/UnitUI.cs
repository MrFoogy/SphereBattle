using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour {
    public Slider healthSlider;
    public Text healthText;
	// Use this for initialization
	void Start () {
		
	}
	
    public void SetContent(GameUnit unit)
    {
        healthSlider.maxValue = unit.maxHealth;
        healthSlider.minValue = 0;
        healthSlider.value = unit.health;
        healthText.text = "" + unit.health + "/" + unit.maxHealth;
    }
}
