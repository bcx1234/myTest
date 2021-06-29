using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTran;//Ö÷½ÇµÄtransform
    public float MaxDistanceX = 2;
    public float MaxDistanceY = 2;
    public float xSpeed = 4;
    public float ySpeed = 4;
    public Vector2 maxXandY;
    public Vector2 minXandY = new Vector2(-8, 8);
    // Start is called before the first frame update
    private bool NeedMoveX()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x - playerTran.position.x) > MaxDistanceX)
            bMove = true;
        else
            bMove = false;
        return bMove;
    }
    private bool NeedMoveY()
    {
        bool bMove_2 = false;
        if (Mathf.Abs(transform.position.y - playerTran.position.y) > MaxDistanceY)
            bMove_2 = true;
        else
            bMove_2 = false;
        return bMove_2;
    }

    void Start()
    {
        
    }
    private void Awake()
    {
        playerTran = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void TrackPlayer()
    {
        float newX = transform.position.x;
        if (NeedMoveX())
         newX = Mathf.Lerp(transform.position.x, playerTran.position.x,xSpeed*Time.deltaTime);
            newX = Mathf.Clamp(newX, minXandY.x, maxXandY.y);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        
        float newY = transform.position.y;
        if (NeedMoveY())
       newY = Mathf.Lerp(transform.position.y, playerTran.position.y, ySpeed * Time.deltaTime);
        newY= Mathf.Clamp(newY, minXandY.x, maxXandY.y);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        
        
    }
    private void FixedUpdate()
    {
        TrackPlayer();
    }
}
