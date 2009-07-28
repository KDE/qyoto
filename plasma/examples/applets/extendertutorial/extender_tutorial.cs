namespace Tutorials {
    using Qyoto;
    using Kimono;
    using Plasma;

    public class ExtenderTutorial : PlasmaScripting.PopupApplet {
        public ExtenderTutorial(AppletScript parent) : base(parent) {
            //We want to collapse into an icon when put into a panel.
            //If you don't call this function, you can display another 
            //widget, or draw something yourself.
            SetPopupIcon("extendertutorial");
        }

        public override void Init() {
            //Calling extender() instantiates an extender for you if you
            //haven't already done so. Never instantiate an extender 
            //before init() since Extender needs access to applet.config()
            //to work.
        
            //The message to be shown when there are no ExtenderItems in
            //this extender.
            Extender().EmptyExtenderMessage = KDE.I18n("no running jobs...");
        
            //Notify ourself whenever a new job is created.
            Connect(DataEngine("kuiserver"), 
                    SIGNAL("sourceAdded(const QString&)"),
                    this, SLOT("SourceAdded(const QString&)"));
        }
 
        //Implement this function to make ExtenderItems persistent.
        //This function will get called on plasma start for every 
        //ExtenderItem that belonged to this applet, and is still
        //around. Instantiate the widget to be wrapped in the 
        //ExtenderItem here.
        public override void InitExtenderItem(Plasma.ExtenderItem item) {
            //Create a Meter widget and wrap it in the ExtenderItem
            Plasma.Meter meter = new Plasma.Meter(item) {
                meterType = Plasma.Meter.MeterType.BarMeterHorizontal,
                meter.Svg = "widgets/bar_meter_horizontal",
                meter.Maximum = 100,
                meter.Value = 0
            };
        
            meter.SetMinimumSize(new QSizeF(250, 45));
            meter.SetPreferredSize(new QSizeF(250, 45));
 
            //often, you'll want to connect dataengines or set properties
            //depending on information contained in item.config().
            //In this situation that won't be necessary though.    
            item.Widget = meter;
        
            //Job names are not unique across plasma restarts (kuiserver
            //engine just starts with Job1 again), so avoid problems and
            //just don't give reinstantiated items a name.
            item.Name = "";
        
            //Show a close button.
            item.ShowCloseButton();
        }
 
        //We want to add a new ExtenderItem everytime a new job 
        //is started.
        [Q_SLOT()]
        public void SourceAdded(string source) {
            //Add a new ExtenderItem
            Plasma.ExtenderItem item = new Plasma.ExtenderItem(Extender());
            InitExtenderItem(item);
        
            //We give this item a name, which we don't use in this
            //example, but allows us to look up extenderItems by calling
            //extenderItem(name). That function is useful to avoid 
            //duplicating detached ExtenderItems between session, because 
            //you can check if a certain item already exists.
            item.Name = source;
        
            //And we give this item a title. Titles, along with icons and
            //names are persistent between sessions.
            item.Title = source;
        
            //Connect a dataengine. If this applet would display data where 
            //datasources would have unique names, even between sessions, 
            //you should do this in initExtenderItem, so that after a plasma 
            //restart, datasources would still get connected to the 
            //appropriate sources. Kuiserver jobs are not persistent however, 
            //so we connect them here.
            DataEngine("kuiserver").ConnectSource(source, (QObject) item.Widget, 200);
        
            //Show the popup for 5 seconds if in panel, so the user notices
            //that there's a new job running.
            ShowPopup(5000);
        }
    }
}
/*
[Desktop Entry]
Name=Extender Tutorial
Type=Service
X-KDE-ServiceTypes=Plasma/Applet
 
X-KDE-Library=plasma_applet_extendertutorial
X-KDE-PluginInfo-Author=The Plasma Team
X-KDE-PluginInfo-Email=plasma-devel@kde.org
X-KDE-PluginInfo-Name=extendertutorial
X-KDE-PluginInfo-Version=pre0.1
X-KDE-PluginInfo-Website=http://plasma.kde.org/
X-KDE-PluginInfo-Category=
X-KDE-PluginInfo-Depends=
X-KDE-PluginInfo-License=GPL
X-KDE-PluginInfo-EnabledByDefault=true
*/