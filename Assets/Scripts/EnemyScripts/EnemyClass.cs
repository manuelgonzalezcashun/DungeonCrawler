using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    #region Goblin Mumble
    IEnumerator GoblinMumble()
    {
        int i = Random.Range(0, 101);
        int randomIndex = Random.Range(3, FindObjectOfType<SoundManager>().sounds.Length);
        if (i % 5 == 0)
        {
            FindObjectOfType<SoundManager>().Play(FindObjectOfType<SoundManager>().sounds[randomIndex].name);
        }
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(GoblinMumble());
    }
    #endregion
}
