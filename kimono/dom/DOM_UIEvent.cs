//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace DOM {

	using System;
	using Qyoto;

	/// <remarks>
	///  Introduced in DOM Level 2
	///  The UIEvent interface provides specific contextual information associated
	///  with User Interface events.
	///  </remarks>		<short>    Introduced in DOM Level 2 </short>

	[SmokeClass("DOM::UIEvent")]
	public class UIEvent : DOM.Event, IDisposable {
 		protected UIEvent(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(UIEvent), this);
		}
		// DOM::UIEvent* UIEvent(DOM::UIEventImpl* arg1); >>>> NOT CONVERTED
		public UIEvent() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("UIEvent", "UIEvent()", typeof(void));
		}
		public UIEvent(DOM.UIEvent other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("UIEvent#", "UIEvent(const DOM::UIEvent&)", typeof(void), typeof(DOM.UIEvent), other);
		}
		public UIEvent(DOM.Event other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("UIEvent#", "UIEvent(const DOM::Event&)", typeof(void), typeof(DOM.Event), other);
		}
		/// <remarks>
		///  The view attribute identifies the AbstractView from which the event was
		///  generated.
		///      </remarks>		<short>    The view attribute identifies the AbstractView from which the event was  generated.</short>
		public DOM.AbstractView View() {
			return (DOM.AbstractView) interceptor.Invoke("view", "view() const", typeof(DOM.AbstractView));
		}
		/// <remarks>
		///  Specifies some detail information about the Event, depending on the type
		///  of event.
		///      </remarks>		<short>    Specifies some detail information about the Event, depending on the type  of event.</short>
		public long Detail() {
			return (long) interceptor.Invoke("detail", "detail() const", typeof(long));
		}
		/// <remarks>
		///  Non-standard extension to support IE-style keyCode event property.
		///      </remarks>		<short>    Non-standard extension to support IE-style keyCode event property.</short>
		public int KeyCode() {
			return (int) interceptor.Invoke("keyCode", "keyCode() const", typeof(int));
		}
		/// <remarks>
		///  Non-standard extension to support IE-style charCode event property.
		///      </remarks>		<short>    Non-standard extension to support IE-style charCode event property.</short>
		public int CharCode() {
			return (int) interceptor.Invoke("charCode", "charCode() const", typeof(int));
		}
		/// <remarks>
		///  Non-standard extensions to support Netscape-style pageX and pageY event properties.
		///      </remarks>		<short>    Non-standard extensions to support Netscape-style pageX and pageY event properties.</short>
		public int PageX() {
			return (int) interceptor.Invoke("pageX", "pageX() const", typeof(int));
		}
		public int PageY() {
			return (int) interceptor.Invoke("pageY", "pageY() const", typeof(int));
		}
		/// <remarks>
		///  Non-standard extensions to support Netscape-style layerX and layerY event properties.
		///      </remarks>		<short>    Non-standard extensions to support Netscape-style layerX and layerY event properties.</short>
		public int LayerX() {
			return (int) interceptor.Invoke("layerX", "layerX() const", typeof(int));
		}
		public int LayerY() {
			return (int) interceptor.Invoke("layerY", "layerY() const", typeof(int));
		}
		/// <remarks>
		///  Non-standard extension to support Netscape-style "which" event property.
		///      </remarks>		<short>    Non-standard extension to support Netscape-style "which" event property.</short>
		public int Which() {
			return (int) interceptor.Invoke("which", "which() const", typeof(int));
		}
		/// <remarks>
		///  The initUIEvent method is used to initialize the value of a UIEvent
		///  created through the DocumentEvent interface. This method may only be
		///  called before the UIEvent has been dispatched via the dispatchEvent
		///  method, though it may be called multiple times during that phase if
		///  necessary. If called multiple times, the final invocation takes
		///  precedence.
		/// <param> name="typeArg" Specifies the event type.
		/// </param><param> name="canBubbleArg" Specifies whether or not the event can bubble.
		/// </param><param> name="cancelableArg" Specifies whether or not the event's default action
		///  can be prevented.
		/// </param><param> name="viewArg" Specifies the Event's AbstractView.
		/// </param><param> name="detailArg" Specifies the Event's detail.
		/// </param>     </remarks>		<short>    The initUIEvent method is used to initialize the value of a UIEvent  created through the DocumentEvent interface.</short>
		public void InitUIEvent(string typeArg, bool canBubbleArg, bool cancelableArg, DOM.AbstractView viewArg, long detailArg) {
			interceptor.Invoke("initUIEvent#$$#$", "initUIEvent(const DOM::DOMString&, bool, bool, const DOM::AbstractView&, long)", typeof(void), typeof(string), typeArg, typeof(bool), canBubbleArg, typeof(bool), cancelableArg, typeof(DOM.AbstractView), viewArg, typeof(long), detailArg);
		}
		~UIEvent() {
			interceptor.Invoke("~UIEvent", "~UIEvent()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~UIEvent", "~UIEvent()", typeof(void));
		}
	}
	}
}
