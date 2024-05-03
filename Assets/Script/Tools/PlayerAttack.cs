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
        if(tool!=null && Input.GetKeyDown(KeyCode.F)){
            tool.Pay();
        }  
    }
    public void LoadTool(Tools tool){this.tool=tool;}
    public void LoadTool(ItemSO Tool){
        if(tool!=null){Destroy(tool.gameObject);UnLoadTool();}
        string prefabname=Tool.Prefab.name;
        Transform toolparent=transform.Find(prefabname+"P");
        GameObject toolgo=GameObject.Instantiate(Tool.Prefab);
        toolgo.transform.SetParent(toolparent);
        toolgo.transform.localPosition=Vector3.zero+Vector3.up*4f;
        toolgo.transform.localRotation=Quaternion.identity;
        this.tool=toolgo.GetComponent<Tools>();
    }
    public void UnLoadTool(){
        tool=null;
    }
}
