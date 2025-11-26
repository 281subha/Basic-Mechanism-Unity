// using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject square1;
    public GameObject square2;
    public GameObject square3;
    public Transform target1;
    public Transform target2;
    public Transform target3;

    private Vector3[] squareArray;
    private Vector3[] targetArray;

    void Start()
    {
        squareArray = new Vector3[3];
        squareArray[0] = square1.transform.position;
        squareArray[1] = square2.transform.position;
        squareArray[2] = square3.transform.position;

        targetArray = new Vector3[3];
        targetArray[0] = target1.position;
        targetArray[1] = target2.position;
        targetArray[2] = target3.position;
        TargetShuffle();
    }
    void Update()
    {
        if(square1.activeInHierarchy == false && square2.activeInHierarchy == false && square3.activeInHierarchy == false)
        {
            square1.SetActive(true);
            square2.SetActive(true);
            square3.SetActive(true);
            // SquareShuffle();
            TargetShuffle();
            ResetPos();
        }
    }


    private void TargetShuffle()
    {
        // Vector3[] shuffled = (Vector3[])targetArray.Clone();
        for(int i = 0; i < targetArray.Length; i++)
        {
            int random = Random.Range(i, targetArray.Length);
            (targetArray[i], targetArray[random]) = (targetArray[random], targetArray[i]);
        }
        target1.position = targetArray[0];
        target2.position = targetArray[1];
        target3.position = targetArray[2];
    }

    private void ResetPos()
    {
        square1.transform.position = squareArray[0];
        square2.transform.position = squareArray[1];
        square3.transform.position = squareArray[2];
    }
    // private void SquareShuffle()
    // {
    //     // Vector3[] shuffled = (Vector3[])squareArray.Clone();
    //     for(int i = 0; i < squareArray.Length; i++)
    //     {
    //         int random = Random.Range(i, squareArray.Length);
    //         (squareArray[i], squareArray[random]) = (squareArray[random], squareArray[i]);
    //     }
    //     square1.transform.position = squareArray[0];
    //     square2.transform.position = squareArray[1];
    //     square3.transform.position = squareArray[2];
    // }
}
