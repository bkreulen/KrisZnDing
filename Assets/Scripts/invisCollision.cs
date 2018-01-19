using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class invisCollision : NetworkBehaviour
{

    [SerializeField]
    private Material ghost;
    private Material tmpMat;

    void Start()
    {

    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        MeshRenderer target = other.gameObject.GetComponent<MeshRenderer>();
        if (!other.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)        {
            target.enabled = false;
        }else
        {            
            tmpMat = new Material (target.material);
            target.material = ghost;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        MeshRenderer target = other.gameObject.GetComponent<MeshRenderer>();
        if (!other.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)
        {
            target.enabled = true;
        }
        else
        {
            target.material = tmpMat;
        }
    }

    
}