using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public GameObject folow;

    public Vector2 minCampos, maxCampos;

    public float smoothTime;

    private Vector2 velocity;
    private Vector3 velocity3D;


    float cont1 ;

    // Start is called before the first frame update
    void Start()
    {
        cont1 = 2.3f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cont1 = Mathf.SmoothDamp(folow.transform.position.z, transform.position.z, ref velocity3D.z, smoothTime );
        float posX = Mathf.SmoothDamp(transform.position.x, folow.transform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, folow.transform.position.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(Mathf.Clamp(posX, minCampos.x, maxCampos.x), 
                                         Mathf.Clamp(posY, minCampos.y, maxCampos.y),
                                         transform.position.z);
        
    }
}
