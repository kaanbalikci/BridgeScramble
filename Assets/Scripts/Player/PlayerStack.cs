using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStack : MonoBehaviour
{
    public List<GameObject> stackList = new List<GameObject>();
    //11.046 - 9.75 - 
    //cam = -12.62 , 22.8 = 35.42
    [SerializeField] private Transform parent;
    [SerializeField] private Text stackText;
    [SerializeField] Camera mainCam;

    private int stackScore = 0;
    private int bridgeCount = 0;

    //Bridge positions
    private Vector3 firstPos = new Vector3(6.4f, 0.67f, 10.669f); //second 11.97 = 1.301
    private Vector3 firstScale = new Vector3(3, 0.1f, 1.3f);


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenCube") && stackScore <5 )
        {
            other.transform.parent = parent;
            stackList.Add(other.gameObject); //add cube to list
            Vector3 parentPos = parent.transform.position;
            other.transform.position = new Vector3(parentPos.x, parentPos.y + ((stackScore * 1.5f) / 10), parentPos.z); //cube pos change to our backside
            stackScore++;
            stackText.text = "Stack: " + stackScore + " / 5";
            Debug.Log("HIT");
        }

        if (other.gameObject.CompareTag("BridgePoint") && stackScore > 0)
        {
            //change bridge point to next step
            Vector3 bpTransform = other.transform.localPosition;
            

            //build bridge
            stackList[stackList.Count - 1].transform.localScale = firstScale;
            stackList[stackList.Count - 1].transform.position = new Vector3(firstPos.x, firstPos.y, firstPos.z + (1.3f * bridgeCount));
            stackList[stackList.Count - 1].gameObject.transform.parent = null;
            stackList[stackList.Count - 1].gameObject.tag = "Untagged";
            stackList[stackList.Count - 1].gameObject.GetComponent<BoxCollider>().isTrigger = false;
            stackList.RemoveAt(stackList.Count - 1);
            stackScore--;
            bridgeCount++;

            //Go next level
            if(bridgeCount == 12)
            {
                other.transform.localPosition = new Vector3(bpTransform.x, bpTransform.y, bpTransform.z + 35.42f);
                bridgeCount = 0;
            }
        }
    }

 
}
