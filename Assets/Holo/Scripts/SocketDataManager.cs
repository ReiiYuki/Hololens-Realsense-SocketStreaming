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
    }

    IEnumerator ConnectToServer()
    {
        yield return new WaitForSeconds(0.5f);
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["type"] = "Holo";
        socket.Emit("identify", new JSONObject(data));
        socket.On("leftHandPositionUpdate", OnLeftHandPositionUpdate);
        socket.On("rightHandPositionUpdate", OnRightHandPositionUpdate);
        socket.On("GestureUpdate", OnGestureUpdate);
        yield break;
    }

    void OnLeftHandPositionUpdate(SocketIOEvent evt)
    {
        Debug.Log("PosL : " + evt.data.GetField("x") + "," + evt.data.GetField("y") + "," + evt.data.GetField("z"));
    }

    void OnRightHandPositionUpdate(SocketIOEvent evt)
    {
        Debug.Log("PosR : " + evt.data.GetField("x") + "," + evt.data.GetField("y") + "," + evt.data.GetField("z"));
    }

    void OnGestureUpdate(SocketIOEvent evt)
    {

    }
}
