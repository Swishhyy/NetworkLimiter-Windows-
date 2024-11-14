using System;

namespace NetworkLimit
{
    public static class Scheduler
    {
        /// <summary>
        /// Checks if the current time is within the scheduled start and end times.
        /// </summary>
        /// <param name="startTime">Start time in "HH:mm" format.</param>
        /// <param name="endTime">End time in "HH:mm" format.</param>
        /// <returns>True if within the scheduled time range; otherwise, false.</returns>
        public static bool IsWithinScheduledTime(string startTime, string endTime)
        {
            try
            {
                DateTime now = DateTime.Now;
                DateTime start = DateTime.Parse(startTime);
                DateTime end = DateTime.Parse(endTime);

                // Adjust the end time if it crosses midnight
                if (end < start)
                {
                    if (now.TimeOfDay >= start.TimeOfDay || now.TimeOfDay <= end.TimeOfDay)
                        return true;
                }
                else
                {
                    if (now.TimeOfDay >= start.TimeOfDay && now.TimeOfDay <= end.TimeOfDay)
                        return true;
                }

                return false;
            }
            catch (FormatException ex)
            {
                Logger.Log($"Scheduler error: Invalid time format. {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log($"Scheduler error: {ex.Message}");
                return false;
            }
        }
    }
}
