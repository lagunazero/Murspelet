using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float distanceAverage;
	public float distanceRandomDistribution;
	public Health health;
	public VictimInfo info;
	public Vector3 goalPoint;
	public float goalDistanceRequirement = 5;
	public int fleeGoalMinX, fleeGoalMaxX, fleeGoalMinZ, fleeGoalMaxZ;
	
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
		}
//		goalPoint = actionMenu.transform.position;
//		goalPoint.y = transform.position.y;
	}
	
	public void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 50);
	}
	
	public void EndTurn()
	{
		//Ensure we're still looking at the right spot.
		transform.LookAt(goalPoint);
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
			if(Vector3.Distance(transform.position, goalPoint) < goalDistanceRequirement)
			{
				isMoving = false;
				if(!info.isFleeing)
					actionMenu.SlippedBy();
				Destroy(gameObject);
				return false;
			}
			else
			{
				transform.Translate(step, Space.World);
				yield return new WaitForEndOfFrame();
			}
		}
	}
	
	public void Flee()
	{
		info.isFleeing = true;
		goalPoint.x = Random.Range(fleeGoalMinX, fleeGoalMaxX);
		goalPoint.z = Random.Range(fleeGoalMinZ, fleeGoalMaxZ);
	}
}
