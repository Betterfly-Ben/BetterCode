using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Betterfly.BetterCode {
	public class VideoController : MonoBehaviour {
		[SerializeField] private VideoPlayer _videoPlayer;
		[SerializeField] private GameObject _videoPlayImage;

		public void SetVideoClip(VideoClip clip)
		{
			_videoPlayer.clip = clip;
		}

		public void PlayVideo()
		{
			_videoPlayer.Play();
			if (_videoPlayImage != null)
			{
				_videoPlayImage.SetActive(false);
			}
		}

		public void PauseVideo()
		{
			_videoPlayer.Pause();
			if (_videoPlayImage != null)
			{
				_videoPlayImage.SetActive(true);
			}
		}

		public void ReplayVideo()
		{
			_videoPlayer?.Stop();
			PlayVideo();
		}

		public void ReplayVideo(VideoClip clip)
		{
			SetVideoClip(clip);
			ReplayVideo();
		}

		public void PlayOrPauseVideo()
		{
			if (_videoPlayer.isPlaying)
			{
				PauseVideo();
			}
			else
			{
				PlayVideo();
			}
		}
	}
}