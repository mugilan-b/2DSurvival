using UnityEngine;
using System.Collections;

public class XHairScript : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;

    private Vector2 hotSpot;
    private bool isEnabled = false;

    private void Start()
    {
        hotSpot = new Vector2(cursorTexture.height/2, cursorTexture.width/2);
        //Centering ^
        SetCurs(cursorTexture, hotSpot);
    }

    void SetCurs(Texture2D cursorTex, Vector2 hotsp)
    {
        Cursor.SetCursor(cursorTex, hotsp, cursorMode);
    }

    void DisableCurs()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

}

