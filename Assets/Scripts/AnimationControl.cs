using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {
    private bool ready, done, play;
    private int state;
    private GameObject b1, b2;
    public float speed;
    public int wait;
    public void Start() {
        state = 0;
        ready = false;
        done = false;
        b1 = gameObject.transform.GetChild(0).gameObject;
        b2 = gameObject.transform.GetChild(1).gameObject;
        StartCoroutine(Example());
    }
    public void Update() {
        if (ready) {

            gameObject.transform.Translate(Vector3.left * speed);  //Go left
        }

        if (ready && b1.transform.position.x == 640) {
            ready = false;
            state = 1;
            done = true;
            StartCoroutine(Example());
        }
        if (ready && b2.transform.position.x == 640) {
            ready = false;
            state = 0;
            done = true;
            StartCoroutine(Example());
        }
        if (ready && done) {
            switch (state) {
                case 0:
                    b1.transform.position = new Vector3(1920, b1.transform.position.y, b1.transform.position.z);
                    break;
                case 1:
                    b2.transform.position = new Vector3(1920, b2.transform.position.y, b2.transform.position.z);
                    break;
            }
            done = false;
        }
    }


    IEnumerator Example() {
        yield return new WaitForSeconds(wait);
        ready = true;

    }


}
