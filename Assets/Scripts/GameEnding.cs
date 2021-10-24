using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

public class GameEnding : MonoBehaviour
{
    
    public float fadeDuration = 1f;
    private bool isPlayerAtExit,isPlayerCaught;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    
    public float displayImageDuration = 1f;
    
    private float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==player)
        {
            isPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if (isPlayerAtExit)
        {
           EndLevel(exitBackgroundImageCanvasGroup,false);// no restart
        }else if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup,true);
        }
        
    }

    /// <summary>
    /// Lanza la imagen de fin de la partida
    /// </summary>
    /// <param name="imageCanvasGroup"> Imagen de fin de la partida correspondiente </param>
    void EndLevel(CanvasGroup imageCanvasGroup,bool doRestart)
    {
        timer += Time.deltaTime;
        //exitBackGroupImageCanvasGroup.alpha = timer / fadeDuration;
        //lo mismo 
        imageCanvasGroup.alpha = Mathf.Clamp(timer / fadeDuration,0,1);
           
        if (timer>fadeDuration+displayImageDuration)
        {
            if (doRestart)
            {
                //SceneManager.LoadScene("MainScene");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);// reset current scene
            }
            else
                {
                    Application.Quit();    
                }
            }
           
        }

    public void CatchPlayer()
    {
        isPlayerCaught = true;
    }
    }

