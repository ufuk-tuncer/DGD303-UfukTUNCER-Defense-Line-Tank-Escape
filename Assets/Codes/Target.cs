using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] int gainMoney = 20;
    [SerializeField] int loseMoney = 20;
    Source source;
    void Start()
    {
        source = FindObjectOfType<Source>();
    }

    public void Gain()
    {
        if (source == null){ return; }
        source.IncreaseMoney(gainMoney);
    }

    public void Lose()
    {
        if (source == null) { return; }
        source.DecreaseMoney(loseMoney);
    }
}
