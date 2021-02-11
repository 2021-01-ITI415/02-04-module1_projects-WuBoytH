using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set Danymically")]
    public float camZ;

    // Start is called before the first frame update
    void Awake(){
        camZ = this.transform.position.z;
    }

    void Start()
    {
        
    }

    void FixedUpdate(){
        if(POI == null) return;

        Vector3 destination = POI.transform.position;
        destination.z = camZ;
        transform.position = destination;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
