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
	
	// Use this for initialization
	void Start ()
	{
		currentHealth = maxHealth;
		info = gameObject.GetComponent<VictimInfo>();
		if(actionMenu == null)
		{
			actionMenu = GameObject.Find("Main Camera").GetComponent<ActionMenu>();
			log = GameObject.Find("HUD").GetComponent<Log>();
		}
	}
	
	public void TakeDamage(int damage)
	{
		if(damage > 0)
		{
			if(!isAlive)
			{
				log.Push(string.Format(Text.shootDead, info.gender), Log.MessageType.shoot);
				return;
			}
			
			currentHealth -= damage;
			if(currentHealth <= 0)
			{
				log.Push(Text.hitKilled, Log.MessageType.shoot);
				audio.Play();
				actionMenu.killCounter++;
				actionMenu.GetComponent<RadioFeedback>().KillFeedback();
				StartCoroutine(Die());
			}
			else if(currentHealth <= maxHealth * 0.2f)
				log.Push(Text.hitWounded4, Log.MessageType.shoot);
			else if(currentHealth <= maxHealth * 0.5f)
				log.Push(Text.hitWounded3, Log.MessageType.shoot);
			else if(currentHealth <= maxHealth * 0.8f)
				log.Push(Text.hitWounded2, Log.MessageType.shoot);
			else
				log.Push(Text.hitWounded1, Log.MessageType.shoot);
		}
		
		//If the victim is still alive, are we brave enough to continue?
		if(isAlive && info.bravery < Random.Range(0f,1f))
		{
			GetComponent<Movement>().Flee();
		}
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
