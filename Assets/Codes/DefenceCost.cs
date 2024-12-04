using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceCost : MonoBehaviour
{
    [SerializeField] int cost = 50;
    [SerializeField] float buildDelay = 0.2f;

    void Start()
    {
        StartCoroutine(Construct());
    }

    public bool CreateDefense(DefenceCost defenseObj, Vector3 position)
    {
        Source source = FindObjectOfType<Source>();

        if (source == null)
        {
            return false;
        }

        if (source.CurrentMoney  >= cost)
        {
            Instantiate(defenseObj, position, Quaternion.identity);
            source.DecreaseMoney(cost);
            return true;
        }

        return false;
    }

    IEnumerator Construct ()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }
    }


}
