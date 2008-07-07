namespace Tiger {
    using System;
    using Qyoto;
    using Kimono;
    using Plasma;

    public class Main : PlasmaScripting.Applet {
        private Plasma.Svg svg;

        public Main(AppletScript parent) : base(parent) {}

        public void Init() {
            svg = new Plasma.Svg(this);
            svg.FilePath = "widgets/tiger";
        }

        public void PaintInterface( QPainter painter,
                                    QStyleOptionGraphicsItem option,
                                    QRect contentsRect )
        {
            svg.Resize(Size);
            svg.Paint(painter, 0, 0);
        }
    }
}
