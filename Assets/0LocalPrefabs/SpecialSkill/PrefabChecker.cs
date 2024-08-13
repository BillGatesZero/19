using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabChecker : MonoBehaviour
{
    public GameObject prefabToCheck;
    public float timeToCheck;
    private float timeleft;
    // Start is called before the first frame update
    void Start()
    {
        timeleft = timeToCheck;
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0)
        {
            if (prefabToCheck == null)
            {
                Destroy(gameObject);
            }
            else
            {
                timeleft = timeToCheck;
                GameObject.Instantiate(prefabToCheck, transform.position+new Vector3(Random.Range(-2f,2f),0,0), transform.rotation);
            }
        }
    }
}
