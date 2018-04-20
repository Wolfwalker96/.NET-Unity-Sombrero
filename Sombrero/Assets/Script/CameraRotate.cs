using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerOrientation {
    FRONT = 0,
    LEFT = 1,
    BACK = 2,
    RIGHT = 3
}
public class CameraRotate : MonoBehaviour {

    // Use this for initialization
    private TowerOrientation orientation;
    public TowerOrientation Orientation {
        get {
            return orientation;
        }
    } 
    
	void Start () {
        orientation = 0;
	}

    private bool isRotating = false;
    public int speed = 10;
    private float angleRotated;
    private float previousAngleRotate;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isRotating) {
            angleRotated = 0;
            isRotating = true;
        }
        if (isRotating) {
            angleRotated += 90 * Time.deltaTime * speed;
            this.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), (angleRotated<90) ? 90 * Time.deltaTime * speed : 90-previousAngleRotate );
            if (angleRotated >= 90) {
                isRotating = false;
                orientation = (TowerOrientation)((int)(orientation + 1) % 4);
            }
            previousAngleRotate = angleRotated;
        }
	}
}
