using UnityEngine;

public class DesktopBuddy : MonoBehaviour
{

    [SerializeField] private float sleepDelay;

    [SerializeField] private Mood currMood;
    private float sleepTimer;
    [SerializeField] private Dragable windowDrag;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Sprite[] moodFaces;
    private enum Mood
    {
        confused,
        sad,
        happy,
        sleeping
    }

    private void UpdateFace(Mood _mood)
    {
        sp.sprite = moodFaces[(int)_mood];
    }

    void Update()
    {
        sleepTimer += Time.deltaTime;
        if(sleepTimer > sleepDelay)
        {
        }
        if (windowDrag.GetHeld())
        {
            sleepTimer = 0;
            currMood = Mood.confused;
        }
        else if(sleepTimer < sleepDelay)
        {
            
            currMood = Mood.happy;

        }
        else
        {
            currMood = Mood.sleeping;

        }
        UpdateFace(currMood);
    }
}
