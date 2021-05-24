using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationMove : MonoBehaviour
{

    ConstelationController constelationController;

    private void Start()
    {
        constelationController = GetComponent<ConstelationController>();
        constelationController.onSelected += OnSelectedTrigger;
        constelationController.onComplete += OnCompleteTrigger;
    }

    public void OnSelectedTrigger()
    {
        StopAllCoroutines();
        StartCoroutine(MoveTowardsPlayer());
    }
    public void OnCompleteTrigger()
    {
        StopAllCoroutines();
        StartCoroutine(BackToSky());
    }

    IEnumerator BackToSky()
    {
        transform.SetParent(constelationController.persistantPosition.parent.transform);
        for (; ; )
        {
            transform.position = Vector3.Lerp(transform.position, constelationController.persistantPosition.position, Time.deltaTime * .5f);
            transform.localScale = Vector3.Lerp(transform.localScale, constelationController.persistantPosition.localScale, Time.deltaTime * .51f);
            transform.rotation = Quaternion.Lerp(transform.rotation, constelationController.persistantPosition.rotation, Time.deltaTime * .5f);
            if ((transform.position - constelationController.persistantPosition.position).magnitude < 1.5f)
            {
                transform.position = constelationController.persistantPosition.position;
                transform.localScale = constelationController.persistantPosition.localScale;
                transform.rotation = constelationController.persistantPosition.rotation;
                break;
            }
            //constelationController.onSkyPosition?.Invoke();

            yield return null;
        }

        ConstelationEvents.Instance.onSkyPosition?.Invoke();
    }

    IEnumerator MoveTowardsPlayer()
    {
        ConstelationEvents.Instance.onSelected?.Invoke();
        /*        constelationController.persistantPosition.transform.position = transform.position;
                constelationController.persistantPosition.transform.localScale = transform.localScale;
                constelationController.persistantPosition.transform.rotation = transform.rotation;*/
        Vector3 finded = new Vector3(0f, 1.25f, 2.5f);
        transform.SetParent(null);

        for (; ; )
        {
            transform.position = Vector3.Lerp(transform.position, finded, Time.deltaTime * .5f);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * .51f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * .5f);
            if ((transform.position - finded).magnitude < 0.25f)
            {
                transform.position = finded;
                transform.localScale = Vector3.one;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            }
            yield return null;
        }
        constelationController.onReady?.Invoke();
        yield return null;
    }

    public void OnSelectedPerform() => constelationController.onSelected?.Invoke();
}
