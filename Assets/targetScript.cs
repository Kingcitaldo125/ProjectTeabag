using UnityEngine;
using System.Collections;

public class targetScript : MonoBehaviour
{
    GameObject mObj;
    GameObject myObj;
    GameObject score;
    public Vector3 mPath;
    public GameObject emitterPrefab;
    public float pathTime;
    float timeElapsed;
    bool isOn,rising,falling;
    float riseTimer = 0.5f;
    float fallTimer = 0.5f;

    //public AudioSource audio;
    //public AudioClip DingClip;

    void Start()
    {
        mObj = gameObject;
        myObj = GameObject.Find("PlayerPrefab");
        score = GameObject.Find("ScoreText");
    }
    void eventTriggered()
    {
        mObj.SendMessage("turnOn");
    }
    void FixedUpdate()
    {
        //audio = GetComponent<AudioSource>();
        //audio.Play();
        //audio.Play(44100);
        float dt = Time.deltaTime;
        //move the target along its path
        if (mPath != null && isOn)
        {
            timeElapsed += dt;
            if (timeElapsed >= pathTime)
            {
                timeElapsed = 0;
                mPath = -1 * mPath;
            }
            mObj.transform.Translate(dt * mPath);
        }
        if(rising)
        {
            //audio.Play();
            //audio.Play(44100);
            riseTimer -= dt;
            mObj.transform.position += new Vector3(0, (dt/.5f)*(mObj.transform.localScale.y / 2), 0);
            mObj.transform.Rotate(new Vector3(0, 0, (-90 * dt / .5f)));
            if (riseTimer<=0)
            {
                rising = false;
                isOn = true;
            }
        }
        if (falling)
        {
            //audio.clip = DingClip;
            //audio.Play();
            //audio.Play();
            //audio.Play(44100);

            fallTimer -= dt;
            mObj.transform.position -= new Vector3(0, (dt / .5f) * (mObj.transform.localScale.y / 2), 0);
            mObj.transform.Rotate(new Vector3(0, 0, (90 * dt / .5f)));
            if (fallTimer <= 0)
            {
                falling = false;
                isOn = false;
                mObj.SetActive(false);
                score.SendMessage("oneUp");
            }
        }
    }
	void rayCastHit(ArrayList list)
    {
        if (emitterPrefab)
        {
            GameObject emitter = Instantiate(emitterPrefab);
			emitter.transform.position = ((RaycastHit)list[0]).point;

			Vector3 forward = (Vector3)list [1];
			Quaternion rotation = Quaternion.LookRotation (forward);

			emitter.transform.rotation = rotation;

            Destroy(emitter, 3.0f);
        }
        mObj.SendMessage("turnOff");
    }
    void rayRomanoCastHit(Vector3 hitPosition)
    {
        myObj.SendMessage("onTopTarget");
    }
    void turnOn()
    {
        rising = true;
    }
    void turnOff()
    {

        falling = true;
    }
}
