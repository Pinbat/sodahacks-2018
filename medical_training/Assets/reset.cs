using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider obj)
    {
        player.GetComponent<hands_together>().Reset();
    }
}
