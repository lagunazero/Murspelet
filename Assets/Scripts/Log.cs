using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Log : MonoBehaviour {
	
	public enum MessageType
	{
		special = 0,
		feedback = 1,
		shoot = 2,
		radio = 3,
		slip = 4
	}

	private List<LogMessage> log = new List<LogMessage>();
	private int turnCounter = 1;
	
	public Text text;
	public GUIText[] guiTexts;
	public Color[] messageTypeColors;
	public FontStyle[] messageTypeFontStyles;
	
	public int turnCounterNumbers = 3;

	// Use this for initialization
	void Start ()
	{
		for(int i = 0; i < guiTexts.Length; i++)
		{
			guiTexts[i].text = "";
		}
		Push(text.intro, Log.MessageType.special);
	}
	
	public void Push(string msg, MessageType type)
	{
		log.Add(new LogMessage("Turn #" + StringNumber(turnCounter, turnCounterNumbers) + ": " + msg, type));
		for(int i = 0; i < guiTexts.Length && i < log.Count; i++)
		{
			LogMessage lm = log[log.Count - 1 -i];
			guiTexts[i].guiText.text = lm.message;
			guiTexts[i].guiText.fontStyle = messageTypeFontStyles[(int)lm.type];
			Color c = messageTypeColors[(int)lm.type];
			guiTexts[i].material.color = new Color(c.r, c.g, c.b, 1f - (i / (float)guiTexts.Length));
		}
	}
	
	public string StringNumber(int n, int length)
	{
		string s = n.ToString();
		while(length > s.Length) s = '0' + s;
		return s;
	}
	
	public void EndTurn()
	{
		turnCounter++;
	}
}
