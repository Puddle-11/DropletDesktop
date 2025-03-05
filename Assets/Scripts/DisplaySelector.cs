using UnityEngine;

public class DisplaySelector : MonoBehaviour
{
    [SerializeField] private GameObject displayCheckBox;
    [SerializeField] private Material mat;
    [SerializeField] private float spacing;
    private int dispCount = 4;
    [SerializeField] private AnimationCurve expandCurve;
    [SerializeField] private Toggle toggleObject;
    [SerializeField] private float expandTime;
    [SerializeField] private GameObject[] boxes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dispCount = Display.displays.Length;
        if(dispCount > 1)
        {
            CreateBoxes();
            SetSelected();
        }
    }
    void CreateBoxes()
    {
        boxes = new GameObject[dispCount];
        for (int i = 0; i < dispCount; i++)
        {
            GameObject g = Instantiate(displayCheckBox, transform);
            g.GetComponentInChildren<MeshRenderer>().material = new Material(mat);
            g.transform.localPosition = Vector3.zero;
            boxes[i] = g;
            CollapseToggle cref = g.AddComponent<CollapseToggle>();
            cref.SetLerpTime(expandTime);
            cref.SetLerpCurve(expandCurve);
            cref.SetToggleObject(toggleObject);
            cref.SetOpenPosition(new Vector3(spacing * (i +1 ), 0, 0));
            DisplayToggle dRef = g.GetComponent<DisplayToggle>();
            dRef.coroDisplay = i;
        }
    }
    void SetSelected()
    {
        int sel = PlayerPrefs.GetInt("UnitySelectMonitor");
        Debug.Log(sel);
        boxes[sel].GetComponent<SpriteRenderer>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
