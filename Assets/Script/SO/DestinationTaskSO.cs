using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class DestinationTaskSO : GameTaskSO
{
    public List<Vector3> destinations;
    private Vector3 dest;
    private int index;
    public GameObject symbol;
    // Start is called before the first frame update
    private Transform player;
    private GameObject Target;
    private PlayerAttribute playerAttribute;
    public override void Starttask(){
        state = GameTaskState.InProgress;
        if(start!=null){InventoryManager.instance.AddItem(start);}
        player=GameObject.Find("Player").GetComponent<Transform>();
        playerAttribute=GameObject.Find("Player").GetComponent<PlayerAttribute>();
        dest=destinations[0];
        Target=null;
        isfail=false;
    }
    // Update is called once per frame
    public override void Fail(){
        isfail=true;
        state = GameTaskState.UnStart;
        if(Target!=null){Destroy(Target.gameObject);}

    }
    public override void UpdateState()
    {   if(state==GameTaskState.InProgress){
        //Debug.Log(Vector3.Distance(player.position,destinations[0]));
        index=destinations.IndexOf(dest);
        if(Target==null) {Target=GameObject.Instantiate(symbol,dest,Quaternion.identity);};
        if(playerAttribute.Mind<300){Fail();return;}
        if(Vector3.Distance(player.position,dest)<5f){
            if(Target!=null){Destroy(Target.gameObject);}
            if(index==destinations.Count-1){Complete();return;}else{dest=destinations[index+1];}}}


    }


}
