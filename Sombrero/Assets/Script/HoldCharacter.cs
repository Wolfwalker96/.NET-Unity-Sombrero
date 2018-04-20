using UnityEngine;
using System.Collections;

public class HoldCharacter : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
            col.transform.parent = gameObject.transform;
    }

    void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }
}
