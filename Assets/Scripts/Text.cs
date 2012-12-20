using UnityEngine;
using System.Collections;

public static class Text {

	//Special
	public static string introTitle = "No-one has the intention";
	public static string introExplanation =
		"START OF BRIEFING\n" +
		"Use your mouse to aim.\n" +
		"Left mouse button shoots or performs an action.\n" +
		"Press left mouse button to begin.\n" +
		"END OF BRIEFING";
	public static string outroCount = "You shot and killed {0} unarmed civilians.\n\n\n\n\n\n\nThank you for playing.";
	public static string outroCountSingle = "You shot and killed {0} unarmed civilian.\n\n\n\n\n\n\nThank you for playing.";
	public static string outroCountNone = "You took no part in the killing of unarmed civilians.\n\n\n\n\n\n\nThank you.";
	public static string outroCredits = "A game about considering your actions, by Ulf Hartelius\n" +
									"Sound by Alexander Zurowetz\n" +
									"Graphics from Unity Asset Store:\n" +
									"  Gun by Zodiac Alliance Digital Entertainment,\n" +
									"  Textures by Allegorithmic and Ninety Nine Works";
	
	//Events
	public static string introGameStart = "The watch begins...";
	public static string slipBy = "{0} slipped by.";
	public static string outroStart = "Hey, you!";

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
	
	public static string[] slippedByRemarks = {
		"", //Leave empty, since we start at index 0
		"Whoa, you missed one!",
		"Be careful, you missed another one.",
		"You forgot to reload or something?",
		"Are you even trying?",
		"You want me to tell the captain on you?!",
		"We can't lose 'em like this, hold your damn ground!",
		"You better shape up ASAP!",
		"...please try harder, I don't want to be alone here again...",
		"This is your last warning. We can't have traitors around..."
	};
	
	
	
	//Radio
	public static string radioContact01 = "Welcome to the wall, soldier!";
	public static string radioContact02 = "Better get acquainted with it.";
	public static string radioContact03 = "Just aim to kill. They'd rather be dead too!";
	public static string radioContact04 = "Don't worry too much, you're not alone up here.";
	public static string radioContact05 = "It's a good thing we're up here. Good sight, little risk.";
	
	public static string radioContact06 = "You wouldn't happen to know how long it's been, do you?";
	public static string radioContact07 = "Didn't think so... Never mind.";
	
	public static string radioContact08 = "It's just that, you get to wondering, you know.";
	public static string radioContact09 = "Why they want to cross so damn badly, I mean.";
	public static string radioContact10 = "Never mind, ignore what I'm talking about.";
	
	public static string radioContact11 = "You liking the guns you got? Tried the sniper yet?";
	public static string radioContact12 = "Me, that's my favourite. Takes 'em from afar.";
	public static string radioContact13 = ".............";
	
	public static string radioContact14 = "You've heard about the Charlie tank incident, right?";
	public static string radioContact15 = "Back before it was a real wall; just a wire fence.";
	public static string radioContact16 = "TWENTY tanks just stood there, for days on end.";
	public static string radioContact17 = "Crazy, I tell ya!";
	public static string radioContact18 = "Then again, I guess that's the US and USSR for ya.";
	public static string radioContact19 = "Can't trust 'em. Couldn't back then, no difference now.";
	public static string radioContact20 = "That's what I always said.";
	public static string radioContact21 = "You're not going to say anything to anyone, are you?!";
	public static string radioContact22 = "Good, good... Back to shooting, now.";

	public static string radioContact23 = "I don't really get it.";
	public static string radioContact24 = "Why they're coming at us, getting shot at like this.";
	public static string radioContact25 = "Can't they just stay home, like they've been told?";

	public static string radioContact26 = "Sharpen up, there's an officer approaching!";
	public static string radioContact27 = "Okay, he's passed. Looks like he went to ground level.";

	public static string radioContact28 = "Can I ask you a question? You don't have to answer.";
	public static string radioContact29 = "Are you aiming to kill or scare?";
	public static string radioContact30 = "I mostly just try to scare 'em.";
	public static string radioContact31 = "Nowadays...";
	public static string radioContact32 = "Though it's not easy. The aim's hardly perfect.";
	public static string radioContact33 = "I won't hold either against you. We're just following orders.";
	public static string radioContact34 = "Even when they're with women or children, like the traitors they are...";

	public static string radioContact35 = "Speaking of aiming, I should warn you about something.";
	public static string radioContact36 = "No, never mind. I shouldn't.";

	public static string radioContact37 = "Still...";
	public static string radioContact38 = "We're the ones with the guns.";
	public static string radioContact39 = "We're the ones with the power.";
	public static string radioContact40 = "I keep wondering what would happen...";
	public static string radioContact41 = "It'd take everyone, of course. The people too.";
	public static string radioContact42 = "Not that I have the intention to, mind!";
	public static string radioContact43 = "That reminds me of his speech.";
	public static string radioContact44 = "It must have been Ulbricht, right?";
	public static string radioContact45 = "...that lying...";
	
	public static string radioContact46 = "Niemand hat die Absicht...";
	public static string radioContact47 = "...eine Mauer zu errichten.";
	public static string radioContact48 = "Niemand hat die Absicht...";
	public static string radioContact49 = "...to help anyone, to take responsibility...";
	public static string radioContact50 = "...but by Christ, I wish it wasn't so.";
	
	public static string radioKillFeedback01 = "Good shot!";
	public static string radioKillFeedback02 = "Show those cretins they can't cross!";
	public static string radioKillFeedback03 = "Impressive!";
	public static string radioKillFeedback04 = "You're getting a hand at this.";
	public static string radioKillFeedback05 = "Don't forget to reload whenever you can.";
	public static string radioKillFeedback06 = "That's one more!";
	public static string radioKillFeedback07 = "And another one!";
	public static string radioKillFeedback08 = "And another one...";
	public static string radioKillFeedback09 = "You could... never mind. Good work, soldier.";
	public static string radioKillFeedback10 = "This is starting to get extreme.";
	public static string radioKillFeedback11 = "Was that Gueffroy?";
	public static string radioKillFeedback12 = "How do you... just do it like this?";
	public static string radioKillFeedback13 = "Charlie would be satisfied.";
	public static string radioKillFeedback14 = "We're all victims now.";
	
	public static string[] chatNoise = {"*bzzt*", "*zzrpk*", "*bzzzkrz*", "*kkrz*", "*zpak*", "*kazkz*", "*bkzbzk*"};

	//Old radio
	public static string[] chatEntries = {
		"How's it going?",
		"Show 'em they've got NO CHANCE!",
		"Don't spare your ammo.",
		"So what really happened between you and that girl, eh?",
		"Man, this helmet itches."
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
