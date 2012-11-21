using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Soundscape : MonoBehaviour {
	
	public Log log;
	
	public AudioSource sourceWind;
	public AudioSource sourceAmbience;
	public AudioSource sourceTranquil;
	public AudioSource sourceRocking;
	
	public float fadeSpeed = 0.5f;
	
	private float idealVolumeAmbience;
	private float idealVolumeTranquil;
	private float idealVolumeRocking;
	
	public void Start()
	{
		idealVolumeAmbience = sourceAmbience.volume;
		idealVolumeTranquil = sourceTranquil.volume;
		idealVolumeRocking = sourceRocking.volume;
	}
	
	public void StartGame()
	{
		sourceAmbience.volume = 0;
		sourceAmbience.Play();
		StartCoroutine(FadeIn(sourceAmbience));

		sourceWind.volume = 0;
		sourceWind.Play();
		StartCoroutine(FadeIn(sourceWind));
	}
	
	public void Tranquility()
	{
		StartCoroutine(FadeIn(sourceTranquil));
		StartCoroutine(FadeOut(sourceAmbience));
		StartCoroutine(FadeOut(sourceRocking));
	}
	
	public IEnumerator FadeIn(AudioSource source)
	{
		float target;
		if(source == sourceAmbience) target = idealVolumeAmbience;
		else if(source == sourceTranquil) target = idealVolumeTranquil;
		else if(source == sourceRocking) target = idealVolumeRocking;
		else target = 1;

		while(source.volume < target)
		{
			source.volume = Mathf.Min(target, source.volume + fadeSpeed * Time.deltaTime);
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
		StartCoroutine(FadeOut(sourceAmbience));
		log.Push(Text.radioRockOn, Log.MessageType.feedback);
	}
	
	public void StopRocking()
	{
		sourceRocking.Stop();
		StartCoroutine(FadeIn(sourceAmbience));
		log.Push(Text.radioRockOff, Log.MessageType.feedback);
	}
}
