using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;
    public Transform bulletPos;
    public GameObject bullet;
    private void Awake()
    {
        
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (starterAssetsInputs.shoot)
        {
            animator.SetTrigger("shoot");
            soundManager.instance.gunSound();
            Vector3 mousePos = Vector3.zero;
            Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
            {
                mousePos = raycastHit.point;
            }
            Vector3 aimDir = (mousePos - bulletPos.position).normalized;
            Instantiate(bullet, bulletPos.position, Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false;
        }

    }
   
}
