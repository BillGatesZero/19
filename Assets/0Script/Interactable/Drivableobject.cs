using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drivableobject : InteractableObject
{
    // Start is called before the first frame update
    public bool isdriven=false;
    private GameObject player;
    private GameObject maincamera;
    private void Start()
    {
        isdriven = false;
        player = GameObject.Find("Player");
        maincamera = GameObject.Find("Player/Main Camera");
    }

    // Update is called once per frame
    protected override void Interact()
    {
        print("Interact");
        if (!isdriven)
        {
            isdriven = true;
            //EventsManager.OnAutoDrive?.Invoke();
            player.GetComponent<Playermove>().isstop = true;
            player.transform.SetParent(transform);
            player.transform.localPosition = new Vector3(0.2f, 0.83f, -1.5f);
            player.transform.localRotation = Quaternion.identity;
            maincamera.transform.SetParent(transform);
            player.SetActive(false);
            

            
        }else{
            player.GetComponent<Playermove>().isstop = false;
            player.transform.SetParent(null);
            isdriven = false;
            player.SetActive(true);
            maincamera.transform.SetParent(player.transform);
            maincamera.transform.localPosition = new Vector3(0, 5f, -8f);
}
        
    }
    private void Update(){
        if(isdriven==true&&Input.GetKeyDown(KeyCode.F)){
            player.SetActive(true);
            //player.transform.localPosition = new Vector3(0.2f, 0.83f, -1.5f);
            player.GetComponent<Playermove>().isstop = false;
            player.transform.SetParent(null);
            isdriven = false;
            maincamera.transform.SetParent(player.transform);
            maincamera.transform.localPosition = new Vector3(0, 5f, -8f);
        }
    }
}
