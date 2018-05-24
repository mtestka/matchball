using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragingMoving : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime, ballx, bally;
	private Ball ball;

	// Use this for initialization
	void Start () {
		//Debug.Log ("Got component");
	}

	/*public void MoveStart(){
			ball.transform.Translate (new Vector3 (0, 0, 0));
	}*/

	public void DragStart(){
			//captur time and position of dragstart, mouseclick
			dragStart = Input.mousePosition;
			Debug.Log ("Dragged start"); //usunąć znaczniki ważny kod
			//startTime = Time.time;
	}

	public void DragEnd(){
			//launch the ball
			/*dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;

			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			// y because we switch screen in y, but want ball to move in z
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);
			ball.Launch (launchVelocity);*/
		dragEnd = Input.mousePosition;
		//ballx = ball.transform.position.x;
		//bally = ball.transform.position.y;
		Debug.Log ("Dragged end");
		//endTime = Time.time;
		if (dragEnd.x > dragStart.x) {
			//ball.transform.Translate (new Vector3 (ballx + 1.7f, bally, 0));
			Ball.right = true;
		} else if (dragEnd.x < dragStart.x) {
			//ball.transform.Translate (new Vector3 (ballx - 1.7f, bally, 0));
			Ball.left = true;
		}
	}

	public void EnterLeft(){
		Ball.left = true;
	}

	public void EnterRight(){
		Ball.right = true;
	}
}