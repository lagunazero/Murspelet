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
	public float tranquilFadeOutSpeed = 10;
	public float tranquilFadeInSpeed = 20;
	
	private float idealVolumeAmbience;
	private float idealVolumeTranquil;
	private float idealVolumeRocking;
	
	public AudioClip sfxRadioOn, sfxRadioOff;
	public float sfxRadioOnVolume = 1, sfxRadioOffVolume = 1;
	
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
		StartCoroutine(FadeIn(sourceAmbience, fadeSpeed));

		sourceWind.volume = 0;
		sourceWind.Play();
		StartCoroutine(FadeIn(sourceWind, fadeSpeed));
	}
	
	public void Tranquility()
	{
		sourceTranquil.Play();
		StartCoroutine(FadeIn(sourceTranquil, tranquilFadeInSpeed));
		StartCoroutine(FadeOut(sourceAmbience, tranquilFadeOutSpeed));
		StartCoroutine(FadeOut(sourceRocking, tranquilFadeOutSpeed));
	}
	
	public IEnumerator FadeIn(AudioSource source, float speed)
	{
		float target;
		if(source == sourceAmbience) target = idealVolumeAmbience;
		else if(source == sourceTranquil) target = idealVolumeTranquil;
		else if(source == sourceRocking) target = idealVolumeRocking;
		else target = 1;
		
		source.volume = 0;
		while(source.volume < target)
		{
			source.volume = Mathf.Min(target, source.volume + speed * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
	}

	public IEnumerator FadeOut(AudioSource source, float speed)
	{
		while(source.volume > 0f)
		{
			source.volume = Mathf.Max(0f, source.volume - speed * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
	}

	public void PlayRocking()
	{
		audio.PlayOneShot(sfxRadioOn, sfxRadioOnVolume);
		sourceRocking.Play();
		StartCoroutine(FadeOut(sourceAmbience, fadeSpeed));
		log.Push(Text.radioRockOn, Log.MessageType.feedback);
	}
	
	public void StopRocking()
	{
		audio.PlayOneShot(sfxRadioOff, sfxRadioOffVolume);
		sourceRocking.Stop();
		StartCoroutine(FadeIn(sourceAmbience, fadeSpeed));
		log.Push(Text.radioRockOff, Log.MessageType.feedback);
	}
}
