using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] squareArray;
    public Transform[] targetArray;
    private Vector3 squarePos;
    private Vector3 targetPos;
  
    void Update()
    {
        IndexCheck();
    }

    private void IndexCheck()
    {
        // for(int i = 0; i <= squareArray.Length; i++)
        // {
        //     Transform squareTransform = squareArray[i];
        //     squarePos = squareTransform.position;
        // }

        // for(int i = 0; i <= targetArray.Length; i++)
        // {
        //     Transform targetTransform = targetArray[i];
        //     targetPos = targetTransform.position;
        // }

        if(squarePos == targetPos)
        {
            Debug.Log("matched");
            Time.timeScale = 0f;
        }
    }
}
