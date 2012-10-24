using UnityEngine;
using System.Collections;

public class Searchlight : MonoBehaviour {
	
	private AnimationState animState;
	
	void Start()
	{
		animState = animation[animation.clip.name];
		animState.time = Random.Range(0, (int)animation.clip.length);
		animState.speed = 0;
	}
	
	void EndTurn()
	{
		animState.speed = 1;
	}
	
	void StartTurn()
	{
		animState.speed = 0;
	}
}
