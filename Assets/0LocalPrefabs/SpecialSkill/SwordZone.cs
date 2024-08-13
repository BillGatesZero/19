using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordZone : MonoBehaviour
{
    public float time = 0;
    private float timeleft;
    private Transform sword;
    public GameObject prefab;
    // Start is called before the first frame update
    public void Start()
    {
        Destroy(this.gameObject, 1f);
        timeleft = time;
        sword = transform.Find("SwordPoint");
    }

    // Update is called once per frame
    public void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0)
        {timeleft=100;
            Fire();
        }
        
    }
    public void Fire()
    {
        GameObject obj = GameObject.Instantiate(prefab, sword.position, sword.rotation);
        obj.GetComponent<Rigidbody>().velocity = new Vector3(0, -20, 0);
       

    }
}

