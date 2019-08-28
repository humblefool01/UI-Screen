using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour {

    public static Camera_controller instance { set; get; }
    public GameObject ball;
    public int turn;

    private void Awake() {
        instance = this; 
    }
    public void Start() {
        turn = 0;
    }

	public void Update() {
		if (Input.GetKey (KeyCode.LeftArrow) && turn > -20) {
            turn -= 1;
            Rotate(-1);
        }
		if (Input.GetKey (KeyCode.RightArrow) && turn < 20) {
			turn += 1;
            Rotate(1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            turn = 0;
        }
    }

    public void Rotate(int dir) {
        gameObject.transform.RotateAround(ball.transform.position, Vector3.up, dir*2f);
    }
}

	