using UnityEngine;
using System.Collections;

public class Text {

	//Special
	public static string intro = "The watch begins...";
	public static string slipBy = "One slipped by.";
	public static string outroStart = "Hey, you!";
	
	//Actions
	public static string holdFire = "You hold fire for a moment.";
	public static string aimingAtNone = "You realize you are aiming at no-one.";
	public static string outOfAmmo = "You realize your {0} needs reloading.";
	public static string shotMissed = "You missed your shot.";
	public static string reload = "You reload your {0}.";
	public static string reloadFullyLoaded = "You realize your {0} is already loaded.";
	public static string switchWeapon = "You switch to your {0}.";
	
	public static string shootDead = "You make sure {0} is deceased.";
	public static string hitWounded4 = "Barely standing now.";
	public static string hitWounded3 = "Wounded, but not dead.";
	public static string hitWounded2 = "Nicked the arm quite badly.";
	public static string hitWounded1 = "Only made a scratch.";
	public static string hitKilled = "You got one.";
	
	//GUI
	public static string guiSwitchWeapon = "Switch to";
	public static string guiReload = "Reload";
	public static string guiChat = "Radio";
	public static string guiHoldFire = "Hold fire";
	
	//Radio
	public static string[] chatNoise = {"*bzzt*", "*zzrpk*", "bzzzkrz"};
	public static string[] chatEntries = {
		"How's it going?",
		"Show 'em they've got NO CHANCE!",
		"Don't spare your ammo.",
		"So what really happened between you and that girl, eh?",
		"Man, this helmet itches."
	};
	public static string[] slippedByRemarks = {
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
	
	public static string RandomChatNoise()
	{
		return chatNoise[Random.Range(0, chatNoise.Length)];
	}
}
