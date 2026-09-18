using System.Collections.Generic;
using UnityEngine;

namespace SourceFiles.Scripts
{
   public class AudioManager : MonoBehaviour
   {

      #region  private Fields

      private List<AudioSource> systemSourceChannels;
      private List<AudioSource> activeSouce;

      #endregion
      
      #region Singleton
      public static AudioManager Instance;
      
      
      private void Awake()
      {
         if (Instance == null)
         {
            Instance = this;
            DontDestroyOnLoad(gameObject);
         
         }
         else
         {
            Destroy(gameObject);
         }
      }
      #endregion
      
      #region  Play 2D Sounds

      public void PlayMusic(AudioClip clip)
      {
         if (systemSourceChannels.Count == 0)
         {
            systemSourceChannels.Add(gameObject.AddComponent<AudioSource>());
         }

         systemSourceChannels[0].Stop();
         systemSourceChannels[0].clip = clip;
         systemSourceChannels[0].Play();
      }

      public void StopMusic()
      {
         if (systemSourceChannels.Count >= 2)
         {
            systemSourceChannels[1].Stop();
         }
      }

      public void PauseMusic(AudioClip clip)
      {
         if (systemSourceChannels.Count >= 2)
         {
            systemSourceChannels[1].Pause();
         }
      }
      
      public void ResumeMusic(AudioClip clip)
      {
         if (systemSourceChannels.Count >= 2)
         {
            systemSourceChannels[1].UnPause();
         }
      }

      #endregion
      
   }
   
   
}
