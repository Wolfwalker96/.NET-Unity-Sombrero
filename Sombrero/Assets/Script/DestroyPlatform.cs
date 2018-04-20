using UnityEngine;
using System.Collections;

public class DestroyPlatform : MonoBehaviour {


    public GameObject platform;
    public float time;
    private float timeCpt;

    enum DestroyPlatformState { Unactived, Actived}
    DestroyPlatformState state = DestroyPlatformState.Unactived;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (state == DestroyPlatformState.Actived)
        {
            timeCpt++;
            if (timeCpt >= time)
            {
                Destroy(platform);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
            state = DestroyPlatformState.Actived;
    }
}
