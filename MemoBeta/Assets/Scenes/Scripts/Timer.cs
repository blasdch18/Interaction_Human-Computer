using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI.InputField.text;
//using UnityEngine.AudioClip;

public class Timer : MonoBehaviour
{
	public Text timerText;
	private static float startTime;
	private bool finnished = false;
    public Text angle;
    public int counter;
    public Text laps;
    public int lapsCounter;
    public int limitLap;
    public Text tracks;

    public Button easy;
    public Button mid;
    public Button hard;

    public GameObject TimerPanel;
    public Slider slider;
    public ParticleSystem particles1;
    public ParticleSystem particles2;
    public ParticleSystem particles3;

    private double targetProgress = 0;
    public  float FillSpeed ;

    public AudioSource source;

    public AudioClip coin;
    public AudioClip m_red;
    public AudioClip m_green;

    public Text UserName;
    public GameObject UserPanel;
    string name;

    public GameObject SummPanel;
    public Text UserF;
    public Text timedF;
    public Text LapsF;

    // Start is called before the first frame update
    void Start()
    {
        //source = GetComponent<AudioSource>();
        //Button btn = easy.GetComponent<Button>();
        //easy.onClick.AddListener(taskeasy);
        //mid.onClick.AddListener(taskmid);
        //hard.onClick.AddListener(taskmid);
        //startTime -= Time.deltaTime;
        slider.maxValue = limitLap;
    }
    void taskeasy()
    {
        limitLap = 2;
        slider.maxValue = limitLap;
        FillSpeed = 2.572f;
        if(TimerPanel != null)
        {
            TimerPanel.SetActive(true);
            startTime = Time.time;
        }
        //startTime = Time.time;
        Debug.Log("whyyyyy");
        tracks.color = Color.green;
        timerText.color = Color.green;
    }
    void taskmid()
    {
        limitLap = 4;
        slider.maxValue = limitLap;
        FillSpeed = 3f;
        if(TimerPanel != null)
        {
            TimerPanel.SetActive(true);
            startTime = Time.time;
        }

        
        tracks.color = Color.yellow;
        timerText.color = Color.yellow;
    }
    void taskhard()
    {
        limitLap = 6;
        slider.maxValue = limitLap;
        FillSpeed = 3.255f;
        if(TimerPanel != null)
        {
            TimerPanel.SetActive(true);
            startTime = Time.time;
        }
        
        tracks.color = Color.red;
        timerText.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        //startTime = 0;
        //Button btn = easy.GetComponent<Button>();
        easy.onClick.AddListener(taskeasy);
        mid.onClick.AddListener(taskmid);
        hard.onClick.AddListener(taskhard);
        //Debug.Log(angle.text);
        //int tmp = System.Int32.Parse(angle.text);
        //Debug.Log(tmp);

    	if(angle.text == "90 °")
        {
            counting();
    		return;
        }
        if(counter >= 13)
        {
            counter = 0;
            countingLaps();
            return;
        }
        if(lapsCounter >= limitLap + 1)
        {
            counter = 0;
            Finnish();
            return;
        }
    	float t =Time.time - startTime;
    	string minutes = ( (int) t /60).ToString();
    	string seconds = (t % 60).ToString("f2");
    	timerText.text = minutes + ":" + seconds;     
        setTextCount();
        UserPanelDown();
    }
    public void Finnish()
    {
        source.PlayOneShot(m_green,1F);
    	finnished = true;
    	timerText.color = Color.white;
        ShowSummary();
    }
    public void counting()
    {
        counter++;
        source.PlayOneShot(coin,1F);
        Increment(counter);
    }
    public void countingLaps()
    {
        lapsCounter++;

        source.PlayOneShot(m_red,1F);    
       
        //Increment(lapsCounter);
    }
    void setTextCount()
    {
        tracks.text = "#" + counter.ToString() + " tracks"  ;
        laps.text = "LAP" +lapsCounter.ToString();
    }
    public void Increment(double newProgress)
    {
        targetProgress = slider.value + newProgress;
        if(slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
            if(targetProgress<= limitLap/3)
            {
                particles1.Play();
            }
            if(newProgress<= limitLap/2)
            {
                particles2.Play();
            }
            if(newProgress<= limitLap/1)
            {
                particles3.Play();
            }
        }
    }
    void UserPanelDown()
    {
        name= UserName.text;
        Debug.Log(name);
        if( Input.GetKeyDown(KeyCode.Return))
        {
            UserPanel.SetActive(false);
        }
    }
    void ShowSummary()
    {
        SummPanel.SetActive(true);
        UserF.text = name;
        timedF.text = "Total Time : "+timerText.text;
        LapsF.text = "LAPS #" +limitLap.ToString();
        LapsF.color = tracks.color;
    }
}
