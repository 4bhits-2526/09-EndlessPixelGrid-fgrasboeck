using UnityEngine;
using UnityEngine.UI;

public class PixelController : MonoBehaviour
{
    public PixelModel model;

    
    public Transform gridParent;      
    public Transform inputLineParent; 

    private Image[] gridImages;
    private Image[] inputImages;

    void Awake()
    {
        
        gridImages = gridParent.GetComponentsInChildren<Image>();
        inputImages = inputLineParent.GetComponentsInChildren<Image>();
    }

    void Start()
    {
        RenderGrid();
        RenderInputLine();
    }

    void Update()
    {
        // Steuerung der Eingabezeile
        if (Input.GetKeyDown(KeyCode.S)) Toggle(6);
        if (Input.GetKeyDown(KeyCode.DownArrow)) Toggle(5);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Toggle(4);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Toggle(3);
        if (Input.GetKeyDown(KeyCode.UpArrow)) Toggle(2);
        if (Input.GetKeyDown(KeyCode.A)) Toggle(1);
        if (Input.GetKeyDown(KeyCode.W)) Toggle(0);

      
        if (Input.GetKeyDown(KeyCode.D))
        {
            CommitInputLine();
            RenderGrid();
            RenderInputLine();
        }

        // Reset
       
    }

    // -------- LOGIK --------

    void Toggle(int index)
    {
        model.inputLine[index] = !model.inputLine[index];
        RenderInputLine();
    }

    void CommitInputLine()
    {
        for (int r = 0; r < 9; r++)
            for (int c = 0; c < 7; c++)
                model.grid[r, c] = model.grid[r + 1, c];

        for (int c = 0; c < 7; c++)
        {
            model.grid[9, c] = model.inputLine[c];
            model.inputLine[c] = false;
        }
    }

    void ResetAll()
    {
        for (int r = 0; r < 10; r++)
            for (int c = 0; c < 7; c++)
                model.grid[r, c] = false;

        for (int i = 0; i < 7; i++)
            model.inputLine[i] = false;
    }


    void RenderInputLine()
    {
        for (int i = 0; i < inputImages.Length; i++)
        {
            inputImages[i].color =
                model.inputLine[i] ? Color.white : Color.black;
        }
    }

    void RenderGrid()
    {
        int index = 0;
        for (int r = 0; r < 10; r++)
        {
            for (int c = 0; c < 7; c++)
            {
                gridImages[index].color =
                    model.grid[r, c] ? Color.white : Color.black;
                index++;
            }
        }
    }
}
