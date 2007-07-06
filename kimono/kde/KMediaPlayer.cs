//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks> KMediaPlayer contains an interface to reusable media player components.
	/// </remarks>		<short>   KMediaPlayer contains an interface to reusable media player components.</short>

	[SmokeClass("KMediaPlayer")]
	public class KMediaPlayer : Object {
		protected SmokeInvocation interceptor = null;

		/// <remarks> Player is the center of the KMediaPlayer interface.   It provides all of
		///  the necessary media player operations, and optionally provides the GUI to
		///  control them.
		///  There are two servicetypes for Player:  KMediaPlayer/Player and
		///  KMediaPlayer/Engine.  KMediaPlayer/Player provides a widget (accessable
		///  through view as well as XML GUI KActions.  KMediaPlayer/Engine omits
		///  the user interface facets, for those who wish to provide their own
		///  interface.
		///   See <see cref="IPlayerSignals"></see> for signals emitted by Player
		/// </remarks>		<short>   Player is the center of the KMediaPlayer interface.</short>

		[SmokeClass("KMediaPlayer::Player")]
		public abstract class Player : KParts.ReadOnlyPart {
	 		protected Player(Type dummy) : base((Type) null) {}
			protected new void CreateProxy() {
				interceptor = new SmokeInvocation(typeof(Player), this);
			}
			/// <remarks> This constructor is what to use when no GUI is required, as in the
			///  case of a KMediaPlayer/Engine.
			/// 	 </remarks>		<short>   This constructor is what to use when no GUI is required, as in the  case of a KMediaPlayer/Engine.</short>
			public Player(QObject parent) : this((Type) null) {
				CreateProxy();
				interceptor.Invoke("Player#", "Player(QObject*)", typeof(void), typeof(QObject), parent);
			}
			/// <remarks> This constructor is what to use when a GUI is required, as in the
			///  case of a KMediaPlayer/Player.
			/// 	 </remarks>		<short>   This constructor is what to use when a GUI is required, as in the  case of a KMediaPlayer/Player.</short>
			public Player(QWidget parentWidget, string widgetName, QObject parent) : this((Type) null) {
				CreateProxy();
				interceptor.Invoke("Player#$#", "Player(QWidget*, const char*, QObject*)", typeof(void), typeof(QWidget), parentWidget, typeof(string), widgetName, typeof(QObject), parent);
			}
			/// <remarks> A convenience function returning a pointer to the View for this
			///  Player, or 0 if this Player has no GUI.
			/// 	 </remarks>		<short>   A convenience function returning a pointer to the View for this  Player, or 0 if this Player has no GUI.</short>
			[SmokeMethod("view()")]
			public abstract KMediaPlayer.View View();
			/// <remarks> Returns whether the current track honors seek requests.</remarks>		<short>   Returns whether the current track honors seek requests.</short>
			[SmokeMethod("isSeekable() const")]
			public abstract bool IsSeekable();
			/// <remarks> Returns the current playback position in the track.</remarks>		<short>   Returns the current playback position in the track.</short>
			[SmokeMethod("position() const")]
			public abstract long Position();
			/// <remarks> Returns whether the current track has a length.  Some streams are
			///  endless, and do not have one. </remarks>		<short>   Returns whether the current track has a length.</short>
			[SmokeMethod("hasLength() const")]
			public abstract bool HasLength();
			/// <remarks> Returns the length of the current track.</remarks>		<short>   Returns the length of the current track.</short>
			[SmokeMethod("length() const")]
			public abstract long Length();
			/// <remarks> Pause playback of the media track.</remarks>		<short>   Pause playback of the media track.</short>
			[SmokeMethod("pause()")]
			public abstract void Pause();
			/// <remarks> Begin playing the media track.</remarks>		<short>   Begin playing the media track.</short>
			[SmokeMethod("play()")]
			public abstract void Play();
			/// <remarks> Stop playback of the media track and return to the beginning.</remarks>		<short>   Stop playback of the media track and return to the beginning.</short>
			[SmokeMethod("stop()")]
			public abstract void Stop();
			/// <remarks> Move the current playback position to the specified time in
			///  milliseconds, if the track is seekable.  Some streams may not be
			///  seeked.
			/// 	 </remarks>		<short>   Move the current playback position to the specified time in  milliseconds, if the track is seekable.</short>
			[SmokeMethod("seek(qlonglong)")]
			public abstract void Seek(long msec);
			/// <remarks> Set whether the Player should continue playing at the beginning of
			///  the track when the end of the track is reached.
			/// 	 </remarks>		<short>   Set whether the Player should continue playing at the beginning of  the track when the end of the track is reached.</short>
			[Q_SLOT("void setLooping(bool)")]
			public void SetLooping(bool arg1) {
				interceptor.Invoke("setLooping$", "setLooping(bool)", typeof(void), typeof(bool), arg1);
			}
			/// <remarks> Implementers use this to control what users see as the current
			///  state.</remarks>		<short>   Implementers use this to control what users see as the current  state.</short>
			[Q_SLOT("void setState(int)")]
			protected void SetState(int arg1) {
				interceptor.Invoke("setState$", "setState(int)", typeof(void), typeof(int), arg1);
			}
			protected new IPlayerSignals Emit {
				get { return (IPlayerSignals) Q_EMIT; }
			}
		}

		public interface IPlayerSignals : KParts.IReadOnlyPartSignals {
		/// <remarks> Emitted when the looping state is changed. </remarks>		<short>   Emitted when the looping state is changed.</short>
		[Q_SIGNAL("void loopingChanged(bool)")]
		void LoopingChanged(bool arg1);
		/// <remarks> Emitted when the state changes. </remarks>		<short>   Emitted when the state changes.</short>
		[Q_SIGNAL("void stateChanged(int)")]
		void StateChanged(int arg1);
		}

		/// <remarks> View is part of the user interface of a Player.  See <see cref="IViewSignals"></see> for signals emitted by View
		/// </remarks>		<short>   View is part of the user interface of a Player.</short>

		[SmokeClass("KMediaPlayer::View")]
		public class View : QWidget, IDisposable {
	 		protected View(Type dummy) : base((Type) null) {}
			protected new void CreateProxy() {
				interceptor = new SmokeInvocation(typeof(View), this);
			}
			/// <remarks> Your typical QWidget constructor. </remarks>		<short>   Your typical QWidget constructor.</short>
			public View(QWidget parent) : this((Type) null) {
				CreateProxy();
				interceptor.Invoke("View#", "View(QWidget*)", typeof(void), typeof(QWidget), parent);
			}
			/// <remarks> Return which buttons are being displayed. </remarks>		<short>   Return which buttons are being displayed.</short>
			public int Buttons() {
				return (int) interceptor.Invoke("buttons", "buttons()", typeof(int));
			}
			/// <remarks> Return the QWidget in which video is displayed.
			/// 		May Return null if there is none. </remarks>		<short>   Return the QWidget in which video is displayed.</short>
			public QWidget VideoWidget() {
				return (QWidget) interceptor.Invoke("videoWidget", "videoWidget()", typeof(QWidget));
			}
			/// <remarks> Set which buttons to display. See Button. </remarks>		<short>   Set which buttons to display.</short>
			[Q_SLOT("void setButtons(int)")]
			public void SetButtons(int arg1) {
				interceptor.Invoke("setButtons$", "setButtons(int)", typeof(void), typeof(int), arg1);
			}
			/// <remarks> Returns if a particular button is being displayed. </remarks>		<short>   Returns if a particular button is being displayed.</short>
			[Q_SLOT("bool button(int)")]
			public bool button(int arg1) {
				return (bool) interceptor.Invoke("button$", "button(int)", typeof(bool), typeof(int), arg1);
			}
			/// <remarks> Display a particular button. </remarks>		<short>   Display a particular button.</short>
			[Q_SLOT("void showButton(int)")]
			public void ShowButton(int arg1) {
				interceptor.Invoke("showButton$", "showButton(int)", typeof(void), typeof(int), arg1);
			}
			/// <remarks> Stop displaying a particular button. </remarks>		<short>   Stop displaying a particular button.</short>
			[Q_SLOT("void hideButton(int)")]
			public void HideButton(int arg1) {
				interceptor.Invoke("hideButton$", "hideButton(int)", typeof(void), typeof(int), arg1);
			}
			/// <remarks> Toggle the display of a particular button. </remarks>		<short>   Toggle the display of a particular button.</short>
			[Q_SLOT("void toggleButton(int)")]
			public void ToggleButton(int arg1) {
				interceptor.Invoke("toggleButton$", "toggleButton(int)", typeof(void), typeof(int), arg1);
			}
			/// <remarks> The implementing view should set the widget in which
			/// 		the video will be displayed. KMediaPlayer users may
			/// 		reparent() it to somewhere else, for example.
			/// 	</remarks>		<short>   The implementing view should set the widget in which 		the video will be displayed.</short>
			protected void SetVideoWidget(QWidget videoWidget) {
				interceptor.Invoke("setVideoWidget#", "setVideoWidget(QWidget*)", typeof(void), typeof(QWidget), videoWidget);
			}
			~View() {
				interceptor.Invoke("~View", "~View()", typeof(void));
			}
			public new void Dispose() {
				interceptor.Invoke("~View", "~View()", typeof(void));
			}
			protected new IViewSignals Emit {
				get { return (IViewSignals) Q_EMIT; }
			}
		}

		public interface IViewSignals : IQWidgetSignals {
		/// <remarks> Emitted when the set of displayed buttons changes. </remarks>		<short>   Emitted when the set of displayed buttons changes.</short>
		[Q_SIGNAL("void buttonsChanged(int)")]
		void ButtonsChanged(int arg1);
		}
	}
}
