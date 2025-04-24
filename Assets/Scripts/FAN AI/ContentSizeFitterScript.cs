using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentSizeFitterScript : MonoBehaviour
{
    void Start()
    {
        if (GetComponent<ContentSizeFitter>())
        {
            Refresh();
        }
    }

    private void OnEnable()
    {
        if (GetComponent<ContentSizeFitter>())
        {
            Refresh();
        }
    }

    public void Refresh()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(IERefresh());
        }
    }

    public IEnumerator IERefresh()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
        //if (GetComponent<ContentSizeFitter>())
        {
            //sizeFitter.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            yield return new WaitForSeconds(.01f);
            //sizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
        Refresh();
    }

}
