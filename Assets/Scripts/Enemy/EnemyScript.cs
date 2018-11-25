using UnityEngine;
using System.Collections;


//turn on order direction on WayPoint component on Waypoints_s script to have cube move in one defined direction instead of crossing
//NEED TO FIX BUG OF SHAKING BOX -> distance threshold overlaps with awayFromHome values 
public class EnemyScript : MonoBehaviour {
	public Transform player;
    public WayPointsScript waypoint;
    public float moveSpeed = 5.0f;
    public float distanceToPlayer = 10.0f;
    public float awayFromHome = 20.0f;

    private Vector3 moveDir;


	// Use this for initialization
	void Start () 
    {
        waypoint = FindObjectOfType<WayPointsScript>();
        moveDir = Vector3.zero;
        transform.position = waypoint.StartPosition();
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform; 
	}
	
	// Update is called once per frame
	void Update () 
    {

        //chase
        if (Vector3.Distance(player.position, transform.position) <= distanceToPlayer) //if distance between player and cube is less than defined distance
        {
            //update direction
            moveDir = waypoint.GetDirectionToPlayer(transform, player);
        }
        else
        {
            //move direction and position of box
            moveDir = waypoint.GetDirection(transform); //accesses whole graph of each waypoint-> is getting current location and returns move direction which is also normalized 
        }

        if(waypoint.AwayFromWaypoint(transform, awayFromHome)) //pass in cube current location and if function returns true or false
        {
            moveDir = waypoint.GetDirection(transform); //move back to taget
        }

        transform.position += moveDir * moveSpeed * Time.deltaTime; //update position	

        //This is where the rotation is controlled
        //transform.rotation = Quaternion.LookRotation(moveDir);//maipulate rotation, each time change direction, also moves rotation
    }
    
}
