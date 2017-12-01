using UnityEngine;
using System.Collections;

//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Midterm                       //
//                       Friday, December 1, 2017                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////

public class PlayerManager : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
    [SerializeField]
	public float speed = 5f;
	
	// PRIVATE INSTANCE VARIABLES
	private float _playerInputV;
    private float _playerInputH;
	private Transform _transform;
	private Vector2 _currentPosition;
	
	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		this._currentPosition = this._transform.position;
		
		this._playerInputV = Input.GetAxis ("Vertical");
		// if player input is positive move right 
        // if player input is positive move right 
        if (this._playerInputV > 0) {
            this._currentPosition += new Vector2 (0,this.speed);
        }

        // if player input is negative move left 
        if (this._playerInputV < 0) {
            this._currentPosition -= new Vector2 (0, this.speed);
        }

        this._playerInputH = Input.GetAxis ("Horizontal");
        // if player input is positive move right 
        // if player input is positive move right 
        if (this._playerInputH > 0) {
            this._currentPosition += new Vector2 (this.speed,0);
        }

        // if player input is negative move left 
        if (this._playerInputH < 0) {
            this._currentPosition -= new Vector2 (this.speed,0);
        }

        this._checkBounds ();
		
		this._transform.position = this._currentPosition;
	}
	
	
	// PRIVATE METHODS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	private void _checkBounds() {
		// check if the plane is going out of bounds and keep it inside window boundary
		if (this._currentPosition.y < -75) {
			this._currentPosition.y = -75;
		}
		
		if (this._currentPosition.y > 118) {
			this._currentPosition.y = 118;
		}

        if (this._currentPosition.x < -359) {
            this._currentPosition.x = -359;
        }

        if (this._currentPosition.x > 354) {
            this._currentPosition.x = 354;
        }

	}
}
