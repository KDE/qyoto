/* This file is part of the KDE project
   Copyright (C) 2001 Christoph Cullmann <cullmann@kde.org>
   Copyright (C) 2001 Joseph Wenninger <jowenn@kde.org>
   Copyright (C) 2001 Anders Lund <anders.lund@lund.tdcadsl.dk>

   This library is free software; you can redistribute it and/or
   modify it under the terms of the GNU Library General Public
   License version 2 as published by the Free Software Foundation.

   This library is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
   Library General Public License for more details.

   You should have received a copy of the GNU Library General Public License
   along with this library; see the file COPYING.LIB.  If not, write to
   the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
   Boston, MA 02110-1301, USA.
*/

using System;
using System.Text;
using System.Collections.Generic;
using Qyoto;
using Kimono;

public class KWrite : KParts.MainWindow {
    private KTextEditor.View m_view = null;

    private KRecentFilesAction m_recentFiles = null;
    private KToggleAction m_showPath = null;
    private KToggleAction m_showStatusBar = null;

    private string encoding;

    static List<KTextEditor.Document> docList = new List<KTextEditor.Document>();
    static List<KWrite> winList = new List<KWrite>();

    private QLabel m_lineColLabel;
    private QLabel m_modifiedLabel;
    private QLabel m_insertModeLabel;
    private QLabel m_selectModeLabel;
    private QLabel m_modeLabel;
    private KSqueezedTextLabel m_fileNameLabel;
    private QPixmap m_modPm;
    private QPixmap m_modDiscPm;
    private QPixmap m_modmodPm;
    private QPixmap m_noPm;

    KWrite() : this((KTextEditor.Document) null) {}

    KWrite(KTextEditor.Document doc) : base(null, 0) {
        if (doc == null) {
            KTextEditor.Editor editor = KTextEditor.EditorChooser.Editor();

            if (editor == null) {
                KMessageBox.Error(this, KDE.I18n("A KDE text-editor component could not be found;\n" +
                                    "please check your KDE installation."));
                QCoreApplication.Exit(1);
            }

            // set simple mode
            editor.SetSimpleMode(true);

            doc = editor.CreateDocument(null);

            // enable the modified on disk warning dialogs if any
            if (qobject_cast<KTextEditor.ModificationInterface>(doc) != null)
                qobject_cast<KTextEditor.ModificationInterface>(doc).SetModifiedOnDiskWarning(true);

            docList.Add(doc);
        }

        m_view = doc.CreateView(this);

        SetCentralWidget(m_view);

        SetupActions();
        SetupStatusBar();

        // signals for the statusbar
        Connect(m_view, SIGNAL("cursorPositionChanged(KTextEditor::View *, const KTextEditor::Cursor &)"), this, SLOT("CursorPositionChanged(KTextEditor::View *)"));
        Connect(m_view, SIGNAL("viewModeChanged(KTextEditor::View *)"), this, SLOT("ViewModeChanged(KTextEditor::View *)"));
        Connect(m_view, SIGNAL("selectionChanged(KTextEditor::View *)"), this, SLOT("SelectionChanged(KTextEditor::View *)"));
        Connect(m_view, SIGNAL("informationMessage(KTextEditor::View *, const QString&)"), this, SLOT("InformationMessage(KTextEditor::View *, const QString &)"));
        Connect(m_view.Document(), SIGNAL("modifiedChanged(KTextEditor::Document *)"), this, SLOT("ModifiedChanged()"));
        Connect(m_view.Document(), SIGNAL("modifiedOnDisk(KTextEditor::Document *, bool, KTextEditor::ModificationInterface::ModifiedOnDiskReason)"), this, SLOT("ModifiedChanged()"));
        Connect(m_view.Document(), SIGNAL("documentNameChanged(KTextEditor::Document *)"), this, SLOT("DocumentNameChanged()"));
        Connect(m_view.Document(), SIGNAL("documentUrlChanged(KTextEditor::Document *)"), this, SLOT("UrlChanged()"));
        Connect(m_view.Document(), SIGNAL("modeChanged(KTextEditor::Document *)"), this, SLOT("ModeChanged(KTextEditor::Document *)"));

        AcceptDrops = true;
        Connect(m_view, SIGNAL("dropEventPass(QDropEvent *)"), this, SLOT("SlotDropEvent(QDropEvent *)"));

        SetXMLFile("kwrite-sharpui.rc");
        CreateShellGUI(true);
        GuiFactory().AddClient(m_view);

        // install a working kate part popup dialog thingy
        m_view.SetContextMenu((QMenu)(Factory().Container("ktexteditor_popup", this)));

        // init with more useful size, stolen from konq :)
        if (!InitialGeometrySet)
            Size = new QSize(700, 480).ExpandedTo(MinimumSizeHint());

        // call it as last thing, must be sure everything is already set up ;)
        SetAutoSaveSettings();

        ReadConfig();

        winList.Add(this);

        UpdateStatus();
        Show();
    }

    ~KWrite() {
        winList.Remove(this);

        if (m_view.Document().Views().Count == 1) {
            docList.Remove(m_view.Document());
            // m_view.Document().Dispose();
        }

        KGlobal.Config().Sync();
    }

    private void SetupActions() {
        ActionCollection().AddAction(KStandardAction.StandardAction.Close, "file_close", this, SLOT("SlotFlush()"))
            .WhatsThis = KDE.I18n("Use this to close the current document");

        // setup File menu
        ActionCollection().AddAction(KStandardAction.StandardAction.New, "file_new", this, SLOT("SlotNew()"))
           .WhatsThis = KDE.I18n("Use this command to create a new document");
        ActionCollection().AddAction(KStandardAction.StandardAction.Open, "file_open", this, SLOT("SlotOpen()"))
           .WhatsThis = KDE.I18n("Use this command to open an existing document for editing");

        m_recentFiles = KStandardAction.OpenRecent(this, SLOT("SlotOpen(const KUrl&)"), this);
        ActionCollection().AddAction(m_recentFiles.ObjectName, m_recentFiles);
        m_recentFiles.WhatsThis = KDE.I18n("This lists files which you have opened recently, and allows you to easily open them again.");

        QAction a = ActionCollection().AddAction("view_new_view");
        a.icon = new KIcon("window-new");
        a.Text = KDE.I18n("&New Window");
        Connect(a, SIGNAL("triggered()"), this, SLOT("NewView()"));
        a.WhatsThis = KDE.I18n("Create another view containing the current document");

        ActionCollection().AddAction(KStandardAction.StandardAction.Quit, this, SLOT("close()"))
           .WhatsThis = KDE.I18n("Close the current document view");

        // setup Settings menu
        StandardToolBarMenuEnabled = true;

        m_showStatusBar = KStandardAction.ShowStatusbar(this, SLOT("ToggleStatusBar()"), this);
        ActionCollection().AddAction("settings_show_statusbar", m_showStatusBar);
        m_showStatusBar.WhatsThis = KDE.I18n("Use this command to show or hide the view's statusbar");

        m_showPath = new KToggleAction(KDE.I18n("Sho&w Path"), this);
        ActionCollection().AddAction("set_showPath", m_showPath);
        Connect(m_showPath, SIGNAL("triggered()"), this, SLOT("DocumentNameChanged()"));
        m_showPath.WhatsThis = KDE.I18n("Show the complete document path in the window caption");

        a = ActionCollection().AddAction(KStandardAction.StandardAction.KeyBindings, this, SLOT("EditKeys()"));
        a.WhatsThis = KDE.I18n("Configure the application's keyboard shortcut assignments.");

        a = ActionCollection().AddAction(KStandardAction.StandardAction.ConfigureToolbars, "options_configure_toolbars",
                                     this, SLOT("EditToolbars()"));
        a.WhatsThis = KDE.I18n("Configure which items should appear in the toolbar(s).");

        a = ActionCollection().AddAction("help_about_editor");
        a.Text = KDE.I18n("&About Editor Component");
        Connect(a, SIGNAL("triggered()"), this, SLOT("AboutEditor()"));
    }

    private void SetupStatusBar() {
        // statusbar stuff
        m_lineColLabel = new QLabel(StatusBar());
        StatusBar().AddWidget(m_lineColLabel, 0);
        m_lineColLabel.Alignment = (uint) Qt.AlignmentFlag.AlignCenter;

        m_modifiedLabel = new QLabel("   ", StatusBar());
        StatusBar().AddWidget(m_modifiedLabel, 0);
        m_modifiedLabel.Alignment = (uint) Qt.AlignmentFlag.AlignCenter;

        m_insertModeLabel = new QLabel(KDE.I18n(" INS "), StatusBar());
        StatusBar().AddWidget(m_insertModeLabel, 0);
        m_insertModeLabel.Alignment = (uint) Qt.AlignmentFlag.AlignCenter;

        m_selectModeLabel = new QLabel(KDE.I18nc("@info:status Statusbar label for line selection mode", " LINE "), StatusBar());
        StatusBar().AddWidget(m_selectModeLabel, 0);
        m_selectModeLabel.Alignment = (uint) Qt.AlignmentFlag.AlignCenter;

        m_modeLabel = new QLabel("", StatusBar());
        StatusBar().AddWidget(m_modeLabel, 0);
        m_modeLabel.Alignment = (uint) Qt.AlignmentFlag.AlignCenter;

        m_fileNameLabel = new KSqueezedTextLabel(StatusBar());
        StatusBar().AddPermanentWidget(m_fileNameLabel, 1);
        m_fileNameLabel.SetMinimumSize(0, 0);
        m_fileNameLabel.SizePolicy = new QSizePolicy(QSizePolicy.Policy.Ignored, QSizePolicy.Policy.Fixed);
        m_fileNameLabel.Alignment = (uint) Qt.AlignmentFlag.AlignLeft;

        m_modPm = KDE.SmallIcon("modified");
        m_modDiscPm = KDE.SmallIcon("modonhd");
        m_modmodPm = KDE.SmallIcon("modmod");
        m_noPm = KDE.SmallIcon("null");
    }

    // load on url
    public void LoadURL(KUrl url) {
        m_view.Document().OpenUrl(url);
    }

    public KTextEditor.View View() { return m_view; }

    public static bool NoWindows() { return winList.Count == 0; }

    // is closing the window wanted by user?
    protected override bool QueryClose() {
        if (m_view.Document().Views().Count > 1)
            return true;

        if (m_view.Document().QueryClose()) {
            // WriteConfig();
            return true;
        }

        return false;
    }

    [Q_SLOT()]
    public void SlotFlush() {
        m_view.Document().CloseUrl();
    }

    [Q_SLOT()]
    public void SlotNew() {
        new KWrite();
    }

    [Q_SLOT()]
    public void SlotOpen() {
        KEncodingFileDialog.Result r = KEncodingFileDialog.GetOpenUrlsAndEncoding(  m_view.Document().Encoding(), 
                                                                                    m_view.Document().Url.Url(),
                                                                                    "",
                                                                                    this,
                                                                                    KDE.I18n("Open File") );

        foreach (KUrl url in r.URLs) {
            encoding = r.Encoding;
            SlotOpen(url);
        }

    }

    [Q_SLOT("SlotOpen(KUrl)")]
    public void SlotOpen(KUrl url) {
        if (url.IsEmpty()) return;

//        if (!KIO.NetAccess.Exists(url, KIO.NetAccess.StatSide.SourceSide, this)) {
//            KMessageBox.Error(this, KDE.I18n("The file given could not be read; check whether it exists or is readable for the current user."));
//            return;
//        }

        if (m_view.Document().IsModified() || !m_view.Document().Url.IsEmpty()) {
            KWrite t = new KWrite();
            t.m_view.Document().SetEncoding(encoding);
            t.LoadURL(url);
        } else {
            m_view.Document().SetEncoding(encoding);
            LoadURL(url);
        }
    }

    [Q_SLOT()]
    public void UrlChanged() {
        if (m_view.Document().Url.IsEmpty()) {
            m_recentFiles.AddUrl( m_view.Document().Url);
        }
    }

    [Q_SLOT()]
    public void NewView() {
        new KWrite(m_view.Document());
    }

    [Q_SLOT()]
    public void ToggleStatusBar() {
        if (m_showStatusBar.Checked) {
            StatusBar().Show();
        } else {
            StatusBar().Hide();
        }
    }

    [Q_SLOT()]
    public void EditKeys() {
        KShortcutsDialog dlg = new KShortcutsDialog(    (uint) KShortcutsEditor.ActionType.AllActions, 
                                                        KShortcutsEditor.LetterShortcuts.LetterShortcutsAllowed, 
                                                        this );
        dlg.AddCollection(ActionCollection());
        if (m_view != null) {
            dlg.AddCollection(m_view.ActionCollection());
        }
        dlg.Configure();
    }

    [Q_SLOT()]
    public void EditToolbars() {
        SaveMainWindowSettings(KGlobal.Config().Group("MainWindow"));
        KEditToolBar dlg = new KEditToolBar(GuiFactory(), this);

        Connect(dlg, SIGNAL("newToolBarConfig()"), this, SLOT("SlotNewToolbarConfig()"));
        dlg.Exec();
    }

    [Q_SLOT()]
    public void SlotNewToolbarConfig() {
        ApplyMainWindowSettings(KGlobal.Config().Group("MainWindow"));
    }

    protected override void DragEnterEvent(QDragEnterEvent e) {
//        KUrl.List uriList = KUrl.List.FromMimeData(e.MimeData());
//        if (!uriList.IsEmpty()) {
//            e.Accept();
//        }
    }

    protected override void DropEvent(QDropEvent e) {
        SlotDropEvent(e);
    }

    [Q_SLOT("SlotDropEvent(QDropEvent*)")]
    public void SlotDropEvent(QDropEvent e) {
//        KUrl.List textlist = KUrl.List.FromMimeData(e.mimeData());

//        if (textlist.IsEmpty()) {
//            return;
//        }

//        for (KUrl.List.Iterator i=textlist.begin(); i != textlist.end(); ++i) {
//            SlotOpen(i);
//        }
    }

    [Q_SLOT()]
    public void SlotEnableActions(bool enable) {
        List<QAction> actions = ActionCollection().Actions();

        foreach (QAction action in actions) {
            action.Enabled = enable;
        }

        actions = m_view.ActionCollection().Actions();

        foreach (QAction action in actions) {
            action.Enabled = enable;
        }
    }

    //common config
    public void ReadConfig(KSharedConfig config) {
        KConfigGroup cfg = new KConfigGroup(config, "General Options");

        m_showStatusBar.Checked = cfg.ReadEntry("ShowStatusBar", true);
        m_showPath.Checked = cfg.ReadEntry("ShowPath", false);

        m_recentFiles.LoadEntries(config.Group("Recent Files"));

        m_view.Document().Editor().ReadConfig(config);

        if (m_showStatusBar.Checked) {
            StatusBar().Show();
        } else {
            StatusBar().Hide();
        }
    }

    public void WriteConfig(KSharedConfig config) {
        KConfigGroup generalOptions = new KConfigGroup(config, "General Options");

        generalOptions.WriteEntry("ShowStatusBar", m_showStatusBar.Checked);
        generalOptions.WriteEntry("ShowPath", m_showPath.Checked);

        m_recentFiles.SaveEntries(new KConfigGroup(config, "Recent Files"));

        // Writes into its own group
        m_view.Document().Editor().WriteConfig(config);

        config.Sync();
    }

    //config file
    private void ReadConfig() {
        ReadConfig(KGlobal.Config());
    }

    private void WriteConfig() {
        WriteConfig(KGlobal.Config());
    }

    // session management
    protected void Restore(KConfig config, int n) {
        ReadPropertiesInternal(config, n);
    }

    private void ReadProperties(KSharedConfig config) {
        ReadConfig(config);

        KTextEditor.SessionConfigInterface iface = qobject_cast<KTextEditor.SessionConfigInterface >(m_view);
        if (iface != null)
            iface.ReadSessionConfig(new KConfigGroup(config, "General Options"));
    }

    private void SaveProperties(KSharedConfig config) {
        WriteConfig(config);

        KConfigGroup group = new KConfigGroup(config, "");
        group.WriteEntry("DocumentNumber", docList.IndexOf(m_view.Document()) + 1);

        KTextEditor.SessionConfigInterface iface = qobject_cast<KTextEditor.SessionConfigInterface >(m_view);
        if (iface != null) {
            KConfigGroup cg = new KConfigGroup( config, "General Options" );
            iface.WriteSessionConfig(cg);
        }
    }

    private void SaveGlobalProperties(KConfig config) {
        config.Group("Number").WriteEntry("NumberOfDocuments", docList.Count);

        int z = 1;
        foreach (KTextEditor.Document document in docList) {
            string buf = "Document " + z.ToString();
            KConfigGroup cg = new KConfigGroup(config, buf);
            KTextEditor.Document doc = docList[z - 1];

            KTextEditor.SessionConfigInterface iface = qobject_cast<KTextEditor.SessionConfigInterface >(doc);
            if (iface != null)
                iface.WriteSessionConfig(cg);
            z++;
        }

        z = 1;
        foreach (KWrite window in winList) {
            string buf = "Window " + z.ToString();
            KConfigGroup cg = new KConfigGroup(config, buf);
            cg.WriteEntry("DocumentNumber", docList.IndexOf(window.View().Document()) + 1);
            z++;
        }
    }

    //restore session
    public static void Restore() {
        KConfig config = KApplication.kApplication().SessionConfig();

        if (config == null) {
            return;
        }

        KTextEditor.Editor editor = KTextEditor.EditorChooser.Editor();

        if (editor == null) {
            KMessageBox.Error(null, KDE.I18n("A KDE text-editor component could not be found;\n" +
                                  "please check your KDE installation."));
            QCoreApplication.Exit(1);
        }

        // simple mode
        editor.SetSimpleMode(true);

        int docs, windows;
        string buf;
        KTextEditor.Document doc;
        KWrite t;

        KConfigGroup numberConfig = new KConfigGroup(config, "Number");
        docs = numberConfig.ReadEntry("NumberOfDocuments", 0);
        windows = numberConfig.ReadEntry("NumberOfWindows", 0);

        for (int z = 1; z <= docs; z++) {
            buf = "Document " + z.ToString();
            KConfigGroup cg = new KConfigGroup(config, buf);
            doc = editor.CreateDocument(null);

            KTextEditor.SessionConfigInterface iface = qobject_cast<KTextEditor.SessionConfigInterface >(doc);
            if (iface != null)
                iface.ReadSessionConfig(cg);
            docList.Add(doc);
        }

        for (int z = 1; z <= windows; z++) {
            buf = "Window " + z;
            KConfigGroup cg = new KConfigGroup(config, buf);
            t = new KWrite(docList[cg.ReadEntry("DocumentNumber", 0) - 1]);
            t.Restore(config, z);
        }
    }

    [Q_SLOT()]
    public void AboutEditor() {
        KAboutApplicationDialog dlg = new KAboutApplicationDialog(m_view.Document().Editor().AboutData(), this);
        dlg.Exec();
    }

    public void UpdateStatus() {
        ViewModeChanged(m_view);
        CursorPositionChanged(m_view);
        SelectionChanged(m_view);
        ModifiedChanged();
        DocumentNameChanged();
        ModeChanged(m_view.Document());
    }   

    [Q_SLOT("ViewModeChanged(KTextEditor::View*)")]
    public void ViewModeChanged(KTextEditor.View view) {
        m_insertModeLabel.Text = view.ViewMode();
    }

    [Q_SLOT("CursorPositionChanged(KTextEditor::View*)")]
    public void CursorPositionChanged(KTextEditor.View view) {
        KTextEditor.Cursor position = new KTextEditor.Cursor(view.CursorPositionVirtual());

        m_lineColLabel.Text =
            KDE.I18nc(  "@info:status Statusbar label for cursor line and column position", 
                        " Line: " + (position.Line()+1).ToString() + " Col: " + (position.Column()+1).ToString() );
    }

    [Q_SLOT("SelectionChanged(KTextEditor::View*)")]
    public void SelectionChanged(KTextEditor.View view) {
        m_selectModeLabel.Text = 
            view.BlockSelection() ? KDE.I18nc("@info:status Statusbar label for block selection mode", " BLOCK ") : 
                KDE.I18nc("@info:status Statusbar label for line selection mode", " LINE ");
    }

    [Q_SLOT("InformationMessage(KTextEditor::View*, QString)")]
    public void InformationMessage(KTextEditor.View view, string message) {
        m_fileNameLabel.Text = message;

        // timer to reset this after 4 seconds
        QTimer.singleShot(4000, this, SLOT("DocumentNameChanged()"));
    }

    [Q_SLOT()]
    public void ModifiedChanged() {
        bool mod = m_view.Document().IsModified();
        m_modifiedLabel.SetPixmap(mod ? m_modPm : m_noPm);
        DocumentNameChanged(); // update the modified flag in window title
    }

    [Q_SLOT()]
    public void DocumentNameChanged() {
        m_fileNameLabel.Text = KStringHandler.Lsqueeze(m_view.Document().DocumentName(), 64);

        if (m_view.Document().Url.IsEmpty()) {
            SetCaption(KDE.I18n("Untitled"), m_view.Document().IsModified());
        } else {
            string c;
            if (!m_showPath.Checked) {
                c = m_view.Document().Url.FileName();

                   //File name shouldn't be too long - Maciek
                if (c.Length > 64) {
                    c = c.Substring(0, 64) + "...";
                }
            } else {
                c = m_view.Document().Url.PrettyUrl();

                //File name shouldn't be too long - Maciek
                if (c.Length > 64) {
                    c = "..." + c.Substring(c.Length - 64, 64);
                }
            }

            SetCaption(c, m_view.Document().IsModified());
        }
    }

    [Q_SLOT("ModeChanged(KTextEditor::Document *)")]
    public void ModeChanged(KTextEditor.Document document) {
        m_modeLabel.Text = document.Mode();
    }

    public static int Main(String[] argv) {
        KAboutData aboutData = new KAboutData(  "kwrite-sharp", "Simple Text Editor",
                                                KDE.Ki18n("KWrite"),
                                                "4.1", // KDE.VersionString(),
                                                KDE.Ki18n("KWrite - Text Editor"),
                                                KAboutData.LicenseKey.License_LGPL_V2,
                                                KDE.Ki18n("(c) 2000-2005 The Kate Authors"), 
                                                new KLocalizedString(), 
                                                "http://www.kate-editor.org" );

        aboutData.AddAuthor(KDE.Ki18n("Christoph Cullmann"), KDE.Ki18n("Maintainer"), "cullmann@kde.org", "http://www.babylon2k.de");
        aboutData.AddAuthor(KDE.Ki18n("Anders Lund"), KDE.Ki18n("Core Developer"), "anders@alweb.dk", "http://www.alweb.dk");
        aboutData.AddAuthor(KDE.Ki18n("Joseph Wenninger"), KDE.Ki18n("Core Developer"), "jowenn@kde.org","http://stud3.tuwien.ac.at/~e9925371");
        aboutData.AddAuthor(KDE.Ki18n("Hamish Rodda"),KDE.Ki18n("Core Developer"), "rodda@kde.org");
        aboutData.AddAuthor(KDE.Ki18n("Dominik Haumann"), KDE.Ki18n("Developer & Highlight wizard"), "dhdev@gmx.de");
        aboutData.AddAuthor(KDE.Ki18n("Waldo Bastian"), KDE.Ki18n( "The cool buffersystem" ), "bastian@kde.org" );
        aboutData.AddAuthor(KDE.Ki18n("Charles Samuels"), KDE.Ki18n("The Editing Commands"), "charles@kde.org");
        aboutData.AddAuthor(KDE.Ki18n("Matt Newell"), KDE.Ki18n("Testing, ..."), "newellm@proaxis.com");
        aboutData.AddAuthor(KDE.Ki18n("Michael Bartl"), KDE.Ki18n("Former Core Developer"), "michael.bartl1@chello.at");
        aboutData.AddAuthor(KDE.Ki18n("Michael McCallum"), KDE.Ki18n("Core Developer"), "gholam@xtra.co.nz");
        aboutData.AddAuthor(KDE.Ki18n("Jochen Wilhemly"), KDE.Ki18n( "KWrite Author" ), "digisnap@cs.tu-berlin.de" );
        aboutData.AddAuthor(KDE.Ki18n("Michael Koch"),KDE.Ki18n("KWrite port to KParts"), "koch@kde.org");
        aboutData.AddAuthor(KDE.Ki18n("Christian Gebauer"), new KLocalizedString(), "gebauer@kde.org" );
        aboutData.AddAuthor(KDE.Ki18n("Simon Hausmann"), new KLocalizedString(), "hausmann@kde.org" );
        aboutData.AddAuthor(KDE.Ki18n("Glen Parker"),KDE.Ki18n("KWrite Undo History, Kspell integration"), "glenebob@nwlink.com");
        aboutData.AddAuthor(KDE.Ki18n("Scott Manson"),KDE.Ki18n("KWrite XML Syntax highlighting support"), "sdmanson@alltel.net");
        aboutData.AddAuthor(KDE.Ki18n("John Firebaugh"),KDE.Ki18n("Patches and more"), "jfirebaugh@kde.org");
        
        aboutData.AddCredit(KDE.Ki18n("Matteo Merli"),KDE.Ki18n("Highlighting for RPM Spec-Files, Perl, Diff and more"), "merlim@libero.it");
        aboutData.AddCredit(KDE.Ki18n("Rocky Scaletta"),KDE.Ki18n("Highlighting for VHDL"), "rocky@purdue.edu");
        aboutData.AddCredit(KDE.Ki18n("Yury Lebedev"),KDE.Ki18n("Highlighting for SQL"));
        aboutData.AddCredit(KDE.Ki18n("Chris Ross"),KDE.Ki18n("Highlighting for Ferite"));
        aboutData.AddCredit(KDE.Ki18n("Nick Roux"),KDE.Ki18n("Highlighting for ILERPG"));
        aboutData.AddCredit(KDE.Ki18n("Carsten Niehaus"), KDE.Ki18n("Highlighting for LaTeX"));
        aboutData.AddCredit(KDE.Ki18n("Per Wigren"), KDE.Ki18n("Highlighting for Makefiles, Python"));
        aboutData.AddCredit(KDE.Ki18n("Jan Fritz"), KDE.Ki18n("Highlighting for Python"));
        aboutData.AddCredit(KDE.Ki18n("Daniel Naber"));
        aboutData.AddCredit(KDE.Ki18n("Roland Pabel"),KDE.Ki18n("Highlighting for Scheme"));
        aboutData.AddCredit(KDE.Ki18n("Cristi Dumitrescu"),KDE.Ki18n("PHP Keyword/Datatype list"));
        aboutData.AddCredit(KDE.Ki18n("Carsten Pfeiffer"), KDE.Ki18n("Very nice help"));
        aboutData.AddCredit(KDE.Ki18n("Richard Dale"), KDE.Ki18n("C# port"));
        aboutData.AddCredit(KDE.Ki18n("All people who have contributed and I have forgotten to mention"));
        aboutData.SetProgramIconName("accessories-text-editor");

        KCmdLineArgs.Init(argv, aboutData);

        KCmdLineOptions options = new KCmdLineOptions();
        options.Add("stdin", KDE.Ki18n("Read the contents of stdin"));
        options.Add("encoding <argument>", KDE.Ki18n("Set encoding for the file to open"));
        options.Add("line <argument>", KDE.Ki18n("Navigate to this line"));
        options.Add("column <argument>", KDE.Ki18n("Navigate to this column"));
        options.Add("+[URL]", KDE.Ki18n("Document to open"));
        KCmdLineArgs.AddCmdLineOptions(options);

        KApplication a = new KApplication();

        KGlobal.Locale().InsertCatalog("katepart4");
        KCmdLineArgs args = KCmdLineArgs.ParsedArgs();

        if (a.IsSessionRestored()) {
            KWrite.Restore();
        } else {
            bool nav = false;
            int line = 0, column = 0;

            // The code below that uses KCmdLineArgs doesn't work, so avoid it for now
            KWrite t2 = new KWrite();
            return KApplication.Exec();

            QTextCodec codec = args.IsSet("encoding") ? QTextCodec.CodecForName(args.GetOption("encoding")) : null;


            if (args.IsSet("line")) {
                line = System.Convert.ToInt32(args.GetOption("line")) - 1;
                nav = true;
            }

            if (args.IsSet("column")) {
                column = System.Convert.ToInt32(args.GetOption("column")) - 1;
                nav = true;
            }

            if (args.Count() == 0) {
                KWrite t = new KWrite((KTextEditor.Document) null);

                if (args.IsSet("stdin")) {
                    // FIXME: the first argument should be stdin here
                    QTextStream input = new QTextStream(new StringBuilder(), (uint) QIODevice.OpenModeFlag.ReadOnly);

                    // set chosen codec
                    if (codec != null)
                        input.SetCodec(codec);

                    string inputLine;
                    string text = "";

                    do {
                        inputLine = input.ReadLine();
                        text += (inputLine + "\n");
                    } while(inputLine.Length != 0);


                    KTextEditor.Document doc = t.View().Document();
                    if (doc != null)
                        doc.SetText(text);
                }

                if (nav && t.View() != null)
                    t.View().SetCursorPosition(new KTextEditor.Cursor(line, column));
            } else {
                int docs_opened = 0;
                for ( int z = 0; z < args.Count(); z++ ) {
                    // this file is no local dir, open it, else warn
                    bool noDir = !args.Url(z).IsLocalFile()  || !(new QDir(args.Url(z).Path())).Exists();
                    if (noDir) {
                        ++docs_opened;
                        KWrite t = new KWrite();
                        //if (codec != null)
                        //    t.View().Document().SetEncoding(codec.Name());
                        t.LoadURL(args.Url(z));
                        if (nav)
                            t.View().SetCursorPosition(new KTextEditor.Cursor(line, column));
                    } else {
                        KMessageBox.Sorry(null, KDE.I18n("The file " + args.Url(z).Url() + " could not be opened: it is not a normal file, it is a folder."));
                    }
                }
                if (docs_opened == 0) return 1; // see http://bugs.kde.org/show_bug.cgi?id=124708
            }
        }

        // no window there, uh, ohh, for example borked session config !!!
        // create at least one !!
        if (KWrite.NoWindows())
            new KWrite();
        return KApplication.Exec();
    }
}

class KWriteEditorChooser : KDialog {
    KWriteEditorChooser(QWidget parent) : base(parent) {
        SetCaption(KDE.I18n("Choose Editor Component"));
        SetButtons((uint) KDialog.ButtonCode.Ok | (uint) KDialog.ButtonCode.Cancel);
        SetDefaultButton(KDialog.ButtonCode.Cancel);
        m_chooser = new KTextEditor.EditorChooser(this);
        ResizeLayout(m_chooser, 0, SpacingHint());
        SetMainWidget(m_chooser);
        m_chooser.ReadAppSetting();

        Connect(this, SIGNAL("okClicked()"), SLOT("SlotOk()"));
    }

    private KTextEditor.EditorChooser m_chooser;

    [Q_SLOT()]
    private void SlotOk() {
        m_chooser.WriteAppSetting();
    }
}

// kate: space-indent on; indent-width 4; replace-tabs on; mixed-indent off;
