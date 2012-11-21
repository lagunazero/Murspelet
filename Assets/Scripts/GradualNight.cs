using UnityEngine;
using System.Collections;

public class GradualNight : MonoBehaviour {
	
	public Color fogColor;
	public Color ambientLight;

	private AnimationState animState;
	
	public void Start()
	{
		animState = animation[animation.clip.name];
		animState.speed = 0;
		fogColor = RenderSettings.fogColor;
		ambientLight = RenderSettings.ambientLight;
	}
	
	void EndTurn()
	{
		animState.speed = 1;
		StartCoroutine(UpdateValues());
	}
	
	void StartTurn()
	{
		animState.speed = 0;
	}
	
	public IEnumerator UpdateValues()
	{
		while(animState.speed != 0)
		{
			RenderSettings.fogColor = fogColor;
			//Looks good out on the field, but the ending looks bad
			//RenderSettings.ambientLight = ambientLight;
			yield return new WaitForEndOfFrame();
		}
	}
}
