using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class respawnpoint : MonoBehaviour
{
    public Vector3 respawnPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player"){
            //  CharacterController cc = other.gameObject.GetComponent(typeof(CharacterController)) as CharacterController;
            // cc.Move();
            ThirdPersonController tpc = other.gameObject.GetComponent(typeof(ThirdPersonController)) as ThirdPersonController;
            tpc._controller.enabled = false;
            other.gameObject.transform.position = respawnPos;
            tpc._controller.enabled = true;
        }
    }
}
