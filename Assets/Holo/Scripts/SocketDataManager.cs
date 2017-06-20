using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class SocketDataManager : MonoBehaviour {

    SocketIOComponent socket;

	// Use this for initialization
	void Awake () {
        socket = GetComponent<SocketIOComponent>();
        StartCoroutine(ConnectToServer());
        socket.On("leftHandPositionUpdate", OnLeftHandPositionUpdate);
        socket.On("rightHandPositionUpdate", OnRightHandPositionUpdate);
        socket.On("GestureUpdate", OnGestureUpdate);
    }

    IEnumerator ConnectToServer()
    {
        yield return new WaitForSeconds(0.5f);
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["type"] = "Holo";
        socket.Emit("identify", new JSONObject(data));
        yield break;
    }

    void OnLeftHandPositionUpdate(SocketIOEvent evt)
    {
        
    }

    void OnRightHandPositionUpdate(SocketIOEvent evt)
    {

    }

    void OnGestureUpdate(SocketIOEvent evt)
    {

    }
}
