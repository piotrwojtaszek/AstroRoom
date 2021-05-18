using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ConstelationSkyTOPlayer : MonoBehaviour
{

    public UnityAction onSelected;

    IEnumerator BackToPlayer()
    {
        GetComponent<Collider>().enabled = false;
        GameObject temporary = new GameObject("Origin of constelation");
        temporary.transform.position = transform.position;
        Vector3 finded = new Vector3(0f, 1f, 2.5f);

        for (; ; )
        {
            transform.parent.position = Vector3.Lerp(transform.parent.position, finded, Time.deltaTime * .5f);
            transform.parent.localScale = Vector3.Lerp(transform.parent.localScale, Vector3.one, Time.deltaTime * .51f);
            transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * .5f);
            if ((transform.parent.position - finded).magnitude < 0.01f)
            {
                break;
            }
            yield return null;
        }
        yield return null;
    }

    public void Selected()
    {
        StartCoroutine(BackToPlayer());
        onSelected?.Invoke();
    }
}