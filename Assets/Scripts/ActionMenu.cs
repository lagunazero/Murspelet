using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMenu : MonoBehaviour {

	public int initTurns = 0;
	public int endSlipByAmount = 10;
	public int framesPerTurn = 60;

	//Object refs
	public GameObject victimSpawner;
	public GameObject aimVictim;
	public List<Weapon> weapons;
	public Log log;
	public List<Searchlight> searchlights;
	public DialogueSystem dialogueSystem;
	public Text text;
	
	//End
	public AnimationClip endAnimation;
	public float endBeforeStartTime;
	public float endBeforeTextTime;
	public float endTextFadeTime;

	//Text
	public AudioClip sfxChatNoise;

	//UI graphics
	public float aimBorder = 400;
	public Texture2D aimSymbol;
	public Vector2 aimSymbolSize;
	public Vector2 aimAccuracySize;
	public Vector2 aimAccuracyOffset;
	public float buttonBorderOffset;	
	private GUIStyle buttonActiveStyle;
	private GUIStyle buttonInactiveStyle;
	private Rect switchWeaponLeftRect;
	private Rect switchWeaponRightRect;
	private Rect reloadRect;
	private Rect chatRect;
	private Rect holdFireRect;
	private List<Rect> weaponRect;
	public Color guiColor;
	private List<Rect> chatRectOptions;
	
	//States and counters
	private bool isEnding = false;
	private bool isAiming = false;
	private int slippedByCounter = 0;
	private bool canTakeAction = true;
	public int activeWeapon;
	private bool isChatting = false;

	// Use this for initialization
	void Start ()
	{
		float width = Screen.width / (6 + weapons.Count);
		float height = Screen.height / 8;
		holdFireRect = new Rect(width * 1,
			buttonBorderOffset, width, height);
		chatRect = new Rect(width * 3,
			buttonBorderOffset, width, height);
		
		chatRectOptions = new List<Rect>();
		for(int i = 0; i < 3; i++)
		{
			chatRectOptions.Add(new Rect(width * 3,
				buttonBorderOffset + height * (1 + i),
				width, height));
		}
		
		weaponRect = new List<Rect>(weapons.Count);
		for(int i = 0; i < weapons.Count; i++)
			weaponRect.Add(new Rect(width * (5 + i),
				buttonBorderOffset, width, height));
		
		for(int i = 0; i < initTurns; i++)
			EndTheTurn();
	}
	
	void Update()
	{
		if(!canTakeAction) return;
		isAiming = Input.mousePosition.y < Screen.height * 0.75f;
		
		if(Input.GetMouseButtonDown(0) && isAiming)
		{
			if(weapons[activeWeapon].ammoCurrent <= 0)
			{
				log.Push(string.Format(text.outOfAmmo, weapons[activeWeapon].type), Log.MessageType.feedback);
				audio.PlayOneShot(weapons[activeWeapon].sfxEmpty);
			}
			else if(aimVictim == null)
			{
				log.Push(text.aimingAtNone, Log.MessageType.feedback);
			}
			else
			{
				audio.PlayOneShot(weapons[activeWeapon].sfxShoot);
				int dmg = weapons[activeWeapon].Shoot(FindAccuracy());
				if(dmg > 0)
					aimVictim.SendMessage("TakeDamage", dmg, SendMessageOptions.DontRequireReceiver);
				else
					log.Push(text.shotMissed, Log.MessageType.shoot);
				
				EndTheTurn();
			}
		}
	}

	/// <summary>Ends the turn. Called at the end of every turn, regardless of action.</summary>
	public void EndTheTurn()
	{
		isAiming = false;
		SendMessageToAI("EndTurn");
		StartCoroutine(WaitingTime());
	}
	
	public IEnumerator WaitingTime()
	{
		int counter = 0;
		canTakeAction = false;
		isChatting = false;
		while(counter < framesPerTurn)
		{
			counter++;
			yield return new WaitForEndOfFrame();
		}
		if(!isEnding)
			canTakeAction = true;
		SendMessageToAI("StartTurn");
	}
	
	public void SendMessageToAI(string msg)
	{
		victimSpawner.SendMessage(msg, SendMessageOptions.DontRequireReceiver);
		log.SendMessage(msg, SendMessageOptions.DontRequireReceiver);
		for(int i = 0; i < searchlights.Count; i++)
			searchlights[i].SendMessage(msg, SendMessageOptions.DontRequireReceiver);
	}
	
	/// <summary>Finds the accuracy against the current victim, in percentage.</summary>
	public int FindAccuracy()
	{
		float a = weapons[activeWeapon].accuracy / (transform.position - aimVictim.transform.position).magnitude;
		a *= 100;
		a = Mathf.Clamp(a, 0, 100);
		return Mathf.CeilToInt(a);
	}
	
	public void SlippedBy()
	{
		log.Push(text.slipBy, Log.MessageType.slip);
		slippedByCounter++;
		if(slippedByCounter >= endSlipByAmount)
			StartCoroutine(EndGame());
		else if(text.slippedByRemarks.Length > slippedByCounter && text.slippedByRemarks[slippedByCounter] != "")
		{
			audio.PlayOneShot(sfxChatNoise);
			log.Push(text.RandomChatNoise() + ' ' +
				text.slippedByRemarks[slippedByCounter] + ' ' +
				text.RandomChatNoise(),
				Log.MessageType.radio);
		}
	}
	
	public IEnumerator EndGame()
	{
		isEnding = true;
		canTakeAction = false;
		log.Push(text.outroStart, Log.MessageType.special);
		yield return new WaitForSeconds(endBeforeStartTime);
		
		//Turn towards the gun.
		animation.clip = endAnimation;
		animation.Play();
		yield return new WaitForSeconds(endAnimation.length + endBeforeTextTime);

		//Show the ending text
		GUIText t = GameObject.Find("Ending text").guiText;
		t.material.color = new Color(1,1,1,0);
		t.enabled = true;
		float fadeSpeed = 1 / (endTextFadeTime * Time.fixedTime);
		while(t.material.color.a < 1)
		{
			t.material.color = new Color(1,1,1,t.material.color.a + fadeSpeed);
			yield return new WaitForEndOfFrame();
		}
		//Now it's all over...
	}
	
	public void PlaySound(AudioClip clip)
	{
		if(clip != null)
			audio.PlayOneShot(clip);
	}
	
	public void EndGameLog(string msg)
	{
		log.Push(msg, Log.MessageType.special);
	}
	
	public void OnGUI()
	{
		if(buttonActiveStyle == null)
		{
			buttonActiveStyle = new GUIStyle(GUI.skin.FindStyle("button"));
			buttonInactiveStyle = new GUIStyle(GUI.skin.FindStyle("button"));
			buttonInactiveStyle.normal.textColor =
				buttonInactiveStyle.active.textColor =
				buttonInactiveStyle.focused.textColor = 
				buttonInactiveStyle.hover.textColor = new Color(1,1,1,0.5f);
		}
		
		GUI.color = guiColor;
		GUIStyle buttonStyle = canTakeAction ? buttonActiveStyle : buttonInactiveStyle;
		
		//AIM
		if(isAiming && canTakeAction)
		{
			GUI.DrawTexture(new Rect(Input.mousePosition.x,
				Screen.height - Input.mousePosition.y, aimSymbolSize.x,
				aimSymbolSize.y), aimSymbol);		
			if(aimVictim != null)
			{
				GUI.TextField(new Rect(Input.mousePosition.x + aimAccuracyOffset.x,
					Screen.height - Input.mousePosition.y + aimAccuracyOffset.y,
					aimAccuracySize.x, aimAccuracySize.y),
					FindAccuracy() + "%");
			}
		}
		
		//HOLD FIRE
		if(GUI.Button(holdFireRect, text.guiHoldFire, buttonStyle) && canTakeAction)
		{
			log.Push(text.holdFire, Log.MessageType.feedback);
			EndTheTurn();
		}

		//CHAT
		/*
		if(GUI.Button(chatRect, text.guiChatText, buttonStyle) && canTakeAction)
		{
			isChatting = !isChatting;
		}
		if(isChatting)
		{
			if(GUI.Button(chatRectOptions[0], dialogueSystem.chatCareFree, buttonStyle))
			{
				audio.PlayOneShot(sfxChatNoise);
				log.Push(chatEntries[i], Log.MessageType.radio);
				EndTheTurn();
			}
		}
		 */
		
		if(GUI.Button(chatRect, text.guiChat, buttonStyle) && canTakeAction)
		{
			audio.PlayOneShot(sfxChatNoise);
			log.Push(
				text.RandomChatNoise() + ' ' +
				text.chatEntries[Random.Range(0, text.chatEntries.Length)] + ' ' +
				text.RandomChatNoise(),
				Log.MessageType.radio);
			EndTheTurn();
		}
		

		//RELOAD AND SWITCH WEAPON
		for(int i = 0; i < weapons.Count; i++)
		{
			if(activeWeapon == i)
			{
				if(GUI.Button(weaponRect[i], text.guiReload + '\n'
					+ weapons[i].type + '\n'
					+ (weapons[i].ammoCurrent + " / " + weapons[i].ammoMax),
					buttonStyle) && canTakeAction)
				{
					if(weapons[i].ammoCurrent < weapons[i].ammoMax)
					{
						weapons[i].ammoCurrent = weapons[i].ammoMax;
						audio.PlayOneShot(weapons[activeWeapon].sfxReload);
						log.Push(string.Format(text.reload, weapons[i].type), Log.MessageType.feedback);
						EndTheTurn();
					}
					else
						log.Push(string.Format(text.reloadFullyLoaded, weapons[i].type), Log.MessageType.feedback);
				}
			}
			else
			{
				if(GUI.Button(weaponRect[i], text.guiSwitchWeapon + '\n'
					+ weapons[i].type + '\n'
					+ (weapons[i].ammoCurrent + " / " + weapons[i].ammoMax),
					buttonStyle) && canTakeAction)
				{
					activeWeapon = i;
					log.Push(string.Format(text.switchWeapon, weapons[i].type), Log.MessageType.feedback);
					EndTheTurn();
				}		
			}
		}
	}
}
