using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : MonoBehaviour
{
    // Start is called before the first frame update
    public int Mind = 500;//0
    public int Luck = 0;//1
    public int Stamina = 0;//2
    public int Confidence = 0;//3
    public int Attraction = 0;//4
    public int LiberalKnowledge = 0;//5
    public int MathsKnowledge = 0;//6
    public int PhysicsKnowledge = 0;//7
    public int ComputerKnowledge = 0;//8
    public int ChemistryKnowledge = 0;//9
    public void ChangeAttribute(int type, int value)
    {
        switch (type)
        {
            case 0: Mind += value; if(Mind > 1000) Mind = 1000; return;
            case 1: Luck += value; if(Luck > 1000) Luck = 1000; return;
            case 2: Stamina += value; if(Stamina > 1000) Stamina = 1000; return;
            case 3: Confidence += value;if(Confidence > 1000) Confidence = 1000; return;
            case 4: Attraction += value;if(Attraction > 1000) Attraction = 1000; return;
            case 5: LiberalKnowledge += value; return;
            case 6: MathsKnowledge += value; return;
            case 7: PhysicsKnowledge += value; return;
            case 8: ComputerKnowledge += value; return;
            case 9: ChemistryKnowledge += value; return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
