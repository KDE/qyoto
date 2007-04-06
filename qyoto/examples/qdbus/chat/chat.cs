/****************************************************************************
 **
 ** Copyright (C) 1992-2006 Trolltech ASA. All rights reserved.
 **
 ** This file is part of the example classes of the Qt Toolkit.
 **
 ** This file may be used under the terms of the GNU General Public
 ** License version 2.0 as published by the Free Software Foundation
 ** and appearing in the file LICENSE.GPL included in the packaging of
 ** this file.  Please review the following information to ensure GNU
 ** General Public Licensing requirements will be met:
 ** http://www.trolltech.com/products/qt/opensource.html
 **
 ** If you are unsure which license is appropriate for your use, please
 ** review the following information:
 ** http://www.trolltech.com/products/qt/licensing.html or contact the
 ** sales department at sales@trolltech.com.
 **
 ** Translated to C#/Qyoto by Richard Dale
 **
 ****************************************************************************/

using Qyoto;
using System;
using System.Collections.Generic;
using System.Text;

public class ChatMainWindow : QMainWindow {
    string m_nickname = "nickname";
    List<string> m_messages;
    Ui.ChatMainWindow m_ui;

    ChatMainWindow() : base()
    {
        m_messages = new List<string>();
        m_ui = new Ui.ChatMainWindow();
        m_ui.SetupUi(this);
        m_ui.sendButton.Enabled = false;
    
        Connect(m_ui.messageLineEdit, SIGNAL("textChanged(QString)"),
                this, SLOT("TextChangedSlot(QString)"));
        Connect(m_ui.sendButton, SIGNAL("clicked(bool)"), this, SLOT("SendClickedSlot()"));
        Connect(m_ui.actionChangeNickname, SIGNAL("triggered(bool)"), this, SLOT("ChangeNickname()"));
        Connect(m_ui.actionAboutQt, SIGNAL("triggered(bool)"), this, SLOT("AboutQt()"));
        Connect(qApp, SIGNAL("lastWindowClosed()"), this, SLOT("Exiting()"));
    
        // add our D-Bus interface and connect to D-Bus
        new ChatAdaptor(this);
        QDBusConnection.SessionBus().RegisterObject("/", this);
    
        com.trolltech.chat iface;
        iface = new com.trolltech.chat("", "", QDBusConnection.SessionBus(), this);
        //Connect(iface, SIGNAL("message(QString,QString)"), this, SLOT("messageSlot(QString,QString)"));
        QDBusConnection.SessionBus().Connect("", "", "com.trolltech.chat", "message", this, SLOT("MessageSlot(QString,QString)"));
        Connect(iface, SIGNAL("Action(QString,QString)"), this, SLOT("ActionSlot(QString,QString)"));
    
        NicknameDialog dialog = new NicknameDialog();
        dialog.m_ui.cancelButton.SetVisible(false);
        dialog.Exec();
        m_nickname = dialog.m_ui.nickname.Text.Trim();
        Emit.Action(m_nickname, "joins the chat");
    }
    
    void RebuildHistory()
    {
        StringBuilder history = new StringBuilder();
        foreach(string element in m_messages) {
            history.Append(element + "\n");
        }
        m_ui.chatHistory.PlainText = history.ToString();
    }
    
    [Q_SLOT]
    void MessageSlot(string nickname, string text)
    {
        string msg = "<" + nickname + "> " + text;
        m_messages.Add(msg);
    
        if (m_messages.Count > 100)
            m_messages.RemoveAt(0);
        RebuildHistory();
    }
    
    [Q_SLOT]
    void ActionSlot(string nickname, string text)
    {
        string msg = "* " + nickname + " " + text;
        m_messages.Add(msg);
    
        if (m_messages.Count > 100)
            m_messages.RemoveAt(0);
        RebuildHistory();
    }
    
    [Q_SLOT]
    void TextChangedSlot(string newText)
    {
        m_ui.sendButton.Enabled = !(newText == "");
    }
    
    [Q_SLOT]
    void SendClickedSlot()
    {
        //Emit.message(m_nickname, messageLineEdit.text());
        QDBusMessage msg = QDBusMessage.CreateSignal("/", "com.trolltech.chat", "message");
        msg.Write(new QVariant(m_nickname)).Write(new QVariant(m_ui.messageLineEdit.Text));
        QDBusConnection.SessionBus().Send(msg);
        m_ui.messageLineEdit.Text = "";
    }
    
    [Q_SLOT]
    void ChangeNickname()
    {
        NicknameDialog dialog = new NicknameDialog(this);
        if (dialog.Exec() == (int) QDialog.DialogCode.Accepted) {
            string old = m_nickname;
            m_nickname = dialog.m_ui.nickname.Text.Trim();
            Emit.Action(old, "is now known as " + m_nickname);
        }
    }
    
    [Q_SLOT]
    void AboutQt()
    {
        QMessageBox.AboutQt(this);
    }
    
    [Q_SLOT]
    void Exiting()
    {
        Emit.Action(m_nickname, "leaves the chat");
    }
    
    public static int Main(string[] args) {
        new QApplication(args);
    
        if (!QDBusConnection.SessionBus().IsConnected()) {
            Console.Write("Cannot connect to the D-BUS session bus.\n" +
                     "Please check your system settings and try again.\n");
            return 1;
        }
    
        ChatMainWindow chat = new ChatMainWindow();
        chat.Show();

        return QApplication.Exec();
    }

    protected new IChatMainWindowSignals Emit {
        get {
            return (IChatMainWindowSignals) Q_EMIT;
        }
    }
}

public interface IChatMainWindowSignals : IQMainWindowSignals {
    [Q_SIGNAL]
    void Message(string nickname, string text);

    [Q_SIGNAL]
    void Action(string nickname, string text);
}

public class NicknameDialog : QDialog {
    public Ui.NicknameDialog m_ui;

    public NicknameDialog() : this((QWidget) null) {}

    public NicknameDialog(QWidget parent) : base(parent)
    {
        m_ui = new Ui.NicknameDialog();
        m_ui.SetupUi(this);
    }
    
}
