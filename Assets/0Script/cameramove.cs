using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cameramove : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
     private CinemachineCameraOffset camera;
    private Vector3 vs;
    private float maxZ;
    private float sleep_;
    private float znum;
 
    void Start()
    {
        camera = GetComponent<CinemachineCameraOffset>();
        znum = 0.2f;
        maxZ = 0.8f;
        sleep_ = 0.1f;
        Debug.Log(camera);
    }
 
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            vs.z = Mathf.Lerp(vs.z, maxZ, sleep_);
        }
        else
        {
            vs.z = Mathf.Lerp(vs.z, 0, sleep_);
        }
        camera.m_Offset = vs;
    }


}
