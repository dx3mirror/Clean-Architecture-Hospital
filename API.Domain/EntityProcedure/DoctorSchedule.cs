namespace API.Domain.EntityProcedure
{
    public class DoctorSchedule
    {
        public int ScheduleID { get; private set; }
        public DayOfWeek WorkDay { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }

        public DoctorSchedule(int scheduleID, DayOfWeek workDay, TimeSpan startTime, TimeSpan endTime)
        {
            ValidateArguments(scheduleID, startTime, endTime);

            ScheduleID = scheduleID;
            WorkDay = workDay;
            StartTime = startTime;
            EndTime = endTime;
        }

        private void ValidateArguments(int scheduleID, TimeSpan startTime, TimeSpan endTime)
        {
            if (scheduleID <= 0)
            {
                throw new ArgumentException("Schedule ID must be greater than zero.", nameof(scheduleID));
            }

            if (startTime >= endTime)
            {
                throw new ArgumentException("Start time must be earlier than end time.");
            }
        }

        public void UpdateSchedule(DayOfWeek workDay, TimeSpan startTime, TimeSpan endTime)
        {
            ValidateArguments(ScheduleID, startTime, endTime);

            WorkDay = workDay;
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
        {
            return $"Schedule ID: {ScheduleID}, Work Day: {WorkDay}, Start Time: {StartTime}, End Time: {EndTime}";
        }
    }

}
