using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public List<Sound> sounds;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;
        else {
            Destroy(gameObject);

            return;
        }

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
            sound.source.spatialBlend = sound.spatialBlend;
        }
    }

    void Start() {
        PlayStageTheme();
    }
    
    private void PlayStageTheme() {

        switch (SceneManager.GetActiveScene().name)
        {
            case "FirstStage": Play("FirstStageMusic");
            break;
            case "SecondStage": Play("SecondStageMusic");
            break;
            case "ThirdStage": Play("ThirdStageMusic");
            break;
            default: return;
        }
    }

    public void Play(string name) {

       Sound currSound = sounds.Find(sound => sound.name == name);

       if (currSound == null) {

           Debug.LogWarning($"The {name} sound was not found!");
       } else currSound.source.Play();
    }

    public void Stop(string name) {

       Sound currSound = sounds.Find(sound => sound.name == name);

       if (currSound == null) {

           Debug.LogWarning($"The {name} sound was not found!");
       } else currSound.source.Stop();
    }

    [System.Serializable]
    public class Sound {

        public AudioClip clip;

        [HideInInspector]
        public AudioSource source;
        public string name;

        [Range(0f, 1f)]
        public float volume;

        [Range(0f, 1f)]
        public float spatialBlend;
        public bool loop;
    }  
}
