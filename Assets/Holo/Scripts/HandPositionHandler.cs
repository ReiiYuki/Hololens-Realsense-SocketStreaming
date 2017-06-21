using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPositionHandler : MonoBehaviour {

    public GameObject leftCursor, rightCursor;

	void OnLeftHandChange(Vector3 position)
    {
        leftCursor.transform.position = position * 100;
    }

    void OnRightHandChange(Vector3 position)
    {
        rightCursor.transform.position = position * 100;
    }

}
