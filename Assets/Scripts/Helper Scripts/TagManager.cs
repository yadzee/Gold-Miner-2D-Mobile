using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : MonoBehaviour
{
    private float score;
    [SerializeField] private float _maxScore;
    [SerializeField] private float _minScore;
    [SerializeField] private Claws _claws;
    [SerializeField] private AudioManager _audioManager;
     private UIManager _uIManager;

    private void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public string TagUpdate(string TagGameObject)
    {

        switch (TagGameObject)
        {
            case "Gold Shard":

                score += 10;
                ScoreUpdate();
                _audioManager.PlayAudio(2);
                break;

            case "Gold Chunk":

                score += 15;
                ScoreUpdate();
                _audioManager.PlayAudio(2);
                break;

            case "Gold Slab":

                score += 20;
                ScoreUpdate();
                _audioManager.PlayAudio(2);
                break;

            case "Small Rock":

                score -= 15;
                ScoreUpdate();
                _audioManager.PlayAudio(3);
                break;

            case "Large Rock":

                score -= 30;
                ScoreUpdate();
                _audioManager.PlayAudio(3);
                break;

            case "Emerald":

                score += 25;
                ScoreUpdate();
                _audioManager.PlayAudio(2);
                break;

            case "Diamond":

                score += 30;
                ScoreUpdate();
                _audioManager.PlayAudio(2);
                break;

            case "Barrel":

                score += 0;
                ScoreUpdate();
                _audioManager.PlayAudio(3);
                break;

            case "Bone":

                score += 100;
                ScoreUpdate();
                _audioManager.PlayAudio(2);
                break;

            case "Bag":

                score += 1;
                ScoreUpdate();
                _audioManager.PlayAudio(2);
                // тут можно придумать рандомную реализацию, вплоть до потери всех денег
                break;

        }

        return TagGameObject;

    }

    void ScoreUpdate()
    {
        if (score >= _maxScore)
        {
            score = _maxScore;
            _uIManager._popUp = true;
            _uIManager._isGamePaused = true;
            _uIManager.congratsText.SetActive(true);
            _audioManager.PlayGameEndAudio();
            Time.timeScale = 0;
        }

        else if (score < _minScore)
        {
            score = _minScore;
        }

        _uIManager.scoreBar.fillAmount = score / _maxScore;

    }


}
