using UnityEngine;
using System.Collections;

public class RadioFeedback : MonoBehaviour {
	
	public Log log;
	public ActionMenu actionMenu;
	
	public int radioContact1Turn = 2;
	public int radioContact2Turn = 4;
	public int radioContact3Turn = 6;
	public int radioContact4Turn = 8;
	public int radioKillFeedback1 = 1;
	public int radioKillFeedback2 = 3;
	public int radioKillFeedback3 = 6;

	public void KillFeedback()
	{
		if(actionMenu.killCounter == radioKillFeedback1)
			log.PushRadio(Text.radioKillFeedback1);
		else if(actionMenu.killCounter == radioKillFeedback2)
			log.PushRadio(Text.radioKillFeedback2);
		else if(actionMenu.killCounter == radioKillFeedback3)
			log.PushRadio(Text.radioKillFeedback3);
	}
	
	public void EndTurn()
	{
		if(log.turnCounter == radioContact1Turn)
			log.PushRadio(Text.radioContact1);
		else if(log.turnCounter == radioContact2Turn)
			log.PushRadio(Text.radioContact2);
		else if(log.turnCounter == radioContact3Turn)
			log.PushRadio(Text.radioContact3);
		else if(log.turnCounter == radioContact4Turn)
			log.PushRadio(Text.radioContact4);
	}
}
