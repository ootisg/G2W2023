using UnityEngine;


public class BasicRigidBodyPush : MonoBehaviour
{
	public LayerMask pushLayers;
	public bool canPush;
	[Range(0.5f, 5f)] public float strength = 1.1f;

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		
		if (canPush) PushRigidBodies(hit);
	}

	private void PushRigidBodies(ControllerColliderHit hit)
	{
	//	Debug.Log(hit.collider);
		// https://docs.unity3d.com/ScriptReference/CharacterController.OnControllerColliderHit.html

		// make sure we hit a non kinematic rigidbody
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic) return;

		// make sure we only push desired layer(s)
		var bodyLayerMask = 1 << body.gameObject.layer;
		if ((bodyLayerMask & pushLayers.value) == 0) return;
		
		
		// We dont want to push objects below us
		

		// Calculate push direction from move direction, horizontal motion only
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

		// Apply the push and take strength into account

		if (hit.moveDirection.y < -0.3f){
			pushDir = new Vector3(Random.Range(-3.0f, 3.0f),Random.Range(0f, 3f),Random.Range(-3.0f, 3.0f));
		}		
		
		body.AddForce(pushDir * strength, ForceMode.Impulse);
	}
}