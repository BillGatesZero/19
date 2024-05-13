using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Tools tool;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {//&& Input.GetKeyDown(KeyCode.F)
        if(tool!=null){
        if((anim.GetCurrentAnimatorStateInfo(0).IsName("2Hand-Sword-Attack1")||anim.GetCurrentAnimatorStateInfo(0).IsName("2Hand-Sword-Attack2")||anim.GetCurrentAnimatorStateInfo(0).IsName("2Hand-Sword-Attack3"))){
            tool.Pay();//print("pay");
        }else{tool.UnPay();//print("unpay");
        } }
    }
    public void LoadTool(Tools tool){this.tool=tool;}
    public void LoadTool(ItemSO Tool){
        if(tool!=null){Destroy(tool.gameObject);UnLoadTool();}
        string prefabname=Tool.Prefab.name;
        Transform toolparent=transform.Find("Armature/Hips/Spine/Spine1/Spine2/RightShoulder/RightArm/RightForeArm/RightHand/"+prefabname+"P");
        GameObject toolgo=GameObject.Instantiate(Tool.Prefab);
        toolgo.transform.SetParent(toolparent);
        toolgo.transform.localPosition=Vector3.zero;
        toolgo.transform.localRotation=Quaternion.identity;
        this.tool=toolgo.GetComponent<Tools>();
    }
    public void UnLoadTool(){
        tool=null;
    }
}
