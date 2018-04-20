using UnityEngine;
using System.Collections;

public class MovablePlatform : MonoBehaviour {

    [SerializeField]
    public Transform platform;
    [SerializeField]
    public Transform startTransform;
    [SerializeField]
    public Transform endTransform;

    private Vector3 newPosition;
    public float time;
    public float resetTime;
    private float resetCpt;
    private Vector3 speed;

    public float precision = 0.05f;

    enum MovementState { GoToEnd, GoToStart, Reset}
    private MovementState state = MovementState.Reset;
    private MovementState nextState = MovementState.GoToEnd;


    // Use this for initialization
    void Start ()
    {

        newPosition = startTransform.position;
        ChangeTarget();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (state != MovementState.Reset)
        {
            platform.position += speed;
            if (Vector3.Distance(newPosition,platform.position) < precision)
                ChangeTarget();
        }
        else
        {
            resetCpt++;
            if(resetCpt >= resetTime)
            {
                resetCpt = 0;
                ChangeTarget();
            }
        }
    }

    void ChangeTarget()
    {
        if (state == MovementState.Reset)
        {
            state = nextState;
        }
        else if(state == MovementState.GoToEnd)
        {
            state = MovementState.Reset;
            nextState = MovementState.GoToStart;
            newPosition = startTransform.position;            
        }
        else
        {
            state = MovementState.Reset;
            nextState = MovementState.GoToEnd;
            newPosition = endTransform.position;
        }
        speed = (newPosition - platform.position)/time;        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(startTransform.position, platform.localScale);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(endTransform.position, platform.localScale);
    }
}
