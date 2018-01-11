using Octane.Xamarin.Forms.VideoPlayer;
using Octane.Xamarin.Forms.VideoPlayer.Constants;
using Xamarin.Forms;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;
using Plugin.MediaManager.Abstractions.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms.Xaml;

namespace DropsApp
{
    public partial class DropsAppPage : ContentPage
    {
        public VideoPlayer player;
        public VideoSource source;
        
        
        public DropsAppPage()
        {
            InitializeComponent();
            source = "http://vjs.zencdn.net/v/oceans.mp4";
            player = new VideoPlayer
            {
                AutoPlay = true,
                Source = source
            };

            

            player.PlayerStateChanged += Player_PlayerStateChanged;
            player.TimeElapsed += Player_TimeElapsed;
            mainLayout.Children.Add(player);
        }

        private void Player_TimeElapsed(object sender, Octane.Xamarin.Forms.VideoPlayer.Events.VideoPlayerEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void Player_PlayerStateChanged(object sender, Octane.Xamarin.Forms.VideoPlayer.Events.VideoPlayerStateChangedEventArgs e)
        {
            //if (e == null)
            //{
            //    throw new System.ArgumentNullException(nameof(e));
            //}
            switch (e.CurrentState)
            {
                case PlayerState.Paused:
                             mainProgressBar.AbortAnimation("SetProgress");                    
                     break;
 
                case PlayerState.Prepared:
                case PlayerState.Completed:
                case PlayerState.Initialized:
                    break;
                default:
                    break;
            }
        }

        private void btnWebVideo_Clicked(object sender, System.EventArgs e)
        {
            PlayVideoWithGivenSource("http://vjs.zencdn.net/v/oceans.mp4");
        }

        private void btnLocalVideo_Clicked(object sender, System.EventArgs e)
        {
            
            PlayVideoWithGivenSource("samplevideo1.mp4");
        }

        private void PlayVideoWithGivenSource(VideoSource tempSource)
        {
            mainProgressBar.Progress = 0;
            source = tempSource;
            player.Source = source;
            player.Play();
            
            mainProgressBar.ProgressTo(1, 5000, Easing.Linear);
        }

        //private async void btnCrossMediaPlay_Clicked(object sender, EventArgs e)
        //{
        //    var mediaFile = new MediaFile
        //    {
        //        Type = MediaFileType.Video,
        //        Url = "http://vjs.zencdn.net/v/oceans.mp4",
        //        Availability = ResourceAvailability.Remote
        //    };
        //    await CrossMediaManager.Current.Play(mediaFile);
        //    var fileDuration = mediaFile.Metadata.Duration;
        //}
    }
}
