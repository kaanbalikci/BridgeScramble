using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : MonoBehaviour
{
    public List<GameObject> stackList = new List<GameObject>();


    [SerializeField] private Transform parent;


    void Start()
    {
        
    }

    
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenCube"))
        {
            other.transform.parent = parent;
            stackList.Add(other.gameObject);
            Debug.Log("HIT");
        }
    }
}
