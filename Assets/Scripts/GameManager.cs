using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Animator cat;
    public float speed;
    public float rotationSpeed = 0.1f;

    CanvasManager canvas;
    CanvasManager canvasManager;
    // Use this for initialization
    void Awake () {
        cat.SetInteger("MovementAnimation", 3);
        canvas = GameObject.Find("Canvas").GetComponent<CanvasManager>();
    }
	
	// Update is called once per frame
	void Update () {

        //movementAnimation
        // 1 -> IDLE
        // 2 -> EAT
        // 3 -> WALK
        // 4 -> JUMP
        Debug.Log(speed);
        Time.timeScale = 1;
        cat.transform.Translate(0, 0, Input.GetAxis("Vertical") * canvas.speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.LeftArrow))
            cat.transform.Rotate(0, -rotationSpeed, 0);
        if(Input.GetKey(KeyCode.RightArrow))
            cat.transform.Rotate(0, rotationSpeed, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "star")
        {
            canvas.CounterStars();
            other.tag = "Untagged";
        }
    }
}
