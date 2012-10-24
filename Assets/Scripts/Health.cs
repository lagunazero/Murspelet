using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int maxHealth;
	//[HideInInspector]
	public float currentHealth;
	[HideInInspector]
	public bool isAlive = true;
	public Color deathTint;
	
	private VictimInfo info;
	
	private static ActionMenu actionMenu;
	private static Log log;
	private static Text text;
	
	// Use this for initialization
	void Start ()
	{
		currentHealth = maxHealth;
		info = gameObject.GetComponent<VictimInfo>();
		if(actionMenu == null)
		{
			actionMenu = GameObject.Find("Main Camera").GetComponent<ActionMenu>();
			log = GameObject.Find("HUD").GetComponent<Log>();
			text = GameObject.Find("HUD").GetComponent<Text>();
		}
	}
	
	public void TakeDamage(int damage)
	{
		if(!isAlive)
		{
			log.Push(string.Format(text.shootDead, info.gender), Log.MessageType.shoot);
			return;
		}
		
		currentHealth -= damage;
		if(currentHealth <= 0)
		{
			log.Push(text.hitKilled, Log.MessageType.shoot);
			StartCoroutine(Die());
		}
		else if(currentHealth <= maxHealth * 0.2f)
			log.Push(text.hitWounded4, Log.MessageType.shoot);
		else if(currentHealth <= maxHealth * 0.5f)
			log.Push(text.hitWounded3, Log.MessageType.shoot);
		else if(currentHealth <= maxHealth * 0.8f)
			log.Push(text.hitWounded2, Log.MessageType.shoot);
		else
			log.Push(text.hitWounded1, Log.MessageType.shoot);
	}
	
	public IEnumerator Die()
	{
		isAlive = false;
		int counter = 0;
		float angle = (Mathf.PI / 2) / actionMenu.framesPerTurn;
		
		Color orig = transform.renderer.material.color;
		float r = (deathTint.r - orig.r) / actionMenu.framesPerTurn;
		float g = (deathTint.g - orig.g) / actionMenu.framesPerTurn;
		float b = (deathTint.b - orig.b) / actionMenu.framesPerTurn;
		float a = (deathTint.a - orig.a) / actionMenu.framesPerTurn;
		while(counter < actionMenu.framesPerTurn)
		{
			counter++;
			transform.RotateAroundLocal(transform.right, angle);
			transform.renderer.material.color = new Color(
				orig.r + r * counter,orig.g + g * counter,
				orig.b + b * counter,orig.a + a * counter);
			yield return new WaitForEndOfFrame();
		}
		//DestroyImmediate(gameObject);
	}
	
	public void OnMouseEnter()
	{
		actionMenu.aimVictim = gameObject;
	}
	
	public void OnMouseExit()
	{
		if(actionMenu.aimVictim == gameObject)
			actionMenu.aimVictim = null;
	}
}
