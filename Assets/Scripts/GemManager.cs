using UnityEngine;
using System.Collections;

//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Midterm                       //
//                       Friday, December 1, 2017                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////

public class GemManager : MonoBehaviour {

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
	
	// Use this for initialization
	void Start () {
		// Make a reference with the Transform Component
		this._transform = gameObject.GetComponent<Transform> ();
		this.Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		this._currentPosition = this._transform.position;
		this._currentPosition -= new Vector2(0, this.speed);
		this._transform.position = this._currentPosition;

        //Reuse objects that are out of sight
        if (_currentPosition.y <= -165)
        {
            Reset();
        }

    }
	
	public void Reset() {
        //Provide implementation for the Reset function
        float xSpeed = Random.Range(minXSpeed, maxXSpeed);
        float ySpeed = Random.Range(minYSpeed, maxYSpeed);

        _currentSpeed = new Vector2(xSpeed, ySpeed);
        float x = Random.Range(366, -362);
        _transform.position = new Vector2(x, 240 + Random.Range(0, 50));
    }


}
