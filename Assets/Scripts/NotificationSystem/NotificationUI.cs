using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;


public class NotificationUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private Image _image;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private int _notificationLifeTime = 3;
    [SerializeField] private float _notificationFadeDuration = .5f;

    private IObjectPool<NotificationUI> _pool;

    private Coroutine _fadeInRoutine;
    private Coroutine _fadeOutRoutine;
    private Coroutine _lifeRoutine;

    public void ResetUI()
    {
        _canvasGroup.alpha = 0;
    }

    public void Setup(NotificationData data)
    {
        ResetUI();
        // Set UI Data
        _titleText.text = data.title;
        _descriptionText.text = data.description;
        _image.sprite = data.sprite;
        _titleText.color = data.color;

        // Coroutines
        _fadeInRoutine = StartCoroutine(FadeIn());
        _fadeOutRoutine = StartCoroutine(FadeOut());
        _lifeRoutine = StartCoroutine(WaitAndRelease());
    }

    private IEnumerator FadeIn()
    {
        float time = 0f;
        while(time < _notificationFadeDuration)
        {
            time += Time.deltaTime;
            _canvasGroup.alpha = Mathf.Lerp(0f, 1f, time / _notificationFadeDuration);

            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(_notificationLifeTime - _notificationFadeDuration);
        float time = 0f;
        while (time < _notificationFadeDuration)
        {
            time += Time.deltaTime;
            _canvasGroup.alpha = Mathf.Lerp(1f, 0f, time / _notificationFadeDuration);

            yield return null;
        }
    }

    private IEnumerator WaitAndRelease()
    {
        yield return new WaitForSeconds(_notificationLifeTime);

        _pool.Release(this);
    }

    public void SetPool(IObjectPool<NotificationUI> pool)
    {
        _pool = pool;
    }

}
