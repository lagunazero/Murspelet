using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {

	//Special
	public string intro = "The watch begins...";
	public string slipBy = "One slipped by.";
	public string outroStart = "Hey, you!";
	
	//Actions
	public string holdFire = "You hold fire for a moment.";
	public string aimingAtNone = "You realize you are aiming at no-one.";
	public string outOfAmmo = "You realize your {0} needs reloading.";
	public string shotMissed = "You missed your shot.";
	public string reload = "You reload your {0}.";
	public string reloadFullyLoaded = "You realize your {0} is already loaded.";
	public string switchWeapon = "You switch to your {0}.";
	
	public string shootDead = "You make sure {0} is deceased.";
	public string hitWounded4 = "Barely standing now.";
	public string hitWounded3 = "Wounded, but not dead.";
	public string hitWounded2 = "Nicked the arm quite badly.";
	public string hitWounded1 = "Only made a scratch.";
	public string hitKilled = "You got one.";
	
	//GUI
	public string guiSwitchWeapon = "Switch to";
	public string guiReload = "Reload";
	public string guiChat = "Radio";
	public string guiHoldFire = "Hold fire";
	
	//Radio
	public string[] chatNoise = {"*bzzt*", "*zzrpk*", "bzzzkrz"};
	public string[] chatEntries = {
		"How's it going?",
		"Show 'em they've got NO CHANCE!",
		"Don't spare your ammo.",
		"So what really happened between you and that girl, eh?",
		"Man, this helmet itches."
	};
	public string[] slippedByRemarks = {
		"",
		"Whoa, you missed one!",
		"Be careful, you missed another one.",
		"You forgot to reload or something?",
		"Are you even trying?",
		"",
		"",
		"We can't lose 'em like this, hold your damn ground!",
		"You better shape up ASAP!",
		"This is your last warning, soldier. We can't have traitors around..."
	};
	
	public string RandomChatNoise()
	{
		return chatNoise[Random.Range(0, chatNoise.Length)];
	}
}
