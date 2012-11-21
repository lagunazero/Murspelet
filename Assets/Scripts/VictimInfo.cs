using UnityEngine;
using System.Collections;

public class VictimInfo : MonoBehaviour {
	
	public enum Gender { she, he }
	
	public Gender gender;
	public float bravery;
	[HideInInspector]
	public bool isFleeing = false;
	
	public void Start()
	{
		gender = (Gender)Random.Range(0, 2);
		bravery = Random.Range(0f, 1f);
	}
}
