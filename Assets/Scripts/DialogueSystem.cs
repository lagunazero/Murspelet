using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueSystem : MonoBehaviour {
	
	[HideInInspector]
	public List<DialogueTree> allChats;
	
	[HideInInspector]
	public int numberOfChats;
	
	public void Start()
	{
		numberOfChats = 3;
		allChats = new List<DialogueTree>(numberOfChats);
	}
	
	public void ConsumeChat(int chatIndex)
	{
		allChats[chatIndex].index++;
	}
	
}
