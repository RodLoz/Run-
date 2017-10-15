using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum RotationAxes{
MouseXAndY  = 0,
	MouseX = 1,
	MouseY = 2

		}
public class MouseLook : MonoBehaviour {
	
	public static int pointsB;
	public static int pointsG;

	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityHor = 4.0f;
	public float sensitivityVer = 4.0f;

	public float maximumVert = 45.0f;
	public float minimumVert = -45.0f;

	private float _rotationX = 0;

		// Use this for initialization
	void Start () {
		Rigidbody rbd = GetComponent<Rigidbody> ();
		if (rbd != null) {
			rbd.freezeRotation = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (axes == RotationAxes.MouseX) {
			// AQUI IRA LA ROTACION HORIZONTAL
			transform.Rotate(0,  Input.GetAxis("Mouse X") * sensitivityHor,  0 );
		} 
		else if (axes == RotationAxes.MouseY) {
			//AQUI IRA LA ROTACION VERTICAL
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVer;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

			float rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3 (_rotationX, 0, rotationY);
		}

		else{
			//ROTACION HORIZONTAL Y VERTICAL AQUI
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVer;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

			float delta = Input.GetAxis ("Mouse X") * sensitivityHor;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3 (0,rotationY, _rotationX);

		}


	}

	public void PuntosBlue (int ptsB){
		pointsB	 += ptsB;
		GameObject.FindGameObjectWithTag ("BlueGems").GetComponent<TextMesh>().text = "Blue Gems:" + pointsB;

	}

	public void PuntosGreen (int ptsG){
	pointsG += ptsG;
		GameObject.FindGameObjectWithTag ("GreenGems").GetComponent<TextMesh>().text = "Green Gems:" + pointsG;
}
}