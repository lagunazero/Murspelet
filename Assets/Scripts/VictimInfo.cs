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
	public float sizeMultiplierMin = 0.8f, sizeMultiplierMax = 1.2f; //around 1
	public float braveryMin = 0.4f, braveryMax = 1f; //between 0-1
	
	public void Start()
	{
		gender = (Gender)Random.Range(0, 2);
		bravery = Random.Range(braveryMin, braveryMax);
		transform.localScale *= Random.Range(sizeMultiplierMin, sizeMultiplierMax);
	}
}
