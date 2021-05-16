using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public float speed = 20f;

    private player playerCtrl;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        anim = transform.root.gameObject.GetComponent<Animator>();
        playerCtrl = transform.parent.GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown ("Fire1"))       //Input.GetKeydown(Keydown.Mouse0);  
        {
            if (player.bFaceRight)
            {
                Rigidbody2D bullet = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bullet.velocity = new Vector2(speed, 0);
            }
            else
            {
                Rigidbody2D bullet = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                bullet.velocity = new Vector2(-speed, 0);
            }
        }
        
    }
}
