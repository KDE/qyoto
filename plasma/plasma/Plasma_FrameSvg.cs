//Auto-generated by kalyptus. DO NOT EDIT.
namespace Plasma {
    using Plasma;
    using System;
    using Kimono;
    using Qyoto;
    /// <remarks>
    ///  @class FrameSvg plasma/framesvg.h <Plasma/FrameSvg>
    ///  When using SVG images for a background of an object that may change
    ///  its aspect ratio, such as a dialog, simply scaling a single image
    ///  may not be enough.
    ///  FrameSvg allows SVGs to provide several elements for borders as well
    ///  as a central element, each of which are scaled individually.  These
    ///  elements should be named
    ///   - <code>center</code>  - the central element, which will be scaled in both directions
    ///   - <code>top</code>     - the top border; the height is fixed, but it will be scaled
    ///                  horizontally to the same width as <code>center</code>
    ///   - <code>bottom</code>  - the bottom border; scaled in the same way as <code>top</code>
    ///   - <code>left</code>    - the left border; the width is fixed, but it will be scaled
    ///                  vertically to the same height as <code>center</code>
    ///   - <code>right</code>   - the right border; scaled in the same way as <code>left</code>
    ///   - <code>topleft</code> - fixed size; must be the same height as <code>top</code> and the same
    ///                  width as <code>left</code>
    ///   - <code>bottomleft</code>, <code>topright</code>, <code>bottomright</code> - similar to <code>topleft</code>
    ///  <code>center</code> must exist, but all the others are optional.  <code>topleft</code> and
    ///  <code>topright</code> will be ignored if <code>top</code> does not exist, and similarly for
    ///  <code>bottomleft</code> and <code>bottomright.</code>
    /// </remarks>        <short> Provides an SVG with borders. </short>
    ///         <see> Plamsa.Svg</see>
    [SmokeClass("Plasma::FrameSvg")]
    public class FrameSvg : Plasma.Svg, IDisposable {
        protected FrameSvg(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(FrameSvg), this);
        }
        /// <remarks>
        ///  These flags represents what borders should be drawn
        ///          </remarks>        <short>    These flags represents what borders should be drawn          </short>
        public enum EnabledBorder {
            NoBorder = 0,
            TopBorder = 1,
            BottomBorder = 2,
            LeftBorder = 4,
            RightBorder = 8,
            AllBorders = TopBorder|BottomBorder|LeftBorder|RightBorder,
        }
        /// <remarks>
        ///  Constructs a new FrameSvg that paints the proper named subelements
        ///  as borders. It may also be used as a regular Plasma.Svg object
        ///  for direct access to elements in the Svg.
        ///  @arg parent options QObject to parent this to
        ///  @related Plasma.Theme
        ///          </remarks>        <short>    Constructs a new FrameSvg that paints the proper named subelements  as borders.</short>
        public FrameSvg(QObject parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("FrameSvg#", "FrameSvg(QObject*)", typeof(void), typeof(QObject), parent);
        }
        public FrameSvg() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("FrameSvg", "FrameSvg()", typeof(void));
        }
        /// <remarks>
        ///  Loads a new Svg
        ///  @arg imagePath the new file
        ///          </remarks>        <short>    Loads a new Svg  @arg imagePath the new file          </short>
        public void SetImagePath(string path) {
            interceptor.Invoke("setImagePath$", "setImagePath(const QString&)", typeof(void), typeof(string), path);
        }
        /// <remarks>
        ///  Sets what borders should be painted
        ///  @arg flags borders we want to paint
        ///          </remarks>        <short>    Sets what borders should be painted  @arg flags borders we want to paint          </short>
        public void SetEnabledBorders(uint borders) {
            interceptor.Invoke("setEnabledBorders$", "setEnabledBorders(const Plasma::FrameSvg::EnabledBorders)", typeof(void), typeof(uint), borders);
        }
        /// <remarks>
        ///  Convenience method to get the enabled borders
        /// </remarks>        <return> what borders are painted
        ///          </return>
        ///         <short>    Convenience method to get the enabled borders </short>
        public uint EnabledBorders() {
            return (uint) interceptor.Invoke("enabledBorders", "enabledBorders() const", typeof(uint));
        }
        /// <remarks>
        ///  Resize the frame maintaining the same border size
        ///  @arg size the new size of the frame
        ///          </remarks>        <short>    Resize the frame maintaining the same border size  @arg size the new size of the frame          </short>
        public void ResizeFrame(QSizeF size) {
            interceptor.Invoke("resizeFrame#", "resizeFrame(const QSizeF&)", typeof(void), typeof(QSizeF), size);
        }
        /// <remarks>
        /// </remarks>        <return> the size of the frame
        ///          </return>
        ///         <short>   </short>
        public QSizeF FrameSize() {
            return (QSizeF) interceptor.Invoke("frameSize", "frameSize() const", typeof(QSizeF));
        }
        /// <remarks>
        ///  Returns the margin size given the margin edge we want
        ///  @arg edge the margin edge we want, top, bottom, left or right
        /// </remarks>        <return> the margin size
        ///          </return>
        ///         <short>    Returns the margin size given the margin edge we want  @arg edge the margin edge we want, top, bottom, left or right </short>
        public double MarginSize(Plasma.MarginEdge edge) {
            return (double) interceptor.Invoke("marginSize$", "marginSize(const Plasma::MarginEdge) const", typeof(double), typeof(Plasma.MarginEdge), edge);
        }
        /// <remarks>
        ///  Convenience method that extracts the size of the four margins
        ///  in the four output parameters
        ///  @arg left left margin size
        ///  @arg top top margin size
        ///  @arg right right margin size
        ///  @arg bottom bottom margin size
        ///          </remarks>        <short>    Convenience method that extracts the size of the four margins  in the four output parameters  @arg left left margin size  @arg top top margin size  @arg right right margin size  @arg bottom bottom margin size          </short>
        public void GetMargins(ref double left, ref double top, ref double right, ref double bottom) {
            StackItem[] stack = new StackItem[5];
            stack[1].s_double = left;
            stack[2].s_double = top;
            stack[3].s_double = right;
            stack[4].s_double = bottom;
            interceptor.Invoke("getMargins$$$$", "getMargins(qreal&, qreal&, qreal&, qreal&) const", stack);
            left = stack[1].s_double;
            top = stack[2].s_double;
            right = stack[3].s_double;
            bottom = stack[4].s_double;
            return;
        }
        /// <remarks>
        /// </remarks>        <return> the rectangle of the center element, taking the margins into account.
        ///          </return>
        ///         <short>   </short>
        public QRectF ContentsRect() {
            return (QRectF) interceptor.Invoke("contentsRect", "contentsRect() const", typeof(QRectF));
        }
        /// <remarks>
        ///  Sets the prefix (@see setElementPrefix) to 'north', 'south', 'west' and 'east'
        ///  when the location is TopEdge, BottomEdge, LeftEdge and RightEdge,
        ///  respectively. Clears the prefix in other cases.
        ///  @arg location location
        ///          </remarks>        <short>    Sets the prefix (@see setElementPrefix) to 'north', 'south', 'west' and 'east'  when the location is TopEdge, BottomEdge, LeftEdge and RightEdge,  respectively.</short>
        public void SetElementPrefix(Plasma.Location location) {
            interceptor.Invoke("setElementPrefix$", "setElementPrefix(Plasma::Location)", typeof(void), typeof(Plasma.Location), location);
        }
        /// <remarks>
        ///  Sets the prefix for the SVG elements to be used for painting. For example,
        ///  if prefix is 'active', then instead of using the 'top' element of the SVG
        ///  file to paint the top border, 'active-top' element will be used. The same
        ///  goes for other SVG elements.
        ///  If the elements with prefixes are not present, the default ones are used.
        ///  (for the sake of speed, the test is present only for the 'center' element)
        ///  Setting the prefix manually resets the location to Floating.
        ///  If the
        ///  @arg prefix prefix for the SVG element names
        ///          </remarks>        <short>    Sets the prefix for the SVG elements to be used for painting.</short>
        public void SetElementPrefix(string prefix) {
            interceptor.Invoke("setElementPrefix$", "setElementPrefix(const QString&)", typeof(void), typeof(string), prefix);
        }
        /// <remarks>
        /// </remarks>        <return> true if the svg has the necessary elements with the given prefix
        ///  to draw a frame
        ///  @arg prefix the given prefix we want to check if drawable
        ///          </return>
        ///         <short>   </short>
        public bool HasElementPrefix(string prefix) {
            return (bool) interceptor.Invoke("hasElementPrefix$", "hasElementPrefix(const QString&) const", typeof(bool), typeof(string), prefix);
        }
        /// <remarks>
        ///  This is an overloaded method provided for convenience equivalent to
        ///  hasElementPrefix("north"), hasElementPrefix("south")
        ///  hasElementPrefix("west") and hasElementPrefix("east")
        /// </remarks>        <return> true if the svg has the necessary elements with the given prefix
        ///  to draw a frame.
        ///  @arg location the given prefix we want to check if drawable
        ///          </return>
        ///         <short>    This is an overloaded method provided for convenience equivalent to  hasElementPrefix("north"), hasElementPrefix("south")  hasElementPrefix("west") and hasElementPrefix("east") </short>
        public bool HasElementPrefix(Plasma.Location location) {
            return (bool) interceptor.Invoke("hasElementPrefix$", "hasElementPrefix(Plasma::Location) const", typeof(bool), typeof(Plasma.Location), location);
        }
        /// <remarks>
        ///  Returns the prefix for SVG elements of the FrameSvg
        /// </remarks>        <return> the prefix
        ///          </return>
        ///         <short>    Returns the prefix for SVG elements of the FrameSvg </short>
        public string Prefix() {
            return (string) interceptor.Invoke("prefix", "prefix()", typeof(string));
        }
        /// <remarks>
        ///  Returns a monochrome mask that tightly contains the fully opaque areas of the svg
        /// </remarks>        <return> a monochrome bitmap of opaque areas
        ///          </return>
        ///         <short>    Returns a monochrome mask that tightly contains the fully opaque areas of the svg </short>
        public QBitmap Mask() {
            return (QBitmap) interceptor.Invoke("mask", "mask() const", typeof(QBitmap));
        }
        /// <remarks>
        ///  Sets whether saving all the rendered prefixes in a cache or not
        ///  @arg cache if use the cache or not
        ///         </remarks>        <short>    Sets whether saving all the rendered prefixes in a cache or not  @arg cache if use the cache or not         </short>
        public void SetCacheAllRenderedFrames(bool cache) {
            interceptor.Invoke("setCacheAllRenderedFrames$", "setCacheAllRenderedFrames(bool)", typeof(void), typeof(bool), cache);
        }
        /// <remarks>
        /// </remarks>        <return> if all the different prefixes should be kept in a cache when rendered
        ///         </return>
        ///         <short>   </short>
        public bool CacheAllRenderedFrames() {
            return (bool) interceptor.Invoke("cacheAllRenderedFrames", "cacheAllRenderedFrames() const", typeof(bool));
        }
        /// <remarks>
        ///  Deletes the internal cache freeing memory: use this if you want to switch the rendered
        ///  element and you don't plan to switch back to the previous one for a long time and you
        ///  used setUseCache(true)
        ///         </remarks>        <short>    Deletes the internal cache freeing memory: use this if you want to switch the rendered  element and you don't plan to switch back to the previous one for a long time and you  used setUseCache(true)         </short>
        public void ClearCache() {
            interceptor.Invoke("clearCache", "clearCache()", typeof(void));
        }
        /// <remarks>
        ///  Returns a pixmap of the SVG represented by this object.
        ///  @arg elelementId the ID string of the element to render, or an empty
        ///                   string for the whole SVG (the default)
        /// </remarks>        <return> a QPixmap of the rendered SVG
        ///          </return>
        ///         <short>    Returns a pixmap of the SVG represented by this object.</short>
        public QPixmap FramePixmap() {
            return (QPixmap) interceptor.Invoke("framePixmap", "framePixmap()", typeof(QPixmap));
        }
        /// <remarks>
        ///  Paints the loaded SVG with the elements that represents the border
        ///  @arg painter the QPainter to use
        ///  @arg target the target rectangle on the paint device
        ///  @arg source the portion rectangle of the source image
        ///          </remarks>        <short>    Paints the loaded SVG with the elements that represents the border  @arg painter the QPainter to use  @arg target the target rectangle on the paint device  @arg source the portion rectangle of the source image          </short>
        public void PaintFrame(QPainter painter, QRectF target, QRectF source) {
            interceptor.Invoke("paintFrame###", "paintFrame(QPainter*, const QRectF&, const QRectF&)", typeof(void), typeof(QPainter), painter, typeof(QRectF), target, typeof(QRectF), source);
        }
        public void PaintFrame(QPainter painter, QRectF target) {
            interceptor.Invoke("paintFrame##", "paintFrame(QPainter*, const QRectF&)", typeof(void), typeof(QPainter), painter, typeof(QRectF), target);
        }
        /// <remarks>
        ///  Paints the loaded SVG with the elements that represents the border
        ///  This is an overloaded member provided for convenience
        ///  @arg painter the QPainter to use
        ///  @arg pos where to paint the svg
        ///          </remarks>        <short>    Paints the loaded SVG with the elements that represents the border  This is an overloaded member provided for convenience  @arg painter the QPainter to use  @arg pos where to paint the svg          </short>
        public void PaintFrame(QPainter painter, QPointF pos) {
            interceptor.Invoke("paintFrame##", "paintFrame(QPainter*, const QPointF&)", typeof(void), typeof(QPainter), painter, typeof(QPointF), pos);
        }
        public void PaintFrame(QPainter painter) {
            interceptor.Invoke("paintFrame#", "paintFrame(QPainter*)", typeof(void), typeof(QPainter), painter);
        }
        ~FrameSvg() {
            interceptor.Invoke("~FrameSvg", "~FrameSvg()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~FrameSvg", "~FrameSvg()", typeof(void));
        }
        protected new IFrameSvgSignals Emit {
            get { return (IFrameSvgSignals) Q_EMIT; }
        }
    }

    public interface IFrameSvgSignals : Plasma.ISvgSignals {
    }
}
