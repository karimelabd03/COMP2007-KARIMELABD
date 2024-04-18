using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletshot : MonoBehaviour
{

    private Rigidbody bulletrb;
    private void Awake()
    {
        bulletrb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletrb.velocity = transform.forward * 20f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("npc"))
        {
            gamemanager.instance.showQuest();
        }
        else if (other.gameObject.CompareTag("continue"))
        {
            gamemanager.instance.continueButton();
        }
        else if (other.gameObject.CompareTag("startquest"))
        {
            gamemanager.instance.startButton();
        }
        Destroy(gameObject);
    }
}
