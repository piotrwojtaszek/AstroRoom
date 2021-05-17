using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationSkyTOPlayer : MonoBehaviour
{
    IEnumerator BackToPlayer()
    {
        Vector3 finded = new Vector3(0f, 1f, 2.5f);

        for (; ; )
        {
            transform.parent.position = Vector3.Lerp(transform.parent.position, finded, Time.deltaTime * .5f);
            transform.parent.localScale = Vector3.Lerp(transform.parent.localScale, Vector3.one, Time.deltaTime * .7f);
            transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * .7f);
            if ((transform.parent.position - finded).magnitude < 0.01f)
            {
                break;
            }
            yield return null;
        }

        Destroy(gameObject);

        yield return null;
    }

    public void Selected()
    {
        StartCoroutine(BackToPlayer());
    }
}
