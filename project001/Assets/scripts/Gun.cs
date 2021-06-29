using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public float fSpeed = 10;
    PlayerContrl playerctrl;
    // Start is called before the first frame update
    void Start()
    {
        playerctrl = transform.root.GetComponent<PlayerContrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 direction =new Vector3 (0, 0, 0);
            if (playerctrl.bFaceRight)
            {
                Rigidbody2D RockectInstance = Instantiate(rocket, transform.position, Quaternion.Euler(direction));
                RockectInstance.velocity = new Vector2(fSpeed, 0);
            }
            else
            {
                direction.z = 180;
                Rigidbody2D RockectInstance = Instantiate(rocket, transform.position, Quaternion.Euler(direction));
                RockectInstance.velocity = new Vector2(-fSpeed, 0);
            }
        }

    }
}
