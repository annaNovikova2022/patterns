using UnityEngine;

public class MoveReceiver : MonoBehaviour
{
    public void MoveOperation(GameObject gameObjectToMove, MoveDirection direction, float distance)
    {
        switch (direction)
        {
            case MoveDirection.up:
                MoveZ(gameObjectToMove, distance);
                break;
            case MoveDirection.down:
                MoveZ(gameObjectToMove, -distance);
                break;
            case MoveDirection.right:
                MoveX(gameObjectToMove, distance);
                break;
            case MoveDirection.left:
                MoveX(gameObjectToMove, -distance);
                break;
        }
    }

    private void MoveZ(GameObject gameObjectToMove, float distance)
    {
        Vector3 newPos = gameObjectToMove.transform.position;
        newPos.z += distance;
        gameObjectToMove.transform.position = newPos;
    }
    private void MoveX(GameObject gameObjectToMove, float distance)
    {
        Vector3 newPos = gameObjectToMove.transform.position;
        newPos.x += distance;
        gameObjectToMove.transform.position = newPos;
    }
}
