using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hands_together : MonoBehaviour {

    public Transform left_hand;
    public Transform right_hand;

    public GameObject hand_sphere;

    float distance;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(left_hand.transform.position, right_hand.transform.position);
        if (distance < 0.15)
        {
            hand_sphere.transform.position = new Vector3((left_hand.position.x + right_hand.position.x) / 2,
                (left_hand.position.y + right_hand.position.y) / 2,
                (left_hand.position.z + right_hand.position.z) / 2);
            hand_sphere.SetActive(true);
        }
        else
        {
            
        }
    }

    public void Reset()
    {
        hand_sphere.SetActive(false);
        hand_sphere.GetComponent<plate_collider>().CPR_state = plate_collider.state.free;
    }
}
