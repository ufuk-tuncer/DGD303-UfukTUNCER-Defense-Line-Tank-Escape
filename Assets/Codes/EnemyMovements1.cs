using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements1 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0f, 4f)] float waittime = 1f;

    Target target;

    void OnEnable()
    {
        PathFinding();
        StartAgain();
        StartCoroutine(pathfollowing());
    }

    void Start()
    {
        target = GetComponent<Target>();
    }

    void PathFinding()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path1");

        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    void StartAgain()
    {
        transform.position = path[0].transform.position;
        Vector3 initialLookDirection = path[1].transform.position;
        transform.LookAt(initialLookDirection);
    }

    IEnumerator pathfollowing()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 start = transform.position;
            Vector3 end = waypoint.transform.position;
            float travelamount = 0f;
            transform.LookAt(end);
            transform.position = waypoint.transform.position;

            while (travelamount < 1f)
            {
                travelamount += Time.deltaTime * waittime;
                transform.position = Vector3.Lerp(start, end, travelamount);

                yield return new WaitForEndOfFrame();
            }

        }
        target.Lose();
        gameObject.SetActive(false);
    }
}
