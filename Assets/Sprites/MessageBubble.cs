using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Collections;
using NUnit.Framework.Internal;
using System;
using static UnityEngine.EventSystems.EventTrigger;
public class MessageBubble : MonoBehaviour
{
    [SerializeField] private GameObject backCover;
    [SerializeField] private TextMeshPro headTextObj;
    [SerializeField] private TextMeshPro messageText;
    [SerializeField] private TextMeshPro frequencyText;
    [SerializeField] private float lineWidth;
    private bool runningWakeHeader;
    [SerializeField] private float headerFlickerSpeed;
    [SerializeField] private int headerFlickerDurration;
    public bool DebugFlicker;
    [SerializeField] private float incomingHangTime;
    [SerializeField] private float typeSpeed;
    [SerializeField] private float radioNameHangtime;
    [SerializeField] private float messageHangTime;
    [SerializeField] private Vector2 timeBetweenMessages;
    public float timeDelay;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        ClearAll();
    }


    void Update()
    {
        if (timer <= 0)
        {
            if (DBManager.loaded)
            {
                timeDelay = UnityEngine.Random.Range(timeBetweenMessages.x, timeBetweenMessages.y) * 60;
                timer = timeDelay;
                object[] entry;
                entry = DBManager.GetEntryAtRandomIndex();
                if (entry != null)
                {
                    while (true)
                    {

                        if (
                            !string.IsNullOrEmpty(entry[3].ToString()) &&
                            entry[3].ToString() != "write your message here and it will be sent across the radio bubbles\n" &&
                            entry[3].ToString() != "write your message here and it will be sent across the radio bubbles"
                            )
                        {

                            break;
                        }
                        entry = DBManager.GetEntryAtRandomIndex();
                    }

                    StartCoroutine(WakeRadio(entry[2].ToString(), entry[3].ToString(), Convert.ToSingle(entry[1])));
                }
            }
        }
        timer -= Time.deltaTime;
        backCover.GetComponent<SpriteRenderer>().size = new Vector2(backCover.GetComponent<SpriteRenderer>().size.x, Mathf.Max(headTextObj.textInfo.lineCount * lineWidth, 1));
    }
    private IEnumerator WakeRadio(string _radioName, string _message, float _frequency)
    {
        ClearAll();
        if (runningWakeHeader) yield break;
        int currFlicketCount = 0;
        float flickerTimer = 0;
        headTextObj.gameObject.SetActive(true);
        headTextObj.text = "INCOMING";
        while (currFlicketCount < headerFlickerDurration * 2)
        {
            if (flickerTimer <= headerFlickerSpeed)
            {
                flickerTimer += Time.deltaTime;

            }
            else
            {
                headTextObj.gameObject.SetActive(currFlicketCount % 2 == 0 ? false : true);

                flickerTimer = 0;
                currFlicketCount++;
            }
            yield return null;
        }
        yield return new WaitForSeconds(incomingHangTime);

        StartCoroutine(Type(headTextObj, _radioName));
        SetFrequency(_frequency);
        yield return new WaitForSeconds(radioNameHangtime);
        StartCoroutine(Type(messageText, _message));
        yield return new WaitForSeconds(messageHangTime);
        runningWakeHeader = false;
    }
    private void SetFrequency(float _val)
    {
        string str = _val.ToString();
        if (_val == (int)_val)
        {
            str += ".0";
        }
        str += " MHz";
        StartCoroutine(Type(frequencyText, str));

    }
    private IEnumerator Type(TextMeshPro _obj, string _str)
    {
        _obj.text = "";

        for (int i = 0; i < _str.Length; i++)
        {

            _obj.text += _str[i];

            yield return new WaitForSeconds(typeSpeed);
        }
    }
    private void ClearAll()
    {
        headTextObj.text = "";
        messageText.text = "";
        frequencyText.text = "";
    }
    private void DissableHeader()
    {
        headTextObj.gameObject.SetActive(false);
    }
}
