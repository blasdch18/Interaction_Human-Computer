using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LineR : MonoBehaviour
{
	LineRenderer Line;
	public Transform[] Positions;

	public Text shoulder_pos;
	public Text elbow_pos;
	public Text hand_pos;

	public Text arm_angle;
	public Text arm_module;

	private float angle;
	private float module;
    // Start is called before the first frame update
    void Start()
    {
        Line = GetComponent<LineRenderer>();
        //SetText();
    }

    // Update is called once per frame
    void Update()
    {
        Line.positionCount = Positions.Length;
        Line.SetPosition(0, Positions[0].position);
        Line.SetPosition(1, Positions[1].position);
        Line.SetPosition(2, Positions[2].position);
        SetText();

    }
    void SetText()
    {
    	shoulder_pos.text = "Shoulder(x;y) : " + Positions[0].position.ToString();
    	elbow_pos.text = "Elbow(x;y) : " + Positions[1].position.ToString();
    	hand_pos.text = "Hand(x;y) : " + Positions[2].position.ToString();
    	arm_angle.text = "Arm_angle : " + angleFunction().ToString() + " °";
    	arm_module.text = "Arm_module : " + moduleFunction().ToString() + " Units";
     }
     public float angleFunction()
     {
     	Vector3 vec1 = Positions[1].position -Positions[0].position;
     	Vector3 vec2 =Positions[2].position -Positions[1].position;
     	float angle_ = Mathf.Atan2(vec2.x - vec1.x, vec2.y - vec1.y );

     	return angle_;
     }
     public float moduleFunction()
     {
     	Vector3 vec1 = Positions[1].position -Positions[0].position;
     	Vector3 vec2 =Positions[2].position -Positions[1].position;
     	float module_ = Vector3.Distance(vec1, vec2);

     	return module_;
     }

}
