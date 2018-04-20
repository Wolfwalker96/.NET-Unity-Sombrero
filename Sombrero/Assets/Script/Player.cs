using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization

    public float speed;
    private bool isJump;
	void Start () {
        this.speed = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rigb = this.GetComponent<Rigidbody>();
        CameraRotate camRot = FindObjectOfType<CameraRotate>();
        if (Input.GetKey(KeyCode.A)) {
            if(camRot.Orientation == TowerOrientation.FRONT) rigb.MovePosition(transform.position + new  Vector3(-speed, 0.0f, 0.0f) * Time.deltaTime);
            else if (camRot.Orientation == TowerOrientation.LEFT) rigb.MovePosition(transform.position + new Vector3(0, 0, speed) * Time.deltaTime);
            else if (camRot.Orientation == TowerOrientation.RIGHT) rigb.MovePosition(transform.position + new Vector3(0, 0, -speed) * Time.deltaTime);
            else if (camRot.Orientation == TowerOrientation.BACK) rigb.MovePosition(transform.position + new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            if (camRot.Orientation == TowerOrientation.FRONT) rigb.MovePosition(transform.position + new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime);
            else if (camRot.Orientation == TowerOrientation.LEFT) rigb.MovePosition(transform.position + new Vector3(0, 0, -speed) * Time.deltaTime);
            else if (camRot.Orientation == TowerOrientation.RIGHT) rigb.MovePosition(transform.position + new Vector3(0, 0, speed) * Time.deltaTime);
            else if (camRot.Orientation == TowerOrientation.BACK) rigb.MovePosition(transform.position + new Vector3(-speed, 0.0f, 0.0f) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!isJump) {
                isJump = true;
                rigb.AddForce(new Vector3(0, 300, 0));
            }
        }
        if (rigb.velocity == Vector3.zero) {
            isJump = false;
        }
    }
}
