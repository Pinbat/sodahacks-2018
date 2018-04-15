using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class plate_collider : MonoBehaviour {

    GameObject bottomPlate;
    GameObject topPlate;

    private bool isCollidedWithBottom = false;
    private bool isCollidedWithTop = false;

    public NewtonVR.NVRHand leftHand;
    public NewtonVR.NVRHand rightHand;

    private int count = 0;

    public enum state {free, in_chest, completed };

    public state CPR_state;

	// Use this for initialization
	void Start () {
        CPR_state = state.free;
    }
	
	// Update is called once per frame
	void Update () {
        if (CPR_state == state.completed)
        {
            leftHand.InputDevice.TriggerHapticPulse(500);
            rightHand.InputDevice.TriggerHapticPulse(500);
        }
        Debug.Log(count);
        if (count >= 20)
        {
            SteamVR_Fade.View(Color.black, 0);
            SceneManager.LoadScene(sceneName: "Video");
        }
	}



    private void OnTriggerEnter(Collider obj)
    {
        switch (CPR_state)
        {
            case state.free:
                if (obj.gameObject.name == "Top")
                {
                    CPR_state = state.in_chest;
                }
                break;
            case state.in_chest:
                if (obj.gameObject.name == "Bottom")
                {
                    CPR_state = state.completed;
                    count += 1;

                }
                    
                else if (obj.gameObject.name == "Top")
                {
                    CPR_state = state.free;
                    
                }
                    
                break;
            case state.completed:
                if (obj.gameObject.name == "Top")
                {
                    CPR_state = state.free;
                    
                }
                break;
            default:
                break;
        }

        
    }
}
