using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Tools tool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tool!=null && Input.GetKeyDown(KeyCode.Space)){
            tool.Pay();
        }  
    }
    public void LoadTool(){
        this.tool=tool;
    }
    public void UnLoadTool(){
        tool=null;
    }
}
