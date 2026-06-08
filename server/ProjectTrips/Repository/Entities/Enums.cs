using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public enum ItemType { Route, Place }
    public enum Accessibility
    {
        NotAccessible,        // לא נגיש בכלל
        Low,                  // נגישות נמוכה (מדרגות, שבילים קשים)
        Partial,              // נגישות חלקית
        WheelchairAccessible, // נגיש לכיסאות גלגלים
        FullyAccessible        // נגישות מלאה (כולל שירותים, חניה וכו')
    }
    public enum ContentType { Route, Place, DayTrip }
    public enum Difficulty { Easy, EasyMedium, Medium, MediumHard, Hard }
    public enum Role { User, Admin }
    public enum TravelMode
    {
        Walking,
        Car,
        Bike
    }
    //public enum RoutePointType
    //{
    //    Start,
    //    Instruction,
    //    ViewPoint,
    //    WaterSpot,
    //    RestArea,
    //    End
    //}

    public enum ApprovalStatus
    {
        Draft = 0,        // טיוטה
        Pending = 1,      // מחכה לאישור
        Approved = 2,     // מאושר
        Rejected = 3      // נדחה
    }

    public class Enums
    {
    }
}
