using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloPlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject holoGameObject;
    [SerializeField]
    GameObject playerGameObject;


    void Awake()
    {
        holoGameObject.SetActive(false);    
    }

    void Update()
    {
        var positionOfPlayer = playerGameObject.transform.position;
        float horizontalOffset = 0.8f;
        float verticalOffset = 1.4f;

        if(Input.GetKey(KeyCode.UpArrow)){
            Debug.Log("Up Pressed");
            holoGameObject.transform.position = new Vector3(positionOfPlayer.x,positionOfPlayer.y + verticalOffset , -1f * positionOfPlayer.z + horizontalOffset);
            holoGameObject.SetActive(true);
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            Debug.Log("Down Pressed");
            holoGameObject.transform.position = new Vector3(positionOfPlayer.x,positionOfPlayer.y + verticalOffset , positionOfPlayer.z + horizontalOffset);
            holoGameObject.SetActive(true);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            Debug.Log("Right Pressed");
            holoGameObject.transform.position = new Vector3(-1f *positionOfPlayer.x + horizontalOffset,positionOfPlayer.y + verticalOffset ,positionOfPlayer.z);
            holoGameObject.SetActive(true);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            Debug.Log("Left Pressed");
            holoGameObject.transform.position = new Vector3(positionOfPlayer.x + horizontalOffset,positionOfPlayer.y + verticalOffset ,positionOfPlayer.z);
            holoGameObject.SetActive(true);
        }
        if(Input.GetKey(KeyCode.Return)){
            holoGameObject.SetActive(false);
            Debug.Log("Enter Pressed");
        }
    }
}
