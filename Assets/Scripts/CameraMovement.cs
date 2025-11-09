using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;              
    public float moveSpeed = 2f;     

    private Vector3 targetPos;

    void Update() {
        targetPos = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

    }

}
