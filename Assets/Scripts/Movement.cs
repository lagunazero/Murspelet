using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float distanceAverage;
	public float distanceRandomDistribution;
	public Health health;
	
	public static Vector3 goalPoint;
	public static Log log;
	public static ActionMenu actionMenu;
	
	private bool isMoving = false;
	
	public void Awake()
	{
		if(log == null)
		{
			GameObject c = GameObject.Find("Main Camera");
			log = c.GetComponentInChildren<Log>();
			actionMenu = c.GetComponent<ActionMenu>();
			goalPoint = c.transform.position;
			goalPoint.y = transform.position.y;
		}
	}
	
	public void EndTurn()
	{
		//Ensure we're still looking at the right spot.
		transform.LookAt(goalPoint);
		transform.eulerAngles = new Vector3(270, transform.eulerAngles.y - 180, 0);
		isMoving = true;
		StopAllCoroutines();
		StartCoroutine(Walk());
	}
	
	public void StartTurn()
	{
		isMoving = false;
	}
	
	public IEnumerator Walk()
	{
		float vel = distanceAverage + Random.Range(-distanceRandomDistribution, distanceRandomDistribution);
		//Walk slower when wounded.
		vel *= health.currentHealth / health.maxHealth;
		//Divide by number of frames, since we want a distance/turn.
		Vector3 step = transform.forward * vel / actionMenu.framesPerTurn;
		while(isMoving)
		{
			transform.Translate(step);
			if(transform.position.z < goalPoint.z)
			{
				Arrived();
				isMoving = false;
				return false;
			}
			yield return new WaitForEndOfFrame();
		}
	}
	
	public void Arrived()
	{
		actionMenu.SlippedBy();
		Destroy(gameObject);
	}
}
