using UnityEngine;
using System.Collections;

public class RadioFeedback : MonoBehaviour {
	
	public Log log;
	public ActionMenu actionMenu;
	
	public const int
		radioContact01Turn = 2,
		radioContact02Turn = 4,
		radioContact03Turn = 6,
		radioContact04Turn = 8,
		radioContact05Turn = 11,

		radioContact06Turn = 21,
		radioContact07Turn = 22,
		
		radioContact08Turn = 33,
		radioContact09Turn = 34,
		radioContact10Turn = 37,
		
		radioContact11Turn = 48,
		radioContact12Turn = 49,
		radioContact13Turn = 50,
		
		radioContact14Turn = 64,
		radioContact15Turn = 65,
		radioContact16Turn = 66,
		radioContact17Turn = 67,
		radioContact18Turn = 68,
		radioContact19Turn = 69,
		radioContact20Turn = 70,
		radioContact21Turn = 73,
		radioContact22Turn = 74,

		radioContact23Turn = 91,
		radioContact24Turn = 92,
		radioContact25Turn = 93,

		radioContact26Turn = 112,
		radioContact27Turn = 115,

		radioContact28Turn = 130,
		radioContact29Turn = 131,
		radioContact30Turn = 132,
		radioContact31Turn = 133,
		radioContact32Turn = 135,
		radioContact33Turn = 136,
		radioContact34Turn = 137,

		radioContact35Turn = 158,
		radioContact36Turn = 159,

		radioContact37Turn = 183,
		radioContact38Turn = 184,
		radioContact39Turn = 185,
		radioContact40Turn = 186,
		radioContact41Turn = 187,
		radioContact42Turn = 188,
		radioContact43Turn = 191,
		radioContact44Turn = 192,
		radioContact45Turn = 193,

		radioContact46Turn = 499,
		radioContact47Turn = 500,
		radioContact48Turn = 2220,
		radioContact49Turn = 2230,
		radioContact50Turn = 2250;

	public const int
		radioKillFeedback01 = 1,
		radioKillFeedback02 = 3,
		radioKillFeedback03 = 6,
		radioKillFeedback04 = 10,
		radioKillFeedback05 = 13,
		radioKillFeedback06 = 18,
		radioKillFeedback07 = 19,
		radioKillFeedback08 = 20,
		radioKillFeedback09 = 25,
		radioKillFeedback10 = 78, //Salzgitter
		radioKillFeedback11 = 135, //Centre for Contemporary History (one less, see wiki list for reason)
		radioKillFeedback12 = 235, //Arbeitsgruppe 13 August
		radioKillFeedback13 = 245, //Checkpoint Charlie Museum
		radioKillFeedback14 = 1245; //Victim's group, via BBC
	
	private bool gaveKillFeedback = false;
	private int feedbackTurnsToCatchUp = 0;
	
	public void KillFeedback()
	{
		switch(actionMenu.killCounter)
		{
			case radioKillFeedback01: log.PushRadio(Text.radioKillFeedback01); gaveKillFeedback = true; break;
			case radioKillFeedback02: log.PushRadio(Text.radioKillFeedback02); gaveKillFeedback = true; break;
			case radioKillFeedback03: log.PushRadio(Text.radioKillFeedback03); gaveKillFeedback = true; break;
			case radioKillFeedback04: log.PushRadio(Text.radioKillFeedback04); gaveKillFeedback = true; break;
			case radioKillFeedback05: log.PushRadio(Text.radioKillFeedback05); gaveKillFeedback = true; break;
			case radioKillFeedback06: log.PushRadio(Text.radioKillFeedback06); gaveKillFeedback = true; break;
			case radioKillFeedback07: log.PushRadio(Text.radioKillFeedback07); gaveKillFeedback = true; break;
			case radioKillFeedback08: log.PushRadio(Text.radioKillFeedback08); gaveKillFeedback = true; break;
			case radioKillFeedback09: log.PushRadio(Text.radioKillFeedback09); gaveKillFeedback = true; break;
			case radioKillFeedback10: log.PushRadio(Text.radioKillFeedback10); gaveKillFeedback = true; break;
			case radioKillFeedback11: log.PushRadio(Text.radioKillFeedback11); gaveKillFeedback = true; break;
			case radioKillFeedback12: log.PushRadio(Text.radioKillFeedback12); gaveKillFeedback = true; break;
			case radioKillFeedback13: log.PushRadio(Text.radioKillFeedback13); gaveKillFeedback = true; break;
			case radioKillFeedback14: log.PushRadio(Text.radioKillFeedback14); gaveKillFeedback = true; break;
			default: break;
		}
	}
	
	public void EndTurn()
	{
		//We don't want to keep a conversation going if we just gave kill feedback.
		//So instead we pause that conversation for a turn (or more, if there
		//are many kill feedbacks consecutively).
		if(!gaveKillFeedback)
		{
			switch(log.turnCounter - feedbackTurnsToCatchUp)
			{
				case radioContact01Turn: log.PushRadio(Text.radioContact01); break;
				case radioContact02Turn: log.PushRadio(Text.radioContact02); break;
				case radioContact03Turn: log.PushRadio(Text.radioContact03); break;
				case radioContact04Turn: log.PushRadio(Text.radioContact04); break;
				case radioContact05Turn: log.PushRadio(Text.radioContact05); break;
				case radioContact06Turn: log.PushRadio(Text.radioContact06); break;
				case radioContact07Turn: log.PushRadio(Text.radioContact07); break;
				case radioContact08Turn: log.PushRadio(Text.radioContact08); break;
				case radioContact09Turn: log.PushRadio(Text.radioContact09); break;
				case radioContact10Turn: log.PushRadio(Text.radioContact10); break;
				case radioContact11Turn: log.PushRadio(Text.radioContact11); break;
				case radioContact12Turn: log.PushRadio(Text.radioContact12); break;
				case radioContact13Turn: log.PushRadio(Text.radioContact13); break;
				case radioContact14Turn: log.PushRadio(Text.radioContact14); break;
				case radioContact15Turn: log.PushRadio(Text.radioContact15); break;
				case radioContact16Turn: log.PushRadio(Text.radioContact16); break;
				case radioContact17Turn: log.PushRadio(Text.radioContact17); break;
				case radioContact18Turn: log.PushRadio(Text.radioContact18); break;
				case radioContact19Turn: log.PushRadio(Text.radioContact19); break;
				case radioContact20Turn: log.PushRadio(Text.radioContact20); break;
				case radioContact21Turn: log.PushRadio(Text.radioContact21); break;
				case radioContact22Turn: log.PushRadio(Text.radioContact22); break;
				case radioContact23Turn: log.PushRadio(Text.radioContact23); break;
				case radioContact24Turn: log.PushRadio(Text.radioContact24); break;
				case radioContact25Turn: log.PushRadio(Text.radioContact25); break;
				case radioContact26Turn: log.PushRadio(Text.radioContact26); break;
				case radioContact27Turn: log.PushRadio(Text.radioContact27); break;
				case radioContact28Turn: log.PushRadio(Text.radioContact28); break;
				case radioContact29Turn: log.PushRadio(Text.radioContact29); break;
				case radioContact30Turn: log.PushRadio(Text.radioContact30); break;
				case radioContact31Turn: log.PushRadio(Text.radioContact31); break;
				case radioContact32Turn: log.PushRadio(Text.radioContact32); break;
				case radioContact33Turn: log.PushRadio(Text.radioContact33); break;
				case radioContact34Turn: log.PushRadio(Text.radioContact34); break;
				case radioContact35Turn: log.PushRadio(Text.radioContact35); break;
				case radioContact36Turn: log.PushRadio(Text.radioContact36); break;
				case radioContact37Turn: log.PushRadio(Text.radioContact37); break;
				case radioContact38Turn: log.PushRadio(Text.radioContact38); break;
				case radioContact39Turn: log.PushRadio(Text.radioContact39); break;
				case radioContact40Turn: log.PushRadio(Text.radioContact40); break;
				case radioContact41Turn: log.PushRadio(Text.radioContact41); break;
				case radioContact42Turn: log.PushRadio(Text.radioContact42); break;
				case radioContact43Turn: log.PushRadio(Text.radioContact43); break;
				case radioContact44Turn: log.PushRadio(Text.radioContact44); break;
				case radioContact45Turn: log.PushRadio(Text.radioContact45); break;
				case radioContact46Turn: log.PushRadio(Text.radioContact46); break;
				case radioContact47Turn: log.PushRadio(Text.radioContact47); break;
				case radioContact48Turn: log.PushRadio(Text.radioContact48); break;
				case radioContact49Turn: log.PushRadio(Text.radioContact49); break;
				case radioContact50Turn: log.PushRadio(Text.radioContact50); break;
				default: break;
			}
			if(feedbackTurnsToCatchUp > 0) feedbackTurnsToCatchUp--;
		}
		else
		{
			gaveKillFeedback = false;
			feedbackTurnsToCatchUp++;
		}
	}
}
