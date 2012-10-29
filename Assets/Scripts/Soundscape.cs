using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Soundscape : MonoBehaviour {
	
	public Log log;
	
	public AudioSource sourceAmbience;
	public AudioSource sourceTranquil;
	public AudioSource sourceRocking;
	
	public float fadeSpeed = 0.5f;
	
	public void Tranquility()
	{
		StartCoroutine(FadeIn(sourceTranquil));
		StartCoroutine(FadeOut(sourceAmbience));
		StartCoroutine(FadeOut(sourceRocking));
	}
	
	public IEnumerator FadeIn(AudioSource source)
	{
		while(source.volume < 1f)
		{
			source.volume = Mathf.Min(1f, source.volume + fadeSpeed * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
	}

	public IEnumerator FadeOut(AudioSource source)
	{
		while(source.volume > 0f)
		{
			source.volume = Mathf.Max(0f, source.volume - fadeSpeed * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
	}

	public void PlayRocking()
	{
		sourceRocking.Play();
		log.Push(Text.radioRockOn, Log.MessageType.feedback);
	}
	
	public void StopRocking()
	{
		sourceRocking.Stop();
		log.Push(Text.radioRockOff, Log.MessageType.feedback);
	}
}
