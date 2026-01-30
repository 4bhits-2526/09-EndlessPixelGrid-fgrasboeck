using UnityEngine;

public class InputController : MonoBehaviour
{
    public PixelModell model;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) Toggle(0);
        if (Input.GetKeyDown(KeyCode.DownArrow)) Toggle(1);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Toggle(2);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Toggle(3);
        if (Input.GetKeyDown(KeyCode.UpArrow)) Toggle(4);
        if (Input.GetKeyDown(KeyCode.A)) Toggle(5);
        if (Input.GetKeyDown(KeyCode.W)) Toggle(6);
    }

    void Toggle(int index)
    {
        model.inputLine[index] = !model.inputLine[index];
    }
}
