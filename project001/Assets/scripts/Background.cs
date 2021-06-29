using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] BackGrounds;
    public float fparallax = 10f;
    public float layerFraction = 5f;
    public float FSmooth = 5f;

    Transform cam;
    Vector3 previousCamPos;
    private void Awake()
    {
        cam = Camera.main.transform;
    }
    void Start()
    {
        previousCamPos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        float fParrlaxX = (previousCamPos.x - cam.position.x) * fparallax;
        float fParrlaxY = (previousCamPos.y - cam.position.y) * fparallax;
        for (int i = 0; i < BackGrounds.Length; i++)
        {
            float fNewX = BackGrounds[i].position.x + fParrlaxX * (1 + i * layerFraction);
            Vector3 NewPos = new Vector3(fNewX, BackGrounds[i].position.x, BackGrounds[i].position.z);
            BackGrounds[i].position = Vector3.Lerp(BackGrounds[i].position, NewPos,
                                                    FSmooth * Time.deltaTime);
            float fNewY = BackGrounds[i].position.y + fParrlaxY * (1 + i * layerFraction);
            Vector3 NewPos2 = new Vector3(fNewY, BackGrounds[i].position.y, BackGrounds[i].position.z);
            BackGrounds[i].position = Vector3.Lerp(BackGrounds[i].position, NewPos2,
                                                    FSmooth * Time.deltaTime);
        }
        previousCamPos = cam.position;
    }


}
