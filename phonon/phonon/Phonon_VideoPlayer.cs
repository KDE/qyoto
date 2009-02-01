//Auto-generated by kalyptus. DO NOT EDIT.
namespace Phonon {
    using Phonon;
    using System;
    using Qyoto;
    /// <remarks> \class VideoPlayer videoplayer.h Phonon/VideoPlayer
    ///  \short Playback class for simple tasks.
    ///  With %VideoPlayer you can get results quickly and easily. You can do the standard
    ///  playback tasks like play, pause and stop, but also set a playback volume and
    ///  seek (there's no guarantee that the seek will work, though).
    ///  Keep in mind that when the %VideoPlayer instance is deleted the playback will
    ///  stop.
    ///  A play and forget code example:
    ///  <pre>
    ///  VideoPlayer player = new VideoPlayer(parentWidget);
    ///  connect(player, SIGNAL("finished()"), player, SLOT("deleteLater()"));
    ///  player.Play(url);
    ///  </pre>
    ///  \ingroup Playback
    ///  \ingroup PhononVideo
    ///  \author Matthias Kretz <kretz@kde.org>
    ///   See <see cref="IVideoPlayerSignals"></see> for signals emitted by VideoPlayer
    /// </remarks>        <short>   \class VideoPlayer videoplayer.</short>
    [SmokeClass("Phonon::VideoPlayer")]
    public class VideoPlayer : QWidget, IDisposable {
        protected VideoPlayer(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(VideoPlayer), this);
        }
        /// <remarks>
        ///  Constructs a new %VideoPlayer instance.
        ///  \param category The category used for the audio output device.
        ///  \param parent The QObject parent.
        ///          </remarks>        <short>    Constructs a new %VideoPlayer instance.</short>
        public VideoPlayer(Phonon.Category category, QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("VideoPlayer$#", "VideoPlayer(Phonon::Category, QWidget*)", typeof(void), typeof(Phonon.Category), category, typeof(QWidget), parent);
        }
        public VideoPlayer(Phonon.Category category) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("VideoPlayer$", "VideoPlayer(Phonon::Category)", typeof(void), typeof(Phonon.Category), category);
        }
        /// <remarks>
        ///  Constructs a new video widget with a <pre>parent</pre>
        ///  using Phonon.VideoCategory as its category.
        ///  \param parent The QObject parent.
        ///          </remarks>        <short>    Constructs a new video widget with a \p parent  using Phonon.VideoCategory as its category.</short>
        public VideoPlayer(QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("VideoPlayer#", "VideoPlayer(QWidget*)", typeof(void), typeof(QWidget), parent);
        }
        public VideoPlayer() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("VideoPlayer", "VideoPlayer()", typeof(void));
        }
        /// <remarks>
        ///  Get the total time (in milliseconds) of the file currently being played.
        ///          </remarks>        <short>    Get the total time (in milliseconds) of the file currently being played.</short>
        public long TotalTime() {
            return (long) interceptor.Invoke("totalTime", "totalTime() const", typeof(long));
        }
        /// <remarks>
        ///  Get the current time (in milliseconds) of the file currently being played.
        ///          </remarks>        <short>    Get the current time (in milliseconds) of the file currently being played.</short>
        public long CurrentTime() {
            return (long) interceptor.Invoke("currentTime", "currentTime() const", typeof(long));
        }
        /// <remarks>
        ///  This is the current volume of the output as voltage factor.
        ///  1.0 means 100%, 0.5 means 50% voltage/25% power, 0.0 means 0%
        ///          </remarks>        <short>    This is the current volume of the output as voltage factor.</short>
        public float Volume() {
            return (float) interceptor.Invoke("volume", "volume() const", typeof(float));
        }
        /// <remarks>
        ///  \returns <code>true</code> if it is currently playing
        ///  \returns <code>false</code> if it is currently stopped or paused
        ///          </remarks>        <short>    \returns <code>true</code> if it is currently playing  \returns <code>false</code> if it is currently stopped or paused          </short>
        public bool IsPlaying() {
            return (bool) interceptor.Invoke("isPlaying", "isPlaying() const", typeof(bool));
        }
        /// <remarks>
        ///  \returns <code>true</code> if it is currently paused
        ///  \returns <code>false</code> if it is currently playing or stopped
        ///          </remarks>        <short>    \returns <code>true</code> if it is currently paused  \returns <code>false</code> if it is currently playing or stopped          </short>
        public bool IsPaused() {
            return (bool) interceptor.Invoke("isPaused", "isPaused() const", typeof(bool));
        }
        /// <remarks>
        ///  getter for the MediaObject.
        ///          </remarks>        <short>    getter for the MediaObject.</short>
        public Phonon.MediaObject MediaObject() {
            return (Phonon.MediaObject) interceptor.Invoke("mediaObject", "mediaObject() const", typeof(Phonon.MediaObject));
        }
        /// <remarks>
        ///  getter for the AudioOutput.
        ///          </remarks>        <short>    getter for the AudioOutput.</short>
        public Phonon.AudioOutput AudioOutput() {
            return (Phonon.AudioOutput) interceptor.Invoke("audioOutput", "audioOutput() const", typeof(Phonon.AudioOutput));
        }
        /// <remarks>
        ///  getter for the VideoWidget.
        ///          </remarks>        <short>    getter for the VideoWidget.</short>
        public Phonon.VideoWidget VideoWidget() {
            return (Phonon.VideoWidget) interceptor.Invoke("videoWidget", "videoWidget() const", typeof(Phonon.VideoWidget));
        }
        /// <remarks>
        ///  Starts preloading the media data and fill audiobuffers in the
        ///  backend.
        ///  When there's already a media playing (or paused) it will be stopped
        ///  (the finished signal will not be emitted).
        ///          </remarks>        <short>    Starts preloading the media data and fill audiobuffers in the  backend.</short>
        [Q_SLOT("void load(Phonon::MediaSource)")]
        public void Load(Phonon.MediaSource source) {
            interceptor.Invoke("load#", "load(const Phonon::MediaSource&)", typeof(void), typeof(Phonon.MediaSource), source);
        }
        /// <remarks>
        ///  Play the media at the given URL. Starts playback as fast as possible.
        ///  This can take a considerable time depending on the URL and the
        ///  backend.
        ///  If you need low latency between calling play() and the sound actually
        ///  starting to play on your output device you need to use MediaObject
        ///  and be able to set the URL before calling play(). Note that
        ///  <pre>
        ///  audioPlayer.Load(url);
        ///  audioPlayer.Play();
        ///  </pre>
        ///  doesn't make a difference: the application should be idle between the
        ///  load and play calls so that the backend can start preloading the
        ///  media and fill audio buffers.
        ///          </remarks>        <short>    Play the media at the given URL.</short>
        [Q_SLOT("void play(Phonon::MediaSource)")]
        public void Play(Phonon.MediaSource source) {
            interceptor.Invoke("play#", "play(const Phonon::MediaSource&)", typeof(void), typeof(Phonon.MediaSource), source);
        }
        /// <remarks>
        ///  Continues playback of a paused media. Restarts playback of a stopped
        ///  media.
        ///          </remarks>        <short>    Continues playback of a paused media.</short>
        [Q_SLOT("void play()")]
        public void Play() {
            interceptor.Invoke("play", "play()", typeof(void));
        }
        /// <remarks>
        ///  Pauses the playback.
        ///          </remarks>        <short>    Pauses the playback.</short>
        [Q_SLOT("void pause()")]
        public void Pause() {
            interceptor.Invoke("pause", "pause()", typeof(void));
        }
        /// <remarks>
        ///  Stops the playback.
        ///          </remarks>        <short>    Stops the playback.</short>
        [Q_SLOT("void stop()")]
        public void Stop() {
            interceptor.Invoke("stop", "stop()", typeof(void));
        }
        /// <remarks>
        ///  Seeks to the requested time. Note that the backend is free to ignore
        ///  the seek request if the media source isn't seekable.
        ///  \param ms Time in milliseconds from the start of the media.
        ///          </remarks>        <short>    Seeks to the requested time.</short>
        [Q_SLOT("void seek(qint64)")]
        public void Seek(long ms) {
            interceptor.Invoke("seek$", "seek(qint64)", typeof(void), typeof(long), ms);
        }
        /// <remarks>
        ///  Sets the volume of the output as voltage factor.
        ///  1.0 means 100%, 0.5 means 50% voltage/25% power, 0.0 means 0%
        ///          </remarks>        <short>    Sets the volume of the output as voltage factor.</short>
        [Q_SLOT("void setVolume(float)")]
        public void SetVolume(float volume) {
            interceptor.Invoke("setVolume$", "setVolume(float)", typeof(void), typeof(float), volume);
        }
        ~VideoPlayer() {
            interceptor.Invoke("~VideoPlayer", "~VideoPlayer()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~VideoPlayer", "~VideoPlayer()", typeof(void));
        }
        public event NoArgDelegate Finished {
            add { QObject.Connect(this, SIGNAL("finished()"), value); }
            remove { QObject.Disconnect(this, SIGNAL("finished()"), value); }
        }
        protected new IVideoPlayerSignals Emit {
            get { return (IVideoPlayerSignals) Q_EMIT; }
        }
    }

    public interface IVideoPlayerSignals : IQWidgetSignals {
        /// <remarks>
        ///  This signal is emitted when the playback finished.
        ///          </remarks>        <short>    This signal is emitted when the playback finished.</short>
        [Q_SIGNAL("void finished()")]
        void Finished();
    }
}
