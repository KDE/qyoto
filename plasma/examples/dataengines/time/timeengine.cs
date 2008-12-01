/*
 *   Copyright 2007 Aaron Seigo <aseigo@kde.org>
 *   Copyright 2008 Richard Dale <richard.j.dale@gmail.com>
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Library General Public License as
 *   published by the Free Software Foundation; either version 2 or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details
 *
 *   You should have received a copy of the GNU Library General Public
 *   License along with this program; if not, write to the
 *   Free Software Foundation, Inc.,
 *   51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 *   Converted to C# by Richard Dale
 */

using System;
using System.Collections.Generic;

using Qyoto;
using Kimono;
using Plasma;

/**
 * This engine provides the current date and time for a given
 * timezone.
 *
 * "Local" is a special source that is an alias for the current
 * timezone.
 */
public class TimeEngine : PlasmaScripting.DataEngine, IDisposable {
    private static string localName = "Local";

    public TimeEngine(DataEngineScript parent) : base(parent) {
        SetMinimumPollingInterval(333);

        // To have translated timezone names
        // (effectively a noop if the catalog is already present).
        KGlobal.Locale().InsertCatalog("timezones4");
    }

    public override void Init() {
        base.Init();
        //QDBusInterface *ktimezoned = new QDBusInterface("org.kde.kded", "/modules/ktimezoned", "org.kde.KTimeZoned");
        QDBusConnection dbus = QDBusConnection.SessionBus();
        dbus.Connect("", "", "org.kde.KTimeZoned", "configChanged", this, SLOT("updateAllSources()"));
    }

    public override List<string> Sources() {
        // To make this work a QMap<QString, KTimeZone> marshaller needs to 
        // be added to Kimono
        // List<string> timezones = new List<string>(KSystemTimeZones.Zones().Keys);

        List<string> timezones = new List<string>();
        timezones.Add("Local");
        return timezones;
    }

    public override bool SourceRequestEvent(string name) {
        return UpdateSourceEvent(name);
    }

    public override bool UpdateSourceEvent(string tz) {
        string timezone;
        if (tz == localName) {
            SetData(localName, "Time", QTime.CurrentTime());
            SetData(localName, "Date", QDate.CurrentDate());
            // this is relatively cheap - KSTZ::local() is cached
            timezone = KSystemTimeZones.Local().Name();
        } else {
            KTimeZone newTz = KSystemTimeZones.Zone(tz);
            if (!newTz.IsValid()) {
                return false;
            }

            KDateTime dt = KDateTime.CurrentDateTime(new KDateTime.Spec(newTz));
            SetData(tz, "Time", dt.Time());
            SetData(tz, "Date", dt.Date());
            timezone = tz;
        }

        string trTimezone = KDE.I18n(timezone);
        SetData(tz, "Timezone", trTimezone);
        string[] tzParts = trTimezone.Split(new char[] { '/' });

        SetData(tz, "Timezone Continent", tzParts[0]);
        SetData(tz, "Timezone City", tzParts[1]);

        return true;
    }
}

// kate: space-indent on; indent-width 4; replace-tabs on; mixed-indent off;
