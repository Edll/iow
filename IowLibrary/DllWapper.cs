﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Roboter {
    namespace DllWapper {
        /// <summary>
        /// Wapper for CodeMercs dll.
        /// </summary>
        /// <author>CodeMercs www.codemercs.com</author>
        ///<author>M. Vervoorst junk@edlly.de</author>

        public static class Defines {
            /// <summary>
            ///  IO-Warrior vendor and product IDs
            /// </summary>
            public const uint IowkitVendorId = 0x07c0;
            /// <summary>
            ///  IO-Warrior vendor and product IDs
            /// </summary>
            public const uint IowkitVid = IowkitVendorId;

            /// <summary>
            ///  IO-Warrior 24 Product ID
            /// </summary>
            public const int IowkitProductIdIow24 = 0x1501;

            /// <summary>
            ///  IO-Warrior 24 Product ID
            /// </summary>
            public const int IowkitPidIow24 = IowkitProductIdIow24;

            /// <summary>
            /// Report size
            /// </summary>
            public const int IowkitReportSize = 4;

            /// <summary>
            /// IOWKit 24 IO Size
            /// </summary>
            public const int Iowkit24IoReportSize = 3;

            /// <summary>
            /// Special Report Size
            /// </summary>
            public const int IowkitSpecialReportSize = 8;

            /// <summary>
            ///  Max number of pipes per IOW device
            /// </summary>
            public const uint IowkitMaxPipex = 2;

            /// <summary>
            /// I/O Pipe
            /// </summary>
            public const int IowPipeIoPins = 0;

            /// <summary>
            /// Special Mode Pipe
            /// </summary>
            public const int IowPipeSpecialMode = 1;

            /// <summary>
            /// Max number of IOW devices in system
            /// </summary>
            public const uint IowkitMaxDevices = 16;
            /// <summary>
            /// Drive start numbering at
            /// </summary>
            public const int IowkitStartNumbering = 1;

            /// <summary>
            /// IOW Legacy devices open modes
            /// </summary>
            public const uint IowOpenSimple = 1;
            /// <summary>
            /// IOW Legacy devices open modes
            /// </summary>
            public const uint IowOpenComplex = 2;

            /// <summary>
            ///  first IO-Warrior revision with serial numbers
            /// </summary>
            public const uint IowNonLegacyRevision = 0x1010;

            /// <summary>
            /// Maximum number of bit pro Port
            /// </summary>
            public const int MaxBitNumber = 7;

            /// <summary>
            /// Device Read Timeout
            /// </summary>
            public const int DeviceTimeout = 200;
        }


        static class Method {
            /// <summary>
            /// Die Metode IowKitOpenDevice öffnet alle am USB erkannten IO-Warrior-Bausteine
            /// und liefert ein Handle für den zuerst gefundenen IO-Warrior zurück.
            /// </summary>
            /// <returns>Handle für IO-Warrior oder null bei Misserfolg.</returns>
            [DllImport("iowkit.dll")]
            public static extern IntPtr IowKitOpenDevice();
            /// <summary>
            /// Die Methode IowKitCloseDevice schließt den IO-Warrior der durch das
            /// gegebene Handle kontrolliert wird.
            /// </summary>
            /// <param name="iowHandle">Gültiges Handle zum IO-Warrior.</param>
            [DllImport("iowkit.dll")]
            public static extern void IowKitCloseDevice(IntPtr iowHandle);
            /// <summary>
            /// Fordert die Produkt-Identität (PID) des IO-Warrior Bausteines ab,
            /// der durch das gegebene Handle kontrolliert wird.
            /// </summary>
            /// <param name="iowHandle">Gültiges Handle zum IO-Warrior.</param>
            [DllImport("iowkit.dll")]
            public static extern uint IowKitGetProductId(IntPtr iowHandle);
            /// <summary>
            /// Zählt und nummeriert die am USB angeschlossenen IO-Warrior Bausteine.
            /// </summary>
            /// <returns></returns>
            [DllImport("iowkit.dll")]
            public static extern uint IowKitGetNumDevs();
            /// <summary>
            /// Die Methode IowKitGetDeviceHandle arbeitet liefert zu dem Gerät mit
            /// der angegebenen Nummer ein gültiges Handle. Vorrausgesetzt, das Gerät
            /// mit der Nummer existiert.
            /// IowKitGetDeviceHandle funktioniert nur nach einem erfolgreichen Aufruf
            /// von IowKitDeviceOpen. Erst dann sind alle Bausteine nummeriert.
            /// </summary>
            /// <param name="numDevice">Nummer des zu öffnenden Gerätes.</param>
            /// <returns>Ein gültiges Handle für das Gerät oder 0 bei Misserfolg.</returns>
            [DllImport("iowkit.dll")]
            public static extern IntPtr IowKitGetDeviceHandle(uint numDevice);
            /// <summary>
            /// Liefert die Version der IoWarrior-Firmaware zurück. Die oberen 2 Byte sind immer 0.
            /// Es sind 4 Hex-Stellen gültig. Wäre die gegenwärtige Softwareversion 1.0.2.1 so wird
            /// 0x1021 zurückgegeben. Ältere IO-Warrior, die keine eigene Seriennummer haben, liefern
            /// eine Versionsnummer kleiner 1.0.1.0 zurück.
            /// </summary>
            /// <param name="iowHandle">Gültiges Handle zum IO-Warrior.</param>
            /// <returns>Die Softwareversion des IO-Warriors oder 0, wenn kein gültiges
            /// Handle übergeben wurde.</returns>
            [DllImport("iowkit.dll")]
            public static extern uint IowKitGetRevision(IntPtr iowHandle);
            /// <summary>
            /// Liest die Seriennummer aus dem durch ein gültiges Handle gesteuerten IO-Warrior
            /// heraus.
            /// </summary>
            /// <param name="iowHandle">Gültiges Handle zum IO-Warrior.</param>
            /// <param name="snTarget">Verweis auf ein Datenfeld, dass die Seriennummer speichert.
            /// Der Stringbuilder muss zuvor instanziert worden sein.</param>
            /// <returns>True, wenn die Seriennummer erfolgreich im angegebenen Datenfeld abgelegt
            /// werden konnte. False, wenn das Handle ungültig war, der IO-Warrior keine Seriennummer
            /// hat oder das Abspeichern der Nummer im übergebenen Ziel fehlgeschlagen ist.</returns>
            [DllImport("iowkit.dll", CharSet = CharSet.Unicode)]
            public static extern bool IowKitGetSerialNumber(IntPtr iowHandle,
                                                             StringBuilder snTarget);
            /// <summary>
            /// Liest Daten vom IO-Warrior. Die Funktion blockiert den aufrufenden Thread bis
            /// eine Änderung an den Eingängen des IO-Warriors durch den Baustein regisriert wird.
            /// Ein nicht blockierendes Lesen kann über den Aufruf von IowKitReadNonBlocking()
            /// erfolgen.
            /// Die Daten kommen in Form eines Reports an. Nähere Beschreibung der Reports ist
            /// im Datenblatt des jeweiligen IO-Warriors zu finden.
            /// </summary>
            /// <param name="iowHandle">Gültiges Handle zum IO-Warrior.</param>
            /// <param name="numPipe">Datenkanal, aus dem gelesen werden soll. Reicht von 0
            /// bis IOWKIT_MAX_PIPES-1</param>
            /// <param name="buffer">Ziel für Ablage der Daten.</param>
            /// <param name="length">Anzahl der einzulesenden Bytes.</param>
            /// <returns>Anzahl tatsächlich eingelesener Bytes oder 0 bei Misserfolg.</returns>
            [DllImport("iowkit.dll")]
            public static extern uint IowKitRead(IntPtr iowHandle,
                                                    uint numPipe,
                                                   byte[] buffer,
                                                    uint length);
            /// <summary>
            /// Liest Daten vom IO-Warrior. Der aufrufende Thread wird nicht blockiert, wenn
            /// keine Daten zur Verfügung stehen, also keine Änderung an den Eingängen des
            /// IO-Warriors stattgefunden hat.
            /// </summary>
            /// <param name="iowHandle">Gültiges Handle zum IO-Warrior.</param>
            /// <param name="numPipe">Datenkanal, aus dem gelesen werden soll. Reicht von 0
            /// bis IOWKIT_MAX_PIPES-1</param>
            /// <param name="buffer">Ziel für Ablage der Daten.</param>
            /// <param name="length">Anzahl der einzulesenden Bytes.</param>
            /// <returns>Anzahl tatsächlich eingelesener Bytes oder 0 bei Misserfolg.</returns>
            [DllImport("iowkit.dll")]
            public static extern uint IowKitReadNonBlocking(IntPtr iowHandle,
                                                               uint numPipe,
                                                               byte[] buffer,
                                                               uint length);
            /// <summary>
            /// Liest den Pinstatus der Eingänge des angeschlossenen IO-Warriors direkt aus.
            /// Die Funktion gibt True zurück, wenn zuvor eine Änderung an den Pins durch den
            /// Baustein registriert wurde. Gleichzeitig is im Ziel-Datenfeld ein Abbild der
            /// Eingänge als Wert verfügbar.
            /// Achtung!!: Diese Funktion arbeitet nicht mit dem IO-Warrior 56 zusammen. Der
            /// Baustein gibt mehr als 32-Bit zurück.
            /// </summary>
            /// <param name="iowHandle">Gültiges Handle zum IO-Warrior.</param>
            /// <param name="ioPinStatus">Ziel-Datenfeld für das Abspeichern der Pin-Zustände.</param>
            /// <returns>True bei Erfolg, False wenn keine neuen Daten erfasst wurden oder
            /// das übergebene Handle nicht funktioniert.</returns>
            [DllImport("iowkit.dll")]
            public static extern bool IowKitReadImmediate(IntPtr iowHandle,
                                                          byte[] ioPinStatus);
            /// <summary>
            /// Legt die Grenze für eine Zeitüberschreitung beim Lesezugriff auf den IO-Warrior fest.
            /// Ein Timeout während einer laufenden, noch nicht beendeten Leseaktion führt zu
            /// Datenverlust (Reports gehen verloren). IowKitRead() schlägt fehl, wenn nicht innerhalb
            /// der gegebenen Grenze Daten vom IO-Warrior eingelesen werden können.
            /// Bei Zeitüberschreitung müssen alle vor bis zu dem Zeitpunkt bereits gesendeten
            /// aber noch nicht ausgeführten Aktionen erneut übermittelt werden (z.B. I2C-Bus schreiben
            /// oder lesen).
            /// </summary>
            /// <param name="iowHandle">Gültiges Handle zum IO-Warrior.</param>
            /// <param name="timeout">Grenze für Zeitüberschreitung in Millisekunden. Empfohlen in
            /// der iowkit.dll-Beschreibung sind 1000ms oder mehr.</param>
            /// <returns>True bei Erfolg oder False bei Fehlschlag.</returns>
            [DllImport("iowkit.dll")]
            public static extern bool IowKitSetTimeout(IntPtr iowHandle,
                                                        uint timeout);

            /// <summary>
            /// Legt die Grenze für eine Zeitüberschreitung beim Schreibzugriff auf den IO-Warrior fest.
            /// IowKitWrite() schlägt fehl, wenn Daten nicht innerhalb der vorgegebenen Grenze geschrieben
            /// werden können. Schreibfehler sind untypisch. Verbindungen und Hardware näher prüfen,
            /// wenn Fehler auftreten.
            /// </summary>
            /// <param name="iowHandle">Gültiges Handle zum IO-Warrior.</param>
            /// <param name="timeout">Grenze für Zeitüberschreitung in Millisekunden. Empfohlen in
            /// der iowkit.dll-Beschreibung sind 1000ms oder mehr.</param>
            /// <returns>True bei Erfolg oder False bei Fehlschlag.</returns>
            [DllImport("iowkit.dll")]
            public static extern bool IowKitSetWriteTimeout(IntPtr iowHandle,
                                                             uint timeout);

            /// <summary>
            /// Beendet alle laufenden Datentransferaktionen auf dem angegebenen Datenkanal(Pipe).
            /// Der Einsatz dieser Methode erfordert im Regelfall einen eigenen Thread, da eine
            /// beipsielsweise laufende IowKitRead()-Funktion den aufrufenden Thread blockiert,
            /// bis eine Rückgabe empfangen werden konnte.
            /// </summary>
            /// <param name="iowHandle">Gültiges Handle zum IO-Warrior.</param>
            /// <param name="numPipe">Nummer des Datenkanals.</param>
            /// <returns>True bei Erfolg, sonst false.</returns>
            [DllImport("iowkit.dll")]
            public static extern bool IowKitCancelIo(IntPtr iowHandle,
                                                      uint numPipe);

            /// <summary>
            /// Schreibt "length" Bytes in den durch "numPipe" angegebenen Datenkanal des IO-Warriors.
            /// Wird etwas anderes als ein gültiger Report, bestehend aus einer korrekten Anzahl von
            /// Bytes und einer vom gewählten Datenkanal akzeptierten Report-ID, gesendet, schlägt
            /// die Funktion fehl.
            /// </summary>
            /// <param name="iowHandle">Gültiges Handle zum IO-Warrior.</param>
            /// <param name="numPipe">Datenkanal, der beschickt werden soll.</param>
            /// <param name="buffer">Puffer, der die zu schreibenden Daten bereistellt.</param>
            /// <param name="length">Anzahl zu schreibender Bytes.</param>
            /// <returns>Bei erfolgreicher Durchführung ist die Anzahl geschriebener =
            /// Anazahl zu schreibender Bytes.</returns>
            [DllImport("iowkit.dll")]
            public static extern uint IowKitWrite(IntPtr iowHandle,
                                                     uint numPipe,
                                                     byte[] buffer,
                                                     uint length);

            /// <summary>
            /// Gibt den Handle des Threads zurück, der zum Lesen der I/O-Pins des
            /// IO-Warriors genutzt wird. Linux nutzt keie Threads um die Funktionen
            /// des IO-Warriors einzubinden und gibt daher immer 0 zurück.
            /// </summary>
            /// <param name="iowHandle">Gültiges Handle zum IO-Warrior.</param>
            /// <returns>Handle für den laufenden Thread oder 0 bei Misserfolg.</returns>
            [DllImport("iowkit.dll")]
            public static extern IntPtr IowKitGetThreadHandle(IntPtr iowHandle);

            /// <summary>
            /// Gibt die Version der iowkit.dll als string zurück.
            /// </summary>
            /// <returns>String mit der Versionsangabe.</returns>
            [DllImport("iowkit.dll")]
            public static extern string IowKitVersion();

            /// <summary>
            /// Öffnet einen IOWarrior40 dessen Firmware Revision älter 1.0.1.0 ist. Diese
            /// Bausteine haben keine Seriennummer die ausgelesen werden kann.
            /// </summary>
            /// <param name="legacyOpenMode">Simple oder Complex-Mode.</param>
            /// <returns>True bei Erfolg sonst false.</returns>
            [DllImport("iowkit.dll")]
            public static extern bool IowKitSetLegacyOpenMode(uint legacyOpenMode);

            /// <summary>
            /// Liefert den zuletzt aufgetretenen Fehler zurück, der vom Kernel
            /// registriert worden ist.
            /// </summary>
            /// <returns>Bei Fehlerfall eine Zahl ungleich 0.</returns>
            [DllImport("kernel32.dll")]
            public static extern uint GetLastError();


        }
    }
}
