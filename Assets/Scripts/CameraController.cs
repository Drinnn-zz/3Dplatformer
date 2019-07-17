using UnityEngine;

public class CameraController : MonoBehaviour{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Update(){
        if (target){
            Vector3 newPos = target.position + offset;
            transform.position = newPos;
        }
    }
}
