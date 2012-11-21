using UnityEngine;
using System.Collections;

public static class Text {

	//Special
	public static string introExplanation =
		"START OF BRIEFING\n" +
		"Use your mouse to aim.\n" +
		"Left mouse button shoots or performs an action.\n" +
		"Press left mouse button to begin.\n" +
		"END OF BRIEFING";
	public static string outroEnd = "A game about considering your actions, by Ulf Hartelius.\n" +
									"Sound by Alexander Zurowetz.\n" +
									"Graphics by ????.\n\n" +
									"You shot and killed {0} unarmed civilians.";
	
	//Events
	public static string introGameStart = "The watch begins...";
	public static string slipBy = "{0} slipped by.";
	public static string outroStart = "Hey, you!";

	//Radio
	public static string radioContact1 = "Welcome to the wall, soldier!";
	public static string radioContact2 = "Better get acquainted with it.";
	public static string radioContact3 = "Just aim to kill. They'd rather be dead too!";
	public static string radioContact4 = "Don't worry too much, you're not alone up here.";
	public static string radioKillFeedback1 = "Good shot!";
	public static string radioKillFeedback2 = "Show those cretins they can't cross!";
	public static string radioKillFeedback3 = "Impressive!";
	
	//Actions
	public static string holdFire = "You hold fire for a moment.";
	public static string aimingAtNone = "You realize you are aiming at no-one.";
	public static string outOfAmmo = "You realize your {0} needs reloading.";
	public static string shotMissed = "You missed your shot.";
	public static string reload = "You reload your {0}.";
	public static string reloadFullyLoaded = "You realize your {0} is already loaded.";
	public static string switchWeapon = "You switch to your {0}.";
	
	//Wounding
	public static string shootDead = "You make sure {0} is deceased.";
	public static string hitWounded4 = "Barely standing now.";
	public static string hitWounded3 = "Wounded, but not dead.";
	public static string hitWounded2 = "Nicked the arm quite badly.";
	public static string hitWounded1 = "Only made a scratch.";
	public static string hitKilled = "You got one.";
	
	//Radio
	public static string radioRockOn = "You tune out to some sweet music.";
	public static string radioRockOff = "You turn off the music.";
	public static string radioNoSignal = "The radio appears to have lost the signal.";
	
	//GUI
	public static string guiSwitchWeapon = "Switch to";
	public static string guiReload = "Reload";
	public static string guiChat = "Radio";
	public static string guiHoldFire = "Hold fire";
	public static string guiRadioOn = "Turn radio on";
	public static string guiRadioOff = "Turn radio off";
	
	//Radio
	public static string[] chatNoise = {"*bzzt*", "*zzrpk*", "*bzzzkrz*"};
	public static string[] chatEntries = {
		"How's it going?",
		"Show 'em they've got NO CHANCE!",
		"Don't spare your ammo.",
		"So what really happened between you and that girl, eh?",
		"Man, this helmet itches."
	};
	public static string[] slippedByRemarks = {
		"", //Leave empty, since we start at index 0
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
	
	public static string IntToText(int i)
	{
		switch(i)
		{
			case 0: return "Zero";
			case 1: return "One";
			case 2: return "Two";
			case 3: return "Three";
			case 4: return "Four";
			case 5: return "Five";
			case 6: return "Six";
			case 7: return "Seven";
			case 8: return "Eight";
			case 9: return "Nine";
			case 10: return "Ten";
			default: return "";
		}
	}
}
