using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineR : MonoBehaviour
{
	LineRenderer Line;
	public Transform[] Positions;
    // Start is called before the first frame update
    void Start()
    {
        Line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Line.positionCount = Positions.Length;
        Line.SetPosition(0, Positions[0].position);
        Line.SetPosition(1, Positions[1].position);
        Line.SetPosition(2, Positions[2].position);

    }
}
