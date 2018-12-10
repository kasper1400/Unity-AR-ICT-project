using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour {

    public GameObject NPCAssistant;
    public GameObject character;

    // The target marker.
    public Transform target;

    // Speed in units per sec.
    public float speed;


    private bool IsAssistantActive;



    // Use this for initialization
    void Start () {


        IsAssistantActive = true;
        //NPCAssistant.SetActive(false);

        // Playing walking animation
        character.GetComponent<Animation>().Play("walking");
        // Looping animation
        this.GetComponent<Animation>()["walking"].wrapMode = WrapMode.Loop;
    }

    // Update is called once per frame
    void Update () {

        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "MainCamera")
        {
            Debug.Log("NPC assistant has collided with AR Camera");

            // Stop NPC from moving closer to the camera
            speed = 0;

            //character.GetComponent<Animation>().Stop();
            //character.GetComponent<Animation>().Play("handmove");
            character.GetComponent<Animation>().Play("handmove");
        }

    }
}
