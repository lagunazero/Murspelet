using UnityEngine;
using System.Collections;

public class LogMessage
{
	public string message;
	public Log.MessageType type;
	
	public LogMessage(string m, Log.MessageType t)
	{
		message = m;
		type = t;
	}
}
