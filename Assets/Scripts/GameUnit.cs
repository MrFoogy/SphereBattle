using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType
{
    GROUND, FLYING
}

public abstract class GameUnit : MonoBehaviour {
    public string unitName;
    public int cost;
    public bool selected = false;

    public int health;
    public int maxHealth;
    public int armor;
    public Weapon weapon;

    public int movement;
    public MovementType movementType;

    // Use this for initialization
	void Start () {
        
	}

    // perhaps have armor on stuff?
    public void TakeDamage(int damage) 
    {
        health -= damage > armor ? damage - armor : 0;
        if (health <= 0)
            Destroy(this);
    }
    
    // the "whether or not you can reach" check is not done here, should be done in higher up logic
	public void Attack(GameTile tile)
    {
        tile.currentUnit.TakeDamage(weapon.damage * (health / maxHealth));
    }



	
    // Update is called once per frame
	void Update () {
		
	}
}
