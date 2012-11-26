using UnityEngine;
using System.Collections;

public class VictimInfo : MonoBehaviour {
	
	public enum Gender { she, he }
	
	[HideInInspector]
	public Gender gender;
	[HideInInspector]
	public float bravery;
	[HideInInspector]
	public bool isFleeing = false;
	public float sizeMultiplierMin, sizeMultiplierMax;
	
	public void Start()
	{
		gender = (Gender)Random.Range(0, 2);
		bravery = Random.Range(0.4f, 1f);
		transform.localScale *= Random.Range(sizeMultiplierMin, sizeMultiplierMax);
	}
}
