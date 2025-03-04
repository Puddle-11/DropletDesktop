using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GameObject[] reorderableObjects;
    public Clickable currentObject;

    void Update()
    {
        GetOverlap();
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Release();
        }
    }
    private void Click()
    {
        Collider2D[] clickArr = GetOverlap();
        Collider2D clickedObject = GetTop(clickArr);
        if (clickedObject == null) return;
        if (clickedObject.TryGetComponent(out Clickable cRef))
        {
            PushToTop(cRef);
            cRef.Click();
            currentObject = cRef;
        }
    }
    private void Release()
    {
        if(currentObject != null)
        {
            currentObject.Release();
        }
    }
    private void PushToTop(Clickable _clicked)
    {
        int prevIndex;

        prevIndex = _clicked.GetOrder();
        if (_clicked.GetOrderable() && prevIndex != 0)
        {
            _clicked.SetOrder(0);
            Clickable currCheck = _clicked;
            while (true)
            {
                int n = GetDuplicateOrderIndex(reorderableObjects, currCheck);
                if (n == -1) break;
                currCheck = reorderableObjects[n].GetComponent<Clickable>();
                currCheck.UpdateOrder(1);
            }
        }

    }
    private int GetDuplicateOrderIndex(GameObject[] arr, Clickable r)
    {
        for (int i = 0; i < arr.Length; i++)
        {

            if (arr[i].TryGetComponent(out Clickable cRef))
            {
                if (cRef == r) continue;
                int t = cRef.GetOrder();
                if (t == r.GetOrder()) return i;
            }
        }
        return -1;
    }

    private Collider2D GetTop(GameObject[] arr)
    {
        Collider2D[] newArr = new Collider2D[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i].TryGetComponent(out newArr[i]);

        }
        return GetTop(newArr);
    }
    private Collider2D GetTop(Collider2D[] _collArr)
    {

        if (_collArr.Length == 1)
        {
            return _collArr[0];
        }
        List<Collider2D> TopSortingIndex = new List<Collider2D>();

        int minIndex = int.MaxValue;
        for (int i = 0; i < _collArr.Length; i++)
        {
            if (_collArr[i].TryGetComponent(out Clickable cRef))
            {
                minIndex = cRef.GetOrder() < minIndex ? cRef.GetOrder() : minIndex;
            }
        }
        for (int i = 0; i < _collArr.Length; i++)
        {
            if (_collArr[i].TryGetComponent(out Clickable cRef))
            {
                if (cRef.GetOrder() == minIndex)
                {
                    TopSortingIndex.Add(_collArr[i]);
                }

            }
        }
        if (TopSortingIndex.Count <= 0) return null;
        if (TopSortingIndex.Count == 1)
        {
            return TopSortingIndex[0];
        }
        float minZValue = Mathf.Infinity;
        int index = -1;
        for (int i = 0; i < TopSortingIndex.Count; i++)
        {
            if (TopSortingIndex[i].gameObject.transform.position.z < minZValue)
            {
                minZValue = TopSortingIndex[i].gameObject.transform.position.z;
                index = i;
            }
        }
        return TopSortingIndex[index];
    }
    private Collider2D[] GetOverlap()
    {
        return Physics2D.OverlapPointAll(TransparentWindow.GetMouseWorldPosition());
    }
    private void Start()
    {

        reorderableObjects = GetOrderableObjects();
        for (int i = 0; i < reorderableObjects.Length; i++)
        {
            reorderableObjects[i].GetComponent<Clickable>().SetOrder(i);

        }
    }
    private GameObject[] GetOrderableObjects()
    {
        MonoBehaviour[] arr = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        List<GameObject> final = new List<GameObject>();
        for (int i = 0; i < arr.Length; i++)
        {

            if (arr[i].TryGetComponent(out Clickable cRef))
            {
                if (cRef.GetOrderable())
                {
                    final.Add(arr[i].gameObject);
                }
            }
        }
        return final.ToArray();
    }
}
