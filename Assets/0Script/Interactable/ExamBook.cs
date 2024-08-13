using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamBook : InteractableObject
{
    // Start is called before the first frame update
    public int index;
    public List<ExamQuestionSO> questions;
    public ExamUI examUI;
    void Start()
    {
        index=0;
    }

    // Update is called once per frame
    protected override void Interact(){
        examUI.UpdateContent(questions, index);
    }
}
