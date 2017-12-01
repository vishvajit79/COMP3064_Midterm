using UnityEngine;
using System.Collections;

//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Midterm                       //
//                       Friday, December 1, 2017                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////

public class JeyManager : MonoBehaviour {

    /// PUBLIC INSTANCE VARIABLES
    [SerializeField]
    public float speed = 5f;

    //some variables
    [SerializeField]
    float minXSpeed = 1f;
    [SerializeField]
    float maxXSpeed = 2f;
    [SerializeField]
    float minYSpeed = -0.5f;
    [SerializeField]
    float maxYSpeed = 0.5f;

    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Vector2 _currentSpeed;
    private Vector2 _currentPosition;
    private AudioSource _birdSound;

    // Use this for initialization
    void Start()
    {
        // Make a reference with the Transform Component
        this._transform = gameObject.GetComponent<Transform>();
        _birdSound = gameObject.GetComponent<AudioSource>();
        this.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        this._currentPosition = this._transform.position;
        this._currentPosition -= new Vector2(this.speed, 0);
        this._transform.position = this._currentPosition;

        //Reuse objects that are out of sight
        if (_currentPosition.x <= -385)
        {
            Reset();
        }

    }

    public void Reset()
    {
        //Provide implementation for the Reset function
        float xSpeed = Random.Range(minXSpeed, maxXSpeed);
        float ySpeed = Random.Range(minYSpeed, maxYSpeed);

        _currentSpeed = new Vector2(xSpeed, ySpeed);
        float y = Random.Range(130, -128);
        _transform.position = new Vector2(487 + Random.Range(0, 50), y);
    }

    public void OnTriggerEnter2D(Collider2D collision){
        //if collides with player
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (_birdSound != null)
            {
                //play sound
                _birdSound.Play();
            }
        }
    }
}
