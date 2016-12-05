using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IowLibrary {
    public class Log {
        private readonly List<LogEntry> _logs = new List<LogEntry>();

        public void AddLog(Device device, string msg, LogEntry.LogLevel level) {
            _logs.Add(LogEntry.NewLogEntry(device, msg, level));
        }

        public void AddEventLog(Device device, string msg) {
            _logs.Add(LogEntry.NewLogEntry(device, msg, LogEntry.LogLevel.Event));
        }

        public void AddErrorLog(Device device, string msg) {
            _logs.Add(LogEntry.NewLogEntry(device, msg, LogEntry.LogLevel.Error));
        }

        public List<LogEntry> GetAllLogEntries() {
            return _logs;
        }

        public List<LogEntry> GetLogEntrieyAtLevel(LogEntry.LogLevel level) {
            return _logs.Where(logEntry => logEntry.Level.Equals(level)).ToList();
        }

        public List<LogEntry> GetLogEntrysEvent() {
            return GetLogEntrieyAtLevel(LogEntry.LogLevel.Event);
        }

        public List<LogEntry> GetLogEntrysError() {
            return GetLogEntrieyAtLevel(LogEntry.LogLevel.Error);
        }

        public void ClearLog() {
            _logs.Clear();
        }

        public static Log NewInstance() {
            return new Log();
        }
    }

    public class LogEntry {
        public enum LogLevel {
            Event,
            Error
        };

        public string Message { get; set; }
        public Device Device { get; set; }
        public DateTime TimeStamp { get; set; }
        public LogLevel Level { get; set; }

        private LogEntry(Device device, string message, LogLevel level) {
            Message = message;
            Device = device;
            TimeStamp = DateTime.Now;
            Level = level;
        }

        public static LogEntry NewLogEntry(Device device, string message, LogLevel level) {
            return new LogEntry(device, message, level);
        }

        public override string ToString() {
            return "Device: " + Device.DeviceNumber + " - " + TimeStamp + " - " + Message;
        }
    }
}
