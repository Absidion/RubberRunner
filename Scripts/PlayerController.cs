using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float TurnSpeed;
    public static int kills;
    public static int score;
    private Vector3 PosForScore;
    public AudioClip CarEffect;
    public AudioClip WilhelmScream;
    public AudioClip FemaleScream;
    public AudioClip TrashCan;
    public AudioClip TruckReverse;
    public AudioClip ConstructionDrill;
    public AudioClip PopTire;
    public AudioClip HotDogStand;
    private AudioSource AudioObject;
    public GameObject explosion;
    private bool isDead = false;

	// Use this for initialization
	void Start () {
        AudioObject = GameObject.Find("GameManager").gameObject.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        PosForScore = new Vector3(0, 0, 0);
        kills = PlayerPrefs.GetInt("Kills");
    }
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(gameObject.transform.position.z - PosForScore.z) > 50 && gameObject.transform.position.z > -200)
        {
            score++;
            PosForScore = gameObject.transform.position;
        }
    }

    void FixedUpdate() //Physics Update
    {
        Vector3 oldRotation = gameObject.transform.eulerAngles;

        if (!isDead)
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self); // Move forward

            if (Input.GetKey(KeyCode.D)) // Turn right
            {
                Vector3 currentRotation = new Vector3(0, gameObject.transform.rotation.y + TurnSpeed, 0);
                gameObject.transform.Rotate(currentRotation, Space.World);
            }

            if (Input.GetKey(KeyCode.A)) // Turn left
            {
                Vector3 currentRotation = new Vector3(0, gameObject.transform.rotation.y - TurnSpeed, 0);
                gameObject.transform.Rotate(currentRotation, Space.World);
            }

            // Boundary angles
            if (gameObject.transform.eulerAngles.y < 315 && gameObject.transform.eulerAngles.y > 200)
            {
                gameObject.transform.eulerAngles = oldRotation;
            }
            else if (gameObject.transform.eulerAngles.y > 45 && gameObject.transform.eulerAngles.y < 200)
            {
                gameObject.transform.eulerAngles = oldRotation;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            AudioObject.PlayOneShot(CarEffect, 1);
        }

        if (other.gameObject.CompareTag("Hotdog"))
        {
            AudioObject.PlayOneShot(HotDogStand, 1);
        }

        if (other.gameObject.CompareTag("Trashcan"))
        {
            AudioObject.PlayOneShot(TrashCan, 1);
        }

        if (other.gameObject.CompareTag("Car") || other.gameObject.CompareTag("Construction") || other.gameObject.CompareTag("Hotdog"))
        {
            Explode();
        }     
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Person"))
        {
            int m = Random.Range(0, 10);
            if (m >= 5)
                AudioObject.PlayOneShot(WilhelmScream, 1);
            else if (m < 5)
                AudioObject.PlayOneShot(FemaleScream, 1);
        }

        if (other.gameObject.CompareTag("Construction"))
        {
            int m = Random.Range(0, 10);
            if (m >= 5)
                AudioObject.PlayOneShot(TruckReverse, 1);
            else if (m < 5)
                AudioObject.PlayOneShot(ConstructionDrill, 1);
        }
    }

	public int ReturnPlayerKills()
	{
		return kills;
	}

    void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);     
        isDead = true;
        AudioObject.PlayOneShot(PopTire, 0.3f);
        GameObject.Find("GameOver").GetComponent<Canvas>().enabled = true;
        GameObject.Find("GameOver").GetComponent<PauseScript>().ShowSplash();
        gameObject.SetActive(false);
    }	
}
