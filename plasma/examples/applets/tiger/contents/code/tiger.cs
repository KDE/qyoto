namespace Tiger {
    using Qyoto;
    using Plasma;

    public class Main : PlasmaScripting.Applet {
        private Plasma.Svg svg;

        public Main(AppletScript parent) : base(parent) {}

        public override void Init() {
            svg = new Plasma.Svg(this);
            svg.ImagePath = "widgets/tiger";
        }

        public override void PaintInterface(    QPainter painter,
                                                QStyleOptionGraphicsItem option,
                                                QRect contentsRect )
        {
            svg.Resize(Size);
            svg.Paint(painter, 0, 0);
        }
    }
}
