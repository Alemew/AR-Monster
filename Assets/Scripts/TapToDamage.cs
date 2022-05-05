using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TapToDamage : MonoBehaviour
{
    public GameObject Esfera;
    public int damage = 10;
    public float force = 1000;
    public float radiusForce = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Esfera, Camera.main.transform.position, Camera.main.transform.rotation);
            Esfera.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward*force,ForceMode.Impulse);
            Debug.Log("Player has touch the screen");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,Mathf.Infinity))
            {
                Debug.Log("Raycast have collided with something");
                
                hit.collider.gameObject.GetComponent<EnemyLife>().UpdateLifePoints(damage);
            }
        }
    }
}
