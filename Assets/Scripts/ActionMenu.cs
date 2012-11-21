using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMenu : MonoBehaviour {
	
	public int initTurns = 0;
	public int tranquilitySlipByAmount = 8;
	public int endSlipByAmount = 10;
	public int framesPerTurn = 60;

	//Object refs
	public GameObject victimSpawner;
	public GameObject aimVictim;
	public List<Weapon> weapons;
	public Log log;
	public List<Searchlight> searchlights;
	public DialogueSystem dialogueSystem;
	public GradualNight terrainScript;
	public Soundscape soundscape;
	
	//Intro
	public float introFadeTime = 1;
	
	//End
	public AnimationClip endAnimation;
	public float endBeforeStartTime;
	public float endBeforeTextTime;
	public float endTextFadeTime = 1;

	//Text
	public AudioClip sfxChatNoise;

	//UI graphics
	public float aimBorder = 400;
	public Texture2D mouseNormalIcon;
	public Texture2D mouseAimIcon;
	public Vector2 mouseIconSize;
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
	//private List<Rect> chatRectOptions;
	
	//States and counters
	private bool isEnding = false;
	private bool isAiming = false;
	private int slippedByCounter = 0;
	private int slippedByCounterThisTurn = 0;
	[HideInInspector]
	public int killCounter = 0;
	private bool canTakeAction = true;
	public int activeWeapon;

	// Use this for initialization
	void Start ()
	{
		float width = Screen.width / (6 + weapons.Count);
		float height = Screen.height / 8;
		holdFireRect = new Rect(width * 1,
			buttonBorderOffset, width, height);
		chatRect = new Rect(width * 3,
			buttonBorderOffset, width, height);

		/*
		chatRectOptions = new List<Rect>();
		for(int i = 0; i < 3; i++)
		{
			chatRectOptions.Add(new Rect(width * 3,
				buttonBorderOffset + height * (1 + i),
				width, height));
		}
		*/
		
		weaponRect = new List<Rect>(weapons.Count);
		for(int i = 0; i < weapons.Count; i++)
			weaponRect.Add(new Rect(width * (5 + i),
				buttonBorderOffset, width, height));
		
//		for(int i = 0; i < initTurns; i++)
//			EndTheTurn();
		
		StartCoroutine(StartGame());
	}
	
	void Update()
	{
		if(!canTakeAction) return;
		isAiming = Input.mousePosition.y < Screen.height * 0.75f;
		
		if(Input.GetButtonDown("Action") && isAiming)
		{
			if(weapons[activeWeapon].ammoCurrent <= 0)
			{
				log.Push(string.Format(Text.outOfAmmo, weapons[activeWeapon].type), Log.MessageType.feedback);
				audio.PlayOneShot(weapons[activeWeapon].sfxEmpty);
			}
			else if(aimVictim == null)
			{
				log.Push(Text.aimingAtNone, Log.MessageType.feedback);
			}
			else
			{
				audio.PlayOneShot(weapons[activeWeapon].sfxShoot);
				int dmg = weapons[activeWeapon].Shoot(FindAccuracy());
				aimVictim.SendMessage("TakeDamage", dmg, SendMessageOptions.DontRequireReceiver);
				if(dmg <= 0)
					log.Push(Text.shotMissed, Log.MessageType.shoot);
				
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
		//isChatting = false;
		while(counter < framesPerTurn)
		{
			counter++;
			yield return new WaitForEndOfFrame();
		}
		SendMessageToAI("StartTurn");
		
		if(!isEnding)
		{
			canTakeAction = true;
			
			//Do some stuff if anyone slipped by.
			if(slippedByCounterThisTurn > 0)
			{
				//Tell if anyone slipped by.
				log.Push(string.Format(Text.slipBy, Text.IntToText(slippedByCounterThisTurn)),
					Log.MessageType.slip);
				slippedByCounter += slippedByCounterThisTurn;
				slippedByCounterThisTurn = 0;
				
				//Are we at the end?
				if(slippedByCounter >= endSlipByAmount)
					StartCoroutine(EndGame());
				else
				{
					//Make a remark on the radio.
					if(Text.slippedByRemarks.Length > slippedByCounter && Text.slippedByRemarks[slippedByCounter] != "")
					{
						audio.PlayOneShot(sfxChatNoise);
						log.PushRadio(Text.slippedByRemarks[slippedByCounter]);
					}
					
					//Have we passed the point for final tranquility?
					if(slippedByCounter > tranquilitySlipByAmount)
					{
						SendMessageToAI("Tranquility");
					}
				}
			}
		}
	}
	
	public void SendMessageToAI(string msg)
	{
		SendMessage(msg, SendMessageOptions.DontRequireReceiver);
		
		victimSpawner.SendMessage(msg, SendMessageOptions.DontRequireReceiver);
		log.SendMessage(msg, SendMessageOptions.DontRequireReceiver);
		terrainScript.SendMessage(msg, SendMessageOptions.DontRequireReceiver);
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
		slippedByCounterThisTurn++;
	}
	
	public IEnumerator StartGame()
	{
		canTakeAction = false;
		
		//Prepare explanation text.
		GUIText t = GameObject.Find("Special text").guiText;
		t.text = Text.introExplanation;
		t.material.color = new Color(t.material.color.r, t.material.color.g, t.material.color.b, 1);
		t.enabled = true;
		
		ScreenOverlay overlay = gameObject.GetComponent<ScreenOverlay>();
		overlay.intensity = -1;

		guiColor = new Color(guiColor.r, guiColor.g, guiColor.b, 0);

		//Wait for mouse button down
		while(!Input.GetButton("Action"))
		{
			yield return new WaitForEndOfFrame();
		}
		
		if(!Debug.isDebugBuild)
			Screen.showCursor = false;

		//Fade in ambient track
		soundscape.StartGame();
		
		//Fade out text and fade in game
		float fadeSpeed = 1 / introFadeTime;
		while(t.material.color.a > 0 || overlay.intensity < 0 || guiColor.a < 1)
		{
			t.material.color = new Color(t.material.color.r, t.material.color.g, t.material.color.b, Mathf.Max(0, t.material.color.a - fadeSpeed * Time.deltaTime));
			overlay.intensity = Mathf.Min(0, overlay.intensity + fadeSpeed * Time.deltaTime);
			guiColor = new Color(guiColor.r, guiColor.g, guiColor.b, Mathf.Min(1, guiColor.a + fadeSpeed * Time.deltaTime));
			yield return new WaitForEndOfFrame();
		}
		
		//Done. Let's play!
		t.enabled = false;
		canTakeAction = true;
		
		SendMessageToAI("GameStarted");
	}
	
	public IEnumerator EndGame()
	{
		isEnding = true;
		canTakeAction = false;
		log.Push(Text.outroStart, Log.MessageType.special);
		//yield return new WaitForSeconds(endBeforeStartTime);
		
		//Turn towards the gun.
		animation.clip = endAnimation;
		animation.Play();
		yield return new WaitForSeconds(endAnimation.length + endBeforeTextTime);

		//Show the ending text
		GUIText t = GameObject.Find("Special text").guiText;
		t.text = string.Format(Text.outroEnd, killCounter);
		t.material.color = new Color(1,1,1,0);
		t.enabled = true;
		float fadeSpeed = 1 / endTextFadeTime;
		while(t.material.color.a < 1)
		{
			t.material.color = new Color(1,1,1,t.material.color.a + fadeSpeed * Time.deltaTime);
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
			OnGUI_Mouse(mouseAimIcon);
			if(aimVictim != null)
			{
				GUI.TextField(new Rect(Input.mousePosition.x + aimAccuracyOffset.x,
					Screen.height - Input.mousePosition.y + aimAccuracyOffset.y,
					aimAccuracySize.x, aimAccuracySize.y),
					FindAccuracy() + "%");
			}
		}
		else
		{
			OnGUI_Mouse(mouseNormalIcon);
		}
		
		//HOLD FIRE
		if(GUI.Button(holdFireRect, Text.guiHoldFire, buttonStyle) && canTakeAction)
		{
			log.Push(Text.holdFire, Log.MessageType.feedback);
			EndTheTurn();
		}

		//CHAT
		/*
		if(GUI.Button(chatRect, Text.guiChatText, buttonStyle) && canTakeAction)
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
		
		if(GUI.Button(chatRect,soundscape.sourceRocking.isPlaying ? Text.guiRadioOff : Text.guiRadioOn, buttonStyle) && canTakeAction)
		{
			/*
			audio.PlayOneShot(sfxChatNoise);
			log.Push(
				Text.RandomChatNoise() + ' ' +
				Text.chatEntries[Random.Range(0, Text.chatEntries.Length)] + ' ' +
				Text.RandomChatNoise(),
				Log.MessageType.radio);
			*/
			if(slippedByCounter < tranquilitySlipByAmount)
			{
				if(soundscape.sourceRocking.isPlaying)
					soundscape.StopRocking();
				else
					soundscape.PlayRocking();
			}
			else
			{
				log.Push(Text.radioNoSignal, Log.MessageType.feedback);
			}
			EndTheTurn();
		}
		

		//RELOAD AND SWITCH WEAPON
		for(int i = 0; i < weapons.Count; i++)
		{
			if(activeWeapon == i)
			{
				if(GUI.Button(weaponRect[i], Text.guiReload + '\n'
					+ weapons[i].type + '\n'
					+ (weapons[i].ammoCurrent + " / " + weapons[i].ammoMax),
					buttonStyle) && canTakeAction)
				{
					if(weapons[i].ammoCurrent < weapons[i].ammoMax)
					{
						weapons[i].ammoCurrent = weapons[i].ammoMax;
						audio.PlayOneShot(weapons[activeWeapon].sfxReload);
						log.Push(string.Format(Text.reload, weapons[i].type), Log.MessageType.feedback);
						EndTheTurn();
					}
					else
						log.Push(string.Format(Text.reloadFullyLoaded, weapons[i].type), Log.MessageType.feedback);
				}
			}
			else
			{
				if(GUI.Button(weaponRect[i], Text.guiSwitchWeapon + '\n'
					+ weapons[i].type + '\n'
					+ (weapons[i].ammoCurrent + " / " + weapons[i].ammoMax),
					buttonStyle) && canTakeAction)
				{
					activeWeapon = i;
					log.Push(string.Format(Text.switchWeapon, weapons[i].type), Log.MessageType.feedback);
					EndTheTurn();
				}		
			}
		}
	}

	void OnGUI_Mouse(Texture2D tex)
	{
		GUI.DrawTexture(new Rect(Input.mousePosition.x - mouseIconSize.x / 2,
			Screen.height - Input.mousePosition.y - mouseIconSize.y / 2,
			mouseIconSize.x, mouseIconSize.y),
			tex, ScaleMode.ScaleToFit);
	}
}
