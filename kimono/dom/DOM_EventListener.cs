//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace DOM {

	using System;
	using Qyoto;

	/// <remarks>
	///  Introduced in DOM Level 2
	///  The EventListener interface is the primary method for handling events.
	///  Users implement the EventListener interface and register their listener on
	///  an EventTarget using the AddEventListener method. The users should also
	///  remove their EventListener from its EventTarget after they have completed
	///  using the listener.
	///  When a Node is copied using the cloneNode method the EventListeners attached
	///  to the source Node are not attached to the copied Node. If the user wishes
	///  the same EventListeners to be added to the newly created copy the user must
	///  add them manually.
	///  </remarks>		<short>    Introduced in DOM Level 2 </short>

	[SmokeClass("DOM::EventListener")]
	public class EventListener : DOM.DomShared, IDisposable {
 		protected EventListener(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(EventListener), this);
		}
		public EventListener() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("EventListener", "EventListener()", typeof(void));
		}
		/// <remarks>
		///  This method is called whenever an event occurs of the type for which the
		///  EventListener interface was registered. Parameters
		/// <param> name="evt" The Event contains contextual information about the event. It
		///  also contains the stopPropagation and preventDefault methods which are
		///  used in determining the event's flow and default action.
		/// </param>     </remarks>		<short>    This method is called whenever an event occurs of the type for which the  EventListener interface was registered.</short>
		[SmokeMethod("handleEvent(DOM::Event&)")]
		public virtual void HandleEvent(DOM.Event evt) {
			interceptor.Invoke("handleEvent#", "handleEvent(DOM::Event&)", typeof(void), typeof(DOM.Event), evt);
		}
		/// <remarks>
		///  not part of the DOM
		///  Returns a name specifying the type of listener. Useful for checking
		///  if an event is of a particular sublass.
		///      </remarks>		<short>   </short>
		[SmokeMethod("eventListenerType()")]
		public virtual string EventListenerType() {
			return (string) interceptor.Invoke("eventListenerType", "eventListenerType()", typeof(string));
		}
		~EventListener() {
			interceptor.Invoke("~EventListener", "~EventListener()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~EventListener", "~EventListener()", typeof(void));
		}
	}
	}
}