using System;
using System.Reflection;
using System.Collections.Generic;

using Monodoc;

using Qyoto;
using Kimono;

public class MySlave : KIO.SlaveBase {
	public MySlave(QByteArray protocol, QByteArray pool_sock, QByteArray app_sock)
		: base(protocol, pool_sock, app_sock)
	{
	}

	public static RootTree HelpTree = RootTree.LoadTree();

	public static string GetHtml(string url, Node n, out Node match) {
		match = null;
		if (url.StartsWith("edit:")) return null;
		
		string html = null;
		
		if (n != null && n.tree.HelpSource != null) {
			try {
				html = n.tree.HelpSource.GetText(url, out match);
			} catch {
				bool showInherited = SettingsHandler.Settings.ShowInheritedMembers;
				SettingsHandler.Settings.ShowInheritedMembers = false;
				html = n.tree.HelpSource.GetText(url, out match);
				SettingsHandler.Settings.ShowInheritedMembers = showInherited;
			}
		}
		
		if (html == null || html == "") {
			try {
				html = HelpTree.RenderUrl(url, out match);
			} catch {
				bool showInherited = SettingsHandler.Settings.ShowInheritedMembers;
				SettingsHandler.Settings.ShowInheritedMembers = false;
				html = HelpTree.RenderUrl(url, out match);
				SettingsHandler.Settings.ShowInheritedMembers = showInherited;
			}
		}
		
		return html;
	}

	public override void Get(KUrl url) {
		string docurl = url.ToString().Substring(9);
		if (docurl == string.Empty) {
			Redirection(new KUrl("monodoc:/root:/classlib"));
			Finished();
			return;
		}
		MimeType("application/xhtml+xml");
		Node n;
		try {
			string data = GetHtml(docurl, null, out n);
			if (data != null) {
				data = data.Replace("href=\"", "href=\"monodoc:/");
				Data(data);
			} else {
				Data("The requested url is not availible");
			}
		} catch {
			Data("The requested url is not availible");
		}
		Finished();
	}
}
