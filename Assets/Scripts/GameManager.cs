using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private bool _isGamePaused;

    private GameObject _transitionAnimExit;
    private GameObject _transitionAnimOn;


    void Awake()
    {
        _transitionAnimExit = GameObject.Find("Transition Scene Exit");
        {
            if (_transitionAnimExit != null)
            {
                _transitionAnimExit.SetActive(false);
            }
        }
        _transitionAnimOn = GameObject.Find("Transition Scene On");
        {
            if (_transitionAnimOn != null)
            {
                _transitionAnimOn.SetActive(true);
            }
        }


        _isGamePaused = false;
        Time.timeScale = 1;
    }



    void Update()
    {
        IsGamePaused();
    }

    public void TryAgain()
    {
        StartCoroutine(TryAgainTransitionRoutine());
    }


    public void LoadMainMenu()
    {
        StartCoroutine(MenuTransitionExitRoutine());
    }


    public void NextLevel()
    {
        StartCoroutine(NextLevelTransitionRoutine());
    }

    public void NewGame()
    {
        StartCoroutine(NewGameTransitionExitRoutine());
    }

    public void IsGamePaused()
    {
        if (Time.timeScale == 0)
        {
            _isGamePaused = true;
        }
    }

    IEnumerator TryAgainTransitionRoutine()
    {
        _transitionAnimExit.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    IEnumerator NewGameTransitionExitRoutine()
    {
        _transitionAnimExit.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }

    IEnumerator MenuTransitionExitRoutine()
    {
        _transitionAnimExit.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(0);
    }

    IEnumerator NextLevelTransitionRoutine()
    {
        _transitionAnimExit.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);

        if (SceneManager.GetActiveScene().buildIndex < 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(1);
        }
    }

    #region levels

    public void levelOne()
    {
        StartCoroutine(LevelOneRoutine());
    }

    public void levelTwo()
    {
        StartCoroutine(LevelTwoRoutine());
    }

    public void levelThree()
    {
        StartCoroutine(LevelThreeRoutine());
    }

    public void levelFour()
    {
        StartCoroutine(LevelFourRoutine());
    }

    public void levelFive()
    {
        StartCoroutine(LevelFiveRoutine());
    }

    public void levelSix()
    {
        StartCoroutine(LevelSixRoutine());
    }





    IEnumerator LevelOneRoutine()
    {
        _transitionAnimExit.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }

    IEnumerator LevelTwoRoutine()
    {
        _transitionAnimExit.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
    }

    IEnumerator LevelThreeRoutine()
    {
        _transitionAnimExit.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(3);
    }

    IEnumerator LevelFourRoutine()
    {
        _transitionAnimExit.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(4);
    }

    IEnumerator LevelFiveRoutine()
    {
        _transitionAnimExit.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(5);
    }

    IEnumerator LevelSixRoutine()
    {
        _transitionAnimExit.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(6);
    }
    #endregion

}


