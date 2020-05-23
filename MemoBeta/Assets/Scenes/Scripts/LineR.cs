using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineR : MonoBehaviour
{
	LineRenderer Line;
	public Transform[] Positions;
	//public Text shoulder_pos;
	//public Text elbow_pos;
	//public Text hand_pos;
	public Text arm_angle;
	public Text arm_module;
	public Text angle_elbow;
	public Text counter_angle;
	private float angle;
	private float module;
    [SerializeField]
	private int counter ;
    private float module_;
    private int angle_ ;
    private bool controller;

    public float waitTime = 3.0f;
    private float timer;
    private bool timerActive = false;
    private bool buttonActive = false;
    // Start is called before the first frame update
    void Start()
    {
        Line = GetComponent<LineRenderer>();
        controller = false;
        //counter = 0;
        //SetText();
        //counter_angle.text = "# "+ Countering().ToString() + " Tracks";
    }
    // Update is called once per frame
    void Update()
    {	
        Line.positionCount = Positions.Length;
        Line.SetPosition(0, Positions[0].position);
        Line.SetPosition(1, Positions[1].position);
        Line.SetPosition(2, Positions[2].position);
        SetText();
        angleFunction();
        moduleFunction();
        //Countering();
        

    }
    void SetText()
    {
    	//counter = 0;
    	//shoulder_pos.text = "Shoulder(x;y) : " + Positions[0].position.ToString();
    	//elbow_pos.text = "Elbow(x;y) : " + Positions[1].position.ToString();
    	//hand_pos.text = "Hand(x;y) : " + Positions[2].position.ToString();

    	arm_angle.text = "Arm_angle : " + angle_.ToString() + " °";
    	arm_module.text = "Arm_module : " + module_.ToString("F0") + " Units";
    	angle_elbow.text = angle_.ToString() + " °";
    	
    	//counter_angle.text = "# "+ counter.ToString() + " Tracks";
     }
     public void angleFunction()
     {
     	Vector2 vec1 = Positions[1].position -Positions[0].position;
        //Debug.Log("vec1="+vec1);
     	Vector2 vec2 =Positions[2].position -Positions[1].position;
        //Debug.Log(" vec2="+vec2);
     	angle_ = (int)Vector2.Angle(vec1, vec2);

     	//angle_ = (int)Mathf.Round(angle_ * 1f) / 1f;

     	//return angle_;
     }
     public void moduleFunction()
     {
     	Vector3 vec1 = Positions[1].position -Positions[0].position;
     	Vector3 vec2 =Positions[2].position -Positions[1].position;
     	module_ = Vector3.Distance(vec1, vec2);

     	//return module_;
     }
     private IEnumerator Countering()
     {
     	//counter=0;
     	if( 90 == angle_  )
    	{
    		counter+=1;
            Debug.Log(" ++1");
            yield return new WaitForSeconds(1);
            Debug.Log(" Waited");
    	}
     }
     
}
