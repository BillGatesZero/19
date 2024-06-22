using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MindBar : MonoBehaviour
{
    private TextMeshProUGUI mindText;
    private Image mindBar;
    private PlayerAttribute playerAttribute;
    // Start is called before the first frame update
    void Start()
    {
        mindText = transform.Find("MindText").GetComponent<TextMeshProUGUI>();
        mindBar = transform.Find("MindBar").GetComponent<Image>();
        playerAttribute = GameObject.Find("Player").GetComponent<PlayerAttribute>();
    }

    // Update is called once per frame
    void Update()
    {
        mindBar.fillAmount = playerAttribute.Mind / 1000f;
        mindText.text = playerAttribute.Mind + "/1000";
    }
}
