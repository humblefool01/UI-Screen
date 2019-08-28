using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
    public GameObject camera;
    private Rigidbody rb;
    private int force;
    public float factor, gravity_controller, swing_controller;
    private float x, y, z;
    private bool clicked;
    private bool reset;

    public static Controller instance { set; get; }
    void Awake() {
        instance = this;
    }
    public void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        reset = false;
        force = 0;
        clicked = false;
        Spawn();
    }

    public void FixedUpdate() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("SampleScene");
        }
        Gravity();

        if (rb.transform.position.y > 10f && rb.velocity.magnitude != 0f) {
            Swing();
        }

        if (Input.GetKey(KeyCode.D) && force < 40) {
            force += 1;
        }
        if (Input.GetKeyUp(KeyCode.D) && !clicked){
            Shoot(camera, force);
            force = 0;
            clicked = true;
        }
    }

    public void Shoot(GameObject camera, int force) {
        instance.x = instance.rb.transform.position.x - camera.transform.position.x;
        instance.z = instance.rb.transform.position.z - camera.transform.position.z;
        instance.y = force * instance.gravity_controller;
        Vector3 temp = new Vector3(instance.x, 0f, instance.z);
        temp = Vector3.Cross(temp, Vector3.up); //Left Hand Rule used in Unity for Cross product
        temp /= 2f;
        temp += new Vector3(instance.x, instance.y, instance.z);
        instance.rb.AddForce(temp * instance.factor * force, ForceMode.Impulse);
    }
    public void Spawn(){
        // Ball X-Range: -200 to 200; Z-Range: 0 to -200; Camera 60 behind ball in Z

        int a = -1;
        int b = -1;
        a = UnityEngine.Random.Range(-100, 101);
        b = UnityEngine.Random.Range(0, -151);

        transform.position = new Vector3(a, 3f, b);
        camera.transform.position = new Vector3(a, 30f, b - 60f);
        reset = true;
    }

    public void Gravity(){
        if (rb.transform.position.y > 3f){
            rb.AddForce(new Vector3(0f, -rb.mass * 9.81f * 5, 0f));
        }
    }
    public void Swing(){
        Vector3 dir = Vector3.Cross(Vector3.up, new Vector3(x, 0f, z));
        rb.AddForce(swing_controller * dir.normalized, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other) {
        Reset();
    }

    public void Reset(){
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        camera.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        rb.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        force = 0;
        clicked = false;
        Spawn();
    }
}
