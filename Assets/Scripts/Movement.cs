using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float distanceAverage = 40;
	public float distanceRandomDistribution = 15;
	public float directionRandomDistribution = 0.12f;
	public int yOffsetFrameFrequency = 6;
	public float yOffsetRestriction = 6;
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
		//Get the velocity we want to proceed with.
		float vel = distanceAverage + Random.Range(-distanceRandomDistribution, distanceRandomDistribution);
		//Walk slower when wounded.
		vel *= health.currentHealth / health.maxHealth;
		//Get the direction we want to go.
		Vector3 step = transform.forward;
		//Add some random distribution to make it less robotic.
		step.x += Random.Range(- directionRandomDistribution,  directionRandomDistribution);
		step.z += Random.Range(- directionRandomDistribution,  directionRandomDistribution);
		//Divide by number of frames, since we want a distance/turn.
		step *= vel / actionMenu.framesPerTurn;

		Vector3 s = step;
		int yCounter = 0;
		
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
				if(--yCounter <= 0)
				{
					yCounter = yOffsetFrameFrequency;
					s = step;
					s.y += Random.Range(3 - transform.position.y, 3.5f - transform.position.y) / yOffsetRestriction;
				}
				transform.Translate(s, Space.World);
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
