using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncMovablePlatform : MonoBehaviour {

    [SerializeField]
    public Transform[] platform;
    [SerializeField]
    public Transform[] startTransform;
    [SerializeField]
    public Transform[] endTransform;



    private Vector3[] newPosition;
    public int nbPlatform;
    public float time;
    public float resetTime;
    private float resetCpt;
    private Vector3[] speed;

    public float precision = 0.05f;

    enum MovementState { GoToEnd, GoToStart, Reset }
    private MovementState state = MovementState.Reset;
    private MovementState nextState = MovementState.GoToEnd;


    // Use this for initialization
    void Start()
    {
        newPosition = new Vector3[nbPlatform];
        speed = new Vector3[nbPlatform];
        for(int i = 0; i < nbPlatform; i++)
            newPosition[i] = startTransform[i].position;
        ChangeTarget();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state != MovementState.Reset)
        {
            for (int i = 0; i < nbPlatform; i++)
            {
                platform[i].position += speed[i];
                if (Vector3.Distance(newPosition[i], platform[i].position) < precision)
                    ChangeTarget();
            }
        }
        else
        {
            resetCpt++;
            if (resetCpt >= resetTime)
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
        else if (state == MovementState.GoToEnd)
        {
            state = MovementState.Reset;
            nextState = MovementState.GoToStart;
            for(int i = 0; i < nbPlatform; i++)
                newPosition[i] = startTransform[i].position;
        }
        else
        {
            state = MovementState.Reset;
            nextState = MovementState.GoToEnd;
            for (int i = 0; i < nbPlatform; i++)
                newPosition[i] = endTransform[i].position;
        }
        for (int i = 0; i < nbPlatform; i++)
            speed[i] = (newPosition[i] - platform[i].position) / time;
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < nbPlatform; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(startTransform[i].position, platform[i].localScale);
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(endTransform[i].position, platform[i].localScale);
        }
    }
}

