using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpObjectIntro.Classes.Diary
{
    public class Diary
    {
        //Fields
        private List<DiaryEvent> diaryEvents = new List<DiaryEvent>();

        //Constructor
        public Diary(string name)
        {
            Name = name;
        }

        // Properties
        public string Name { get; private set; }

        public void AddEvent(DateOnly date, int hours, string description, string location, int minutes = 0, int duration = 60)
        {
            var time = new TimeOnly(hours, minutes);
            var diaryEvent = new DiaryEvent(date, time, minutes, description, location);
            diaryEvents.Add(diaryEvent);
        }

        public int CheckDiary(DateOnly date)
        {
            return diaryEvents.Count(diaryEvent => diaryEvent.Date == date);
        }

        // Add a new method called check morning events

        public int CheckMorningEvents(DateOnly date)
        {
            return diaryEvents.Count(diaryEvent => diaryEvent.Date == date && diaryEvent.IsMorning);
        }
        
    }
}
