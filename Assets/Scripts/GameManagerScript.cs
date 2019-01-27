using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject startPosition;
    [SerializeField] GameObject finishPosition;
    [SerializeField] Transform player;
    [SerializeField] GameObject loseScreen;

    enum Scene
    {
        NORMAL,
        HELL
    };

    public AnimationCurve FadeAnimationCurve;
    public float FadeDuration;
    public SpriteRenderer NormalScene;
    public SpriteRenderer HellScene;

    // Start is called before the first frame update
    void Start()
    {
        activateMusicScene();
        startPosition = GameObject.FindGameObjectWithTag("StartPosition");
        finishPosition = GameObject.FindGameObjectWithTag("FinishPosition");
        player.position = startPosition.transform.position;
    }


    float a = 0.0f;
    bool b = true;
    // Update is called once per frame
    void Update()
    {
        if(finishPosition != null && finishPosition.GetComponent<FinishScript>().collideWithPlayer)
        {
            spawnPlayer();
            finishPosition.GetComponent<FinishScript>().inverseCollision();
        }

        a+=Time.deltaTime;
        if (a > 5.0f)
        {
            a = 0.0f;
            b = !b;
            if (b)
                StartCoroutine(FadeToScene(Scene.NORMAL));
            else
                StartCoroutine(FadeToScene(Scene.HELL));
        }

    }

    public void spawnPlayer()
    {
        player.position = startPosition.transform.position;
    }

    public void defeat()
    {
        loseScreen.SetActive(true);
    }

    public void replay()
    {
        loseScreen.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void activateMusicScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Menu": AkSoundEngine.PostEvent("Play_MusicIntroHouse", gameObject); break;
            case "Niveau1": AkSoundEngine.PostEvent("Play_Music1", gameObject); break;
            case "Lvl2": AkSoundEngine.PostEvent("Play_Music2", gameObject); break;
            //case "Desk": AkSoundEngine.PostEvent("Play_MusicIntroHouse", gameObject); break;
            case "Ending": AkSoundEngine.PostEvent("Play_MusicIntroHouse", gameObject); break;
        }
    }

    public void desactivateMusicScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Menu": AkSoundEngine.PostEvent("Stop_MusicIntroHouse", gameObject); break;
            case "Niveau1": AkSoundEngine.PostEvent("Stop_Music1", gameObject); break;
            case "Lvl2": AkSoundEngine.PostEvent("Stop_Music2", gameObject); break;
            //case "Desk": AkSoundEngine.PostEvent("Stop_MusicIntroHouse", gameObject); break;
            case "Ending": AkSoundEngine.PostEvent("Stop_MusicIntroHouse", gameObject); break;
        }
    }

    IEnumerator FadeToScene(GameManagerScript.Scene scene)
    {
        Debug.Log("FadeToScene: " + scene.ToString());
        yield return null;
        float u = 1.0f;
        if (scene == Scene.HELL)
        {
            HellScene.sortingOrder = 0;
            HellScene.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            NormalScene.sortingOrder = 20;
            NormalScene.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

            while (u > 0.0f)
            {
                u = Mathf.Clamp(u - Time.deltaTime * (1.0f / FadeDuration), 0.0f, 1.0f);
                float alphaValue = FadeAnimationCurve.Evaluate(u);
                NormalScene.color = new Color(1.0f, 1.0f, 1.0f, alphaValue);
                yield return new WaitForEndOfFrame();
            }
        }
        else if (scene == Scene.NORMAL)
        {
            NormalScene.sortingOrder = 20;
            NormalScene.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            HellScene.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            HellScene.sortingOrder = 21;
            while (u > 0.0f)
            {
                u = Mathf.Clamp(u - Time.deltaTime * (1.0f / FadeDuration), 0.0f, 1.0f);
                float alphaValue = FadeAnimationCurve.Evaluate(u);
                HellScene.color = new Color(1.0f, 1.0f, 1.0f, alphaValue);
                yield return new WaitForEndOfFrame();
            }
        }
        
    }

}
