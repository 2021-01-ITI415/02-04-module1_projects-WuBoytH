using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject launchPoint;
    void OnMouseEnter() {
        print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }
    void OnMouseExit() {
        print("Slingshot:OnMouseExis()");
        launchPoint.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake(){
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
