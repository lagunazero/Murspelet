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

		radioContact06Turn = 17,
		radioContact07Turn = 18,
		
		radioContact08Turn = 27,
		radioContact09Turn = 28,
		radioContact10Turn = 31,
		
		radioContact11Turn = 37,
		radioContact12Turn = 38,
		radioContact13Turn = 39,
		
		radioContact14Turn = 46,
		radioContact15Turn = 47,
		radioContact16Turn = 48,
		radioContact17Turn = 49,
		radioContact18Turn = 50,
		radioContact19Turn = 51,
		radioContact20Turn = 52,
		radioContact21Turn = 54,
		radioContact22Turn = 55,

		radioContact23Turn = 66,
		radioContact24Turn = 67,
		radioContact25Turn = 68,

		radioContact26Turn = 77,
		radioContact27Turn = 78,

		radioContact28Turn = 89,
		radioContact29Turn = 90,
		radioContact30Turn = 91,
		radioContact31Turn = 92,
		radioContact32Turn = 94,
		radioContact33Turn = 95,
		radioContact34Turn = 97,

		radioContact35Turn = 109,
		radioContact36Turn = 110,

		radioContact37Turn = 122,
		radioContact38Turn = 123,
		radioContact39Turn = 124,
		radioContact40Turn = 125,
		radioContact41Turn = 126,
		radioContact42Turn = 127,
		radioContact43Turn = 130,
		radioContact44Turn = 131,
		radioContact45Turn = 132,

		radioContact46Turn = 145,
		radioContact47Turn = 146,
		radioContact48Turn = 148,
		radioContact49Turn = 149,
		radioContact50Turn = 150;

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

	public void KillFeedback()
	{
		switch(actionMenu.killCounter)
		{
			case radioKillFeedback01: log.PushRadio(Text.radioKillFeedback01); break;
			case radioKillFeedback02: log.PushRadio(Text.radioKillFeedback02); break;
			case radioKillFeedback03: log.PushRadio(Text.radioKillFeedback03); break;
			case radioKillFeedback04: log.PushRadio(Text.radioKillFeedback04); break;
			case radioKillFeedback05: log.PushRadio(Text.radioKillFeedback05); break;
			case radioKillFeedback06: log.PushRadio(Text.radioKillFeedback06); break;
			case radioKillFeedback07: log.PushRadio(Text.radioKillFeedback07); break;
			case radioKillFeedback08: log.PushRadio(Text.radioKillFeedback08); break;
			case radioKillFeedback09: log.PushRadio(Text.radioKillFeedback09); break;
			case radioKillFeedback10: log.PushRadio(Text.radioKillFeedback10); break;
			case radioKillFeedback11: log.PushRadio(Text.radioKillFeedback11); break;
			case radioKillFeedback12: log.PushRadio(Text.radioKillFeedback12); break;
			case radioKillFeedback13: log.PushRadio(Text.radioKillFeedback13); break;
			case radioKillFeedback14: log.PushRadio(Text.radioKillFeedback14); break;
			default: break;
		}
	}
	
	public void EndTurn()
	{
		switch(log.turnCounter)
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
	}
}
