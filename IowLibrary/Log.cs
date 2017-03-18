using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roboter {
    /// <summary>
    /// LogHandler for the Libary
    /// </summary>
    /// <author>M. Vervoorst junk@edlly.de</author>
    public class Log {
        private readonly List<LogEntry> _logs = new List<LogEntry>();

        /// <summary>
        /// Add new LogEntry for a Device
        /// </summary>
        /// <param name="device">device</param>
        /// <param name="msg">log entry</param>
        /// <param name="level">log level</param>
        /// <returns>instance of this</returns>
        public Log AddLog(Device device, string msg, LogEntry.LogLevel level) {
            _logs.Add(LogEntry.NewLogEntry(device, msg, level));
            return this;
        }

        /// <summary>
        /// Adds new addventlog entry
        /// </summary>
        /// <param name="device">device</param>
        /// <param name="msg">log entry</param>
        /// <returns>instance of this</returns>
        public Log AddEventLog(Device device, string msg) {
            _logs.Add(LogEntry.NewLogEntry(device, msg, LogEntry.LogLevel.Event));
            return this;
        }


        /// <summary>
        /// Adds new Error log entry
        /// </summary>
        /// <param name="device">device</param>
        /// <param name="msg">log entry</param>
        /// <returns>instance of this</returns>
        public Log AddErrorLog(Device device, string msg) {
            _logs.Add(LogEntry.NewLogEntry(device, msg, LogEntry.LogLevel.Error));
            return this;
        }

        /// <summary>
        /// Retuns all Log entries holds in object
        /// </summary>
        /// <returns>List of Log Entries</returns>
        public List<LogEntry> GetAllLogEntries() {
            return _logs;
        }

        /// <summary>
        /// Returns logs entry at the specified level
        /// </summary>
        /// <param name="level">Log Level</param>
        /// <returns>List of log entry at Level</returns>
        public List<LogEntry> GetLogEntrieyAtLevel(LogEntry.LogLevel level) {
            return _logs.Where(logEntry => logEntry.Level.Equals(level)).ToList();
        }

        /// <summary>
        /// Returns events log entries
        /// </summary>
        /// <returns>List of log entry at Level</returns>
        public List<LogEntry> GetLogEntrysEvent() {
            return GetLogEntrieyAtLevel(LogEntry.LogLevel.Event);
        }

        /// <summary>
        /// Returns events log entries and reset cache
        /// </summary>
        /// <returns>List of log entry at Level</returns>
        public List<LogEntry> GetLogEntrysEventAndReset() {
            var list = GetLogEntrieyAtLevel(LogEntry.LogLevel.Event);
            ClearLog();
            return list;
        }

        /// <summary>
        /// Returns error log entries
        /// </summary>
        /// <returns>List of log entry at Level</returns>
        public List<LogEntry> GetLogEntrysError() {
            return GetLogEntrieyAtLevel(LogEntry.LogLevel.Error);
        }

        /// <summary>
        /// Returns error log entries and reset Log Cache
        /// </summary>
        /// <returns>List of log entry at Level</returns>
        public List<LogEntry> GetLogEntrysErrorAndReset() {
            var logs = GetLogEntrieyAtLevel(LogEntry.LogLevel.Error);
            ClearLog();
            return logs;
        }
        /// <summary>
        /// Clears the Log
        /// </summary>
        public void ClearLog() {
            _logs.Clear();
        }

        /// <summary>
        ///  Returns a new Instacne of this Class
        /// </summary>
        /// <returns>Log instance</returns>
        public static Log NewInstance() {
            return new Log();
        }

        /// <summary>
        /// Puts an List of Logs to this Instance an sort them
        /// TODO sort function
        /// </summary>
        /// <param name="logList">list of logs to add</param>
        public void AddList(List<LogEntry> logList) {
            _logs.AddRange(logList);
        }
    }

    /// <summary>
    /// Data Class for Logs Entry
    /// </summary>
    public class LogEntry {
        /// <summary>
        /// Level of Logs
        /// </summary>
        public enum LogLevel {
            /// <summary>
            /// Event Level
            /// </summary>
            Event = 0,

            /// <summary>
            /// Error Level
            /// </summary>
            Error = 1
        };

        /// <summary>
        /// Log Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// initiator device 
        /// </summary>
        public Device Device { get; set; }

        /// <summary>
        /// timestamp of even
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        ///  level of the event
        /// </summary>
        public LogLevel Level { get; set; }


        /// <summary>
        /// Generates a New Instance of LogEntry with given paramertes. 
        /// Set the timestamp to the current timestamp
        /// </summary>
        /// <param name="device">initiator device </param>
        /// <param name="message">Log Message</param>
        /// <param name="level">level of the event</param>
        /// <returns>new LogEntry instance</returns>
        public static LogEntry NewLogEntry(Device device, string message, LogLevel level) {
            return new LogEntry(device, message, level);
        }

        /// <summary>
        /// Converts Object to String
        /// </summary>
        /// <returns>String representation of object</returns>
        public override string ToString() {
            if (Device == null) {
                return TimeStamp + " - " + Message;
            }
            return TimeStamp + "Device: " + Device.DeviceNumber + " - " + " - " + Message;
        }

        private LogEntry(Device device, string message, LogLevel level) {
            Message = message;
            Device = device;
            TimeStamp = DateTime.Now;
            Level = level;
        }
    }
}
