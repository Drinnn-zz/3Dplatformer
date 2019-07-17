using UnityEngine;

public class EnemyController : MonoBehaviour{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 offsetEndPos;

    private Vector3 startPos;
    private Vector3 targetPos;

    private void Awake(){
        startPos = transform.position;
        targetPos = startPos + offsetEndPos;
    }

    private void Update(){
        HandleMovement();
    }

    void HandleMovement(){
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        if (transform.position == targetPos){
            if (targetPos == startPos){
                targetPos = startPos + offsetEndPos;
            }
            else if (targetPos == startPos + offsetEndPos){
                targetPos = startPos;
            }
        }
    }
}

