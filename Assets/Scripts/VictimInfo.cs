using UnityEngine;
using System.Collections;

public class VictimInfo : MonoBehaviour {
	
	public enum Gender { she, he }
	
	public Gender gender;
	
	public void Start()
	{
		gender = (Gender)Random.Range(0, 2);
	}
}
