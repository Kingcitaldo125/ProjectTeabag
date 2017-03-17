using UnityEngine;
using System.Collections;

public class fire_once_Script : MonoBehaviour
{

    public Font ammoFont;
    private bool canFire = true;
    private bool isReloading = false;

    public int maxAmmoClip = 30;
    public int maxAmmo = 300;
    public int currAmmoClip = 30;
    public int currAmmo = 300;

    public float shotDelay = 0.1f;
    public float reloadDelay = 2f;

    public float recoilMin = 6f;
    public float recoilMax = 9f;

    public float bulletDeviation = .02f;
    public float adsBulletDeviation = 0.002f;

    private float shotTime;

    private AudioSource audio;

    public AudioClip ReloadClip;
    public AudioClip RifleShotClip;
    public AudioClip PistolShotClip;

    public bool pistolEquipped = false;

    private bool triggerFired = false;

    public bool autoFireOn = true;

    public bool noClipOn = true;

    public bool isADS = false;

    private float currentBulletDeviation = 0f;

    void Start()
    {
        currentBulletDeviation = bulletDeviation;
    }

    void fire()
    {
        if(pistolEquipped)
            audio.clip = PistolShotClip;
        else
            audio.clip = RifleShotClip;
        audio.Play();
        //audio.Play(44100);
        SendMessage("castRay", currentBulletDeviation, SendMessageOptions.DontRequireReceiver);
		SendMessage("recoil", Random.Range(recoilMin, recoilMax), SendMessageOptions.DontRequireReceiver);
        if(!autoFireOn)
            canFire = false;
        if(!noClipOn)
            currAmmoClip -= 1;
        shotTime = Time.time + shotDelay;
    }

    // Update is called once per frame
    void Update ()
    {
        SendMessage("castRayRomano", null, SendMessageOptions.DontRequireReceiver);
        //"gpad_rtrigger"
        audio = GetComponent<AudioSource>();
        if (Input.GetAxisRaw("gpad_rtrigger") == 0 && !canFire)
            canFire = true;
        if (Input.GetButtonUp("Fire1") && Input.GetAxisRaw("gpad_rtrigger") == 0 && !canFire)
            canFire = true;

        /*//"gpad_rtrigger"
        if (Input.GetAxis("gpad_rtrigger") > 0.0f && Time.time > shotTime)
        {
            //triggerFired = true;
            if (currAmmoClip > 0)// && !triggerFired
            {
                triggerFired = true;
                fire();
            }
            else if (currAmmo > 0 && !isReloading)
            {
                shotTime = Time.time + reloadDelay;
                canFire = false;
                isReloading = true;
            }
        }
        else
            triggerFired = false;*/
        if ((Input.GetButton("Fire1") || Input.GetAxisRaw("gpad_rtrigger") != 0) && canFire && Time.time > shotTime)
        {
            //Debug.Log(Input.GetButtonDown("Fire1"));
            if (currAmmoClip > 0)
            {
                fire();
            }
            else if (currAmmo > 0 && !isReloading)
            {
                shotTime = Time.time + reloadDelay;
                canFire = false;
                isReloading = true;
                audio.clip = ReloadClip;
                audio.Play();
            }
        }
        /*
        if(Input.GetButtonDown("gamepad_lbumper") && currAmmoClip < maxAmmoClip && currAmmo > 0 && !isReloading)
        {
            shotTime = Time.time + reloadDelay;
            canFire = false;
            isReloading = true;
        }*/
        if ((Input.GetKeyDown("r") || Input.GetButtonDown("gamepad_lbumper")) && currAmmoClip < maxAmmoClip && currAmmo > 0 && !isReloading)
        {
            shotTime = Time.time + reloadDelay;
            canFire = false;
            isReloading = true;
            audio.clip = ReloadClip;
            audio.Play();
        }

        if (isReloading && Time.time > shotTime)
        {
            reload();
            canFire = true;
            isReloading = false;
        }

        //Changed the deviation if you are in ADS mode
        if (Input.GetMouseButtonDown(1) && !isADS)
        {
            currentBulletDeviation = adsBulletDeviation;
            isADS = true;
        }
        else if (Input.GetMouseButtonDown(1) && isADS)
        {
            currentBulletDeviation = bulletDeviation;
            isADS = false;
        }
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.font = ammoFont;
        myStyle.fontSize = 20;
		//string text = currAmmoClip.ToString() + "/" + currAmmo.ToString();
        GUI.Label(new Rect(10, 10, 100, 30), currAmmoClip.ToString(), myStyle);
        GUI.Label(new Rect(10, 35, 100, 30), currAmmo.ToString(), myStyle);
    }

    void reload()
    {
        if (currAmmo > 0)
        {
            int refill = maxAmmoClip - currAmmoClip;
            if (refill > currAmmo)
                refill = currAmmo;
            
            currAmmo -= refill;
            currAmmoClip += refill;
        }
    }
}
