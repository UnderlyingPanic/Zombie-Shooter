using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour {

    public Transform doors;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(doors);
    }
}