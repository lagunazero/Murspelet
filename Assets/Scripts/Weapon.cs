using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	
	public string type;
	public int ammoMax;
	public int ammoExpenditure = 1;
	[HideInInspector]
	public int ammoCurrent;
	public int accuracy;
	public int baseDamage;
	
	public AudioClip sfxShoot;
	public AudioClip sfxReload;
	public AudioClip sfxEmpty;
	
	// Use this for initialization
	void Start ()
	{
		ammoCurrent = 0;
	}
	
	public int Shoot(int reqAcc)
	{
		ammoCurrent -= ammoExpenditure;
		//Good old randomization for how good of a shot this is.
		int shotAcc = Random.Range(0, 100);
		//We need to shoot below the required accuracy, otherwise we miss.
		//Damage is simply the max - the diff between the required and actual acc.
		return shotAcc > reqAcc ? 0 : baseDamage + shotAcc;
	}
}
