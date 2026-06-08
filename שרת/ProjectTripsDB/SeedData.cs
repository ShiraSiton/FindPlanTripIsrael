using Microsoft.EntityFrameworkCore;
using ProjectTripsDB.Models;
using Repository.Entities;

namespace ProjectTripsDB;

public static class SeedData
{
    public static async Task SeedAsync(ProjectTripsDataBase context)
    {
        // ==================== TYPES ====================
        if (!await context.Types.AnyAsync())
        {
            var types = new List<Repository.Entities.Type>
            {
                new Repository.Entities.Type { ContentType = ContentType.Route, TypeName = "שביל הליכה" },
                new Repository.Entities.Type { ContentType = ContentType.Route, TypeName = "שביל אופניים" },
                new Repository.Entities.Type { ContentType = ContentType.Route, TypeName = "שביל מים" },
                new Repository.Entities.Type { ContentType = ContentType.Place, TypeName = "תצפית" },
                new Repository.Entities.Type { ContentType = ContentType.Place, TypeName = "מעיין" },
                new Repository.Entities.Type { ContentType = ContentType.Place, TypeName = "מפל" },
                new Repository.Entities.Type { ContentType = ContentType.Place, TypeName = "חורבה" },
                new Repository.Entities.Type { ContentType = ContentType.Place, TypeName = "מוזיאון" },
                new Repository.Entities.Type { ContentType = ContentType.Place, TypeName = "גן לאומי" },
                new Repository.Entities.Type { ContentType = ContentType.Place, TypeName = "שמורת טבע" },
                new Repository.Entities.Type { ContentType = ContentType.Place, TypeName = "נקודת ענין" },
                new Repository.Entities.Type { ContentType = ContentType.Place, TypeName = "אתר ארכיאולוגי" },
                new Repository.Entities.Type { ContentType = ContentType.Place, TypeName = "יקב" },
                new Repository.Entities.Type { ContentType = ContentType.Place, TypeName = "מסעדה" },
                new Repository.Entities.Type { ContentType = ContentType.Place, TypeName = "חוף ים" },
                new Repository.Entities.Type { ContentType = ContentType.DayTrip, TypeName = "טבע ונופים" },
                new Repository.Entities.Type { ContentType = ContentType.DayTrip, TypeName = "היסטוריה ותרבות" },
                new Repository.Entities.Type { ContentType = ContentType.DayTrip, TypeName = "פעילות ספורט" },
                new Repository.Entities.Type { ContentType = ContentType.DayTrip, TypeName = "קולינריה" },
                new Repository.Entities.Type { ContentType = ContentType.DayTrip, TypeName = "משפחה" },
            };
            context.Types.AddRange(types);
            await context.save();
        }

        // ==================== REGIONS ====================
        if (!await context.Regions.AnyAsync())
        {
            var regions = new List<Region>
            {
                new Region { RegionName = "הגליל העליון" },
                new Region { RegionName = "הגליל התחתון" },
                new Region { RegionName = "רמת הגולן" },
                new Region { RegionName = "הכרמל" },
                new Region { RegionName = "עמק הירקון" },
                new Region { RegionName = "הסביבה" },
                new Region { RegionName = "השרון" },
                new Region { RegionName = "גוש דן" },
                new Region { RegionName = "יהודה ושומרון" },
                new Region { RegionName = "השפלה" },
                new Region { RegionName = "ירושלים והסביבה" },
                new Region { RegionName = "ים המלח והסביבה" },
                new Region { RegionName = "הנגב" },
                new Region { RegionName = "הר הנגב" },
                new Region { RegionName = "הכנרת והסביבה" },
                new Region { RegionName = "הערבה" },
                new Region { RegionName = "אילת והסביבה" },
            };
            context.Regions.AddRange(regions);
            await context.save();

            // Update parent regions after IDs are assigned
            var galilElyon = await context.Regions.FirstAsync(r => r.RegionName == "הגליל העליון");
            var galilTachton = await context.Regions.FirstAsync(r => r.RegionName == "הגליל התחתון");
            var harHanegev = await context.Regions.FirstAsync(r => r.RegionName == "הר הנגב");

            galilTachton.ParentRegionId = galilElyon.Id;
            galilElyon.ParentRegionId = null;
            harHanegev.ParentRegionId = (await context.Regions.FirstAsync(r => r.RegionName == "הנגב")).Id;
            await context.save();
        }

        // Get admin user
        var adminUser = context.Users.First(u => u.Email == "Admin@gmail.com");

        // ==================== PLACES ====================
        if (!await context.Places.AnyAsync())
        {
            var galilElyon = await context.Regions.FirstAsync(r => r.RegionName == "הגליל העליון");
            var galilTachton = await context.Regions.FirstAsync(r => r.RegionName == "הגליל התחתון");
            var kineret = await context.Regions.FirstAsync(r => r.RegionName == "הכנרת והסביבה");
            var golan = await context.Regions.FirstAsync(r => r.RegionName == "רמת הגולן");
            var carmel = await context.Regions.FirstAsync(r => r.RegionName == "הכרמל");
            var jerusalem = await context.Regions.FirstAsync(r => r.RegionName == "ירושלים והסביבה");
            var negev = await context.Regions.FirstAsync(r => r.RegionName == "הנגב");
            var yamm = await context.Regions.FirstAsync(r => r.RegionName == "ים המלח והסביבה");
            var eilat = await context.Regions.FirstAsync(r => r.RegionName == "אילת והסביבה");
            var sharon = await context.Regions.FirstAsync(r => r.RegionName == "השרון");
            var central = await context.Regions.FirstAsync(r => r.RegionName == "השפלה");

            var tatzpit = await context.Types.FirstAsync(t => t.TypeName == "תצפית");
            var mayaan = await context.Types.FirstAsync(t => t.TypeName == "מעיין");
            var himum = await context.Types.FirstAsync(t => t.TypeName == "מוזיאון");
            var shomeret = await context.Types.FirstAsync(t => t.TypeName == "שמורת טבע");
            var arch = await context.Types.FirstAsync(t => t.TypeName == "אתר ארכיאולוגי");
            var yekev = await context.Types.FirstAsync(t => t.TypeName == "יקב");
            var chof = await context.Types.FirstAsync(t => t.TypeName == "חוף ים");
            var npaka = await context.Types.FirstAsync(t => t.TypeName == "נקודת ענין");

            var places = new List<Place>
            {
                new Place { Name = "רכס בנטל", Description = "נקודת תצפית מרהיבה על החרמון והגולן", Latitude = 33.2833, Longitude = 35.4167, TypeId = tatzpit.Id, RegionId = galilElyon.Id, Accessibility = Accessibility.Low, Price = 0, OpeningTime = new TimeOnly(0, 0), ClosingTime = new TimeOnly(23, 59), AverageStayMinutes = 45, AverageRating = 4.8, RatingsCount = 156, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-30)), MinTemperature = -5, MaxTemperature = 25, AllowRain = false, HasCommonWeather = true },
                new Place { Name = "מעיין חיון", Description = "מעיין קריר עם בריכת שחיה טבעית", Latitude = 33.0333, Longitude = 35.2667, TypeId = mayaan.Id, RegionId = galilElyon.Id, Accessibility = Accessibility.WheelchairAccessible, Price = 0, OpeningTime = new TimeOnly(6, 0), ClosingTime = new TimeOnly(18, 0), AverageStayMinutes = 120, AverageRating = 4.6, RatingsCount = 289, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-25)), MinTemperature = 15, MaxTemperature = 35, AllowRain = true, HasCommonWeather = true },
                new Place { Name = "שמורת חוף הסלע", Description = "שמורת טבע ייחודית עם צוקים ומערות", Latitude = 33.0833, Longitude = 35.1167, TypeId = shomeret.Id, RegionId = galilElyon.Id, Accessibility = Accessibility.Low, Price = 0, OpeningTime = new TimeOnly(0, 0), ClosingTime = new TimeOnly(23, 59), AverageStayMinutes = 90, AverageRating = 4.5, RatingsCount = 178, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-20)), MinTemperature = 10, MaxTemperature = 30, AllowRain = false, HasCommonWeather = true },
                new Place { Name = "חוף גיא בן חנן", Description = "חוף ים פופולרי על חוף הכנרת", Latitude = 32.7914, Longitude = 35.5314, TypeId = chof.Id, RegionId = kineret.Id, Accessibility = Accessibility.FullyAccessible, Price = 25, OpeningTime = new TimeOnly(8, 0), ClosingTime = new TimeOnly(18, 0), AverageStayMinutes = 180, AverageRating = 4.3, RatingsCount = 445, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-15)), MinTemperature = 20, MaxTemperature = 38, AllowRain = false, HasCommonWeather = true },
                new Place { Name = "הר מירון", Description = "ההר הגבוה בגליל עם נוף פנורמי", Latitude = 33.0167, Longitude = 35.3833, TypeId = tatzpit.Id, RegionId = galilElyon.Id, Accessibility = Accessibility.Low, Price = 0, OpeningTime = new TimeOnly(0, 0), ClosingTime = new TimeOnly(23, 59), AverageStayMinutes = 60, AverageRating = 4.9, RatingsCount = 312, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)), MinTemperature = 0, MaxTemperature = 28, AllowRain = false, HasCommonWeather = true },
                new Place { Name = "ראש פינה", Description = "מושבה עתיקה עם סמטאות ציוריות וחנויות", Latitude = 32.9667, Longitude = 35.5333, TypeId = npaka.Id, RegionId = galilTachton.Id, Accessibility = Accessibility.WheelchairAccessible, Price = 0, OpeningTime = new TimeOnly(9, 0), ClosingTime = new TimeOnly(17, 0), AverageStayMinutes = 120, AverageRating = 4.7, RatingsCount = 567, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-28)), MinTemperature = 5, MaxTemperature = 32, AllowRain = true, HasCommonWeather = true },
                new Place { Name = "צפת העתיקה", Description = "עיר עתיקה עם אווירה ייחודית ומקומות קדושים", Latitude = 32.9667, Longitude = 35.5000, TypeId = npaka.Id, RegionId = galilTachton.Id, Accessibility = Accessibility.WheelchairAccessible, Price = 0, OpeningTime = new TimeOnly(0, 0), ClosingTime = new TimeOnly(23, 59), AverageStayMinutes = 180, AverageRating = 4.6, RatingsCount = 890, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-22)), MinTemperature = 2, MaxTemperature = 30, AllowRain = true, HasCommonWeather = true },
                new Place { Name = "יערות הכרמל", Description = "יער צפוף עם שבילי הליכה מסומנים", Latitude = 32.7000, Longitude = 35.0500, TypeId = shomeret.Id, RegionId = carmel.Id, Accessibility = Accessibility.WheelchairAccessible, Price = 0, OpeningTime = new TimeOnly(0, 0), ClosingTime = new TimeOnly(23, 59), AverageStayMinutes = 150, AverageRating = 4.5, RatingsCount = 234, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-18)), MinTemperature = 8, MaxTemperature = 33, AllowRain = true, HasCommonWeather = true },
                new Place { Name = "הר חרמונית", Description = "נקודת תצפית על החרמון והגולן", Latitude = 33.3000, Longitude = 35.7500, TypeId = tatzpit.Id, RegionId = golan.Id, Accessibility = Accessibility.Low, Price = 0, OpeningTime = new TimeOnly(0, 0), ClosingTime = new TimeOnly(23, 59), AverageStayMinutes = 45, AverageRating = 4.8, RatingsCount = 198, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-17)), MinTemperature = -8, MaxTemperature = 26, AllowRain = false, HasCommonWeather = true },
                new Place { Name = "מעיין הבשן", Description = "מעיין גדול בלב הגולן", Latitude = 32.9500, Longitude = 35.7167, TypeId = mayaan.Id, RegionId = golan.Id, Accessibility = Accessibility.FullyAccessible, Price = 0, OpeningTime = new TimeOnly(6, 0), ClosingTime = new TimeOnly(19, 0), AverageStayMinutes = 90, AverageRating = 4.4, RatingsCount = 167, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-12)), MinTemperature = 12, MaxTemperature = 34, AllowRain = true, HasCommonWeather = true },
                new Place { Name = "מכתש רמון", Description = "מכתש גדול ומרשים בנגב", Latitude = 30.6000, Longitude = 34.8000, TypeId = npaka.Id, RegionId = negev.Id, Accessibility = Accessibility.WheelchairAccessible, Price = 0, OpeningTime = new TimeOnly(0, 0), ClosingTime = new TimeOnly(23, 59), AverageStayMinutes = 90, AverageRating = 4.9, RatingsCount = 789, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-20)), MinTemperature = 15, MaxTemperature = 40, AllowRain = false, HasCommonWeather = true },
                new Place { Name = "מצדה", Description = "אתר מורשת עולמית על הר בולט", Latitude = 31.3158, Longitude = 35.3538, TypeId = arch.Id, RegionId = yamm.Id, Accessibility = Accessibility.Partial, Price = 28, OpeningTime = new TimeOnly(8, 0), ClosingTime = new TimeOnly(17, 0), AverageStayMinutes = 240, AverageRating = 4.9, RatingsCount = 1234, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-30)), MinTemperature = 18, MaxTemperature = 42, AllowRain = false, HasCommonWeather = true },
                new Place { Name = "שמורת עין גדי", Description = "שמורת טבע עם נאותות וצמחייה ייחודית", Latitude = 31.4333, Longitude = 35.3500, TypeId = shomeret.Id, RegionId = yamm.Id, Accessibility = Accessibility.Low, Price = 0, OpeningTime = new TimeOnly(6, 0), ClosingTime = new TimeOnly(16, 0), AverageStayMinutes = 120, AverageRating = 4.8, RatingsCount = 567, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-9)), MinTemperature = 20, MaxTemperature = 40, AllowRain = false, HasCommonWeather = true },
                new Place { Name = "שמורת רואו", Description = "שמורת טבע ימית עם אלמוגים", Latitude = 29.5000, Longitude = 34.9167, TypeId = shomeret.Id, RegionId = eilat.Id, Accessibility = Accessibility.FullyAccessible, Price = 50, OpeningTime = new TimeOnly(9, 0), ClosingTime = new TimeOnly(16, 0), AverageStayMinutes = 180, AverageRating = 4.8, RatingsCount = 678, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-15)), MinTemperature = 22, MaxTemperature = 42, AllowRain = false, HasCommonWeather = true },
                new Place { Name = "הר גרופית", Description = "נקודת תצפית פנורמית באילת", Latitude = 29.5500, Longitude = 34.9500, TypeId = tatzpit.Id, RegionId = eilat.Id, Accessibility = Accessibility.WheelchairAccessible, Price = 0, OpeningTime = new TimeOnly(0, 0), ClosingTime = new TimeOnly(23, 59), AverageStayMinutes = 60, AverageRating = 4.5, RatingsCount = 234, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)), MinTemperature = 20, MaxTemperature = 40, AllowRain = false, HasCommonWeather = true },
                new Place { Name = "גן לאומי קיסריה", Description = "פארק עם שרידים היסטוריים וחוף ים", Latitude = 32.5000, Longitude = 34.9000, TypeId = himum.Id, RegionId = central.Id, Accessibility = Accessibility.FullyAccessible, Price = 35, OpeningTime = new TimeOnly(8, 0), ClosingTime = new TimeOnly(18, 0), AverageStayMinutes = 180, AverageRating = 4.6, RatingsCount = 890, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-20)), MinTemperature = 15, MaxTemperature = 34, AllowRain = false, HasCommonWeather = true },
                new Place { Name = "יקב רמת הנגב", Description = "יקב בוטיק עם טעימות", Latitude = 31.2500, Longitude = 34.7500, TypeId = yekev.Id, RegionId = negev.Id, Accessibility = Accessibility.FullyAccessible, Price = 60, OpeningTime = new TimeOnly(10, 0), ClosingTime = new TimeOnly(18, 0), AverageStayMinutes = 90, AverageRating = 4.6, RatingsCount = 234, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-9)), MinTemperature = 18, MaxTemperature = 38, AllowRain = false, HasCommonWeather = true },
                new Place { Name = "חוף פולג", Description = "חוף ים יפה בנתניה", Latitude = 32.3000, Longitude = 34.8500, TypeId = chof.Id, RegionId = sharon.Id, Accessibility = Accessibility.FullyAccessible, Price = 25, OpeningTime = new TimeOnly(7, 0), ClosingTime = new TimeOnly(19, 0), AverageStayMinutes = 180, AverageRating = 4.5, RatingsCount = 789, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-5)), MinTemperature = 18, MaxTemperature = 34, AllowRain = false, HasCommonWeather = true },
            };
            context.Places.AddRange(places);
            await context.save();
        }

        // ==================== ROUTES ====================
        if (!await context.Routes.AnyAsync())
        {
            var galilElyon = await context.Regions.FirstAsync(r => r.RegionName == "הגליל העליון");
            var galilTachton = await context.Regions.FirstAsync(r => r.RegionName == "הגליל התחתון");
            var kineret = await context.Regions.FirstAsync(r => r.RegionName == "הכנרת והסביבה");
            var golan = await context.Regions.FirstAsync(r => r.RegionName == "רמת הגולן");
            var carmel = await context.Regions.FirstAsync(r => r.RegionName == "הכרמל");
            var jerusalem = await context.Regions.FirstAsync(r => r.RegionName == "ירושלים והסביבה");
            var yamm = await context.Regions.FirstAsync(r => r.RegionName == "ים המלח והסביבה");
            var negev = await context.Regions.FirstAsync(r => r.RegionName == "הנגב");

            var sevilHalechiya = await context.Types.FirstAsync(t => t.TypeName == "שביל הליכה");
            var sevilOfnayim = await context.Types.FirstAsync(t => t.TypeName == "שביל אופניים");
            var sevilMayim = await context.Types.FirstAsync(t => t.TypeName == "שביל מים");

            var routes = new List<Route>
            {
                new Route { Name = "שביל הגולן", Description = "שביל הליכה ברמת הגולן", TypeId = sevilHalechiya.Id, RegionId = golan.Id, Accessibility = Accessibility.Low, Difficulty = Difficulty.Medium, LengthKm = 12, DurationMinutes = 240, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-20)), HasCommonWeather = true },
                new Route { Name = "שביל הכנרת", Description = "שביל הליכה סביב הכנרת", TypeId = sevilHalechiya.Id, RegionId = kineret.Id, Accessibility = Accessibility.WheelchairAccessible, Difficulty = Difficulty.Easy, LengthKm = 8, DurationMinutes = 180, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-18)), HasCommonWeather = true },
                new Route { Name = "שביל הכרמל", Description = "שביל הליכה ביערות הכרמל", TypeId = sevilHalechiya.Id, RegionId = carmel.Id, Accessibility = Accessibility.Low, Difficulty = Difficulty.Medium, LengthKm = 10, DurationMinutes = 210, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-15)), HasCommonWeather = true },
                new Route { Name = "שביל הנחלים", Description = "שביל הליכה בנחלי הנגב", TypeId = sevilHalechiya.Id, RegionId = negev.Id, Accessibility = Accessibility.Low, Difficulty = Difficulty.MediumHard, LengthKm = 15, DurationMinutes = 300, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-12)), HasCommonWeather = true },
                new Route { Name = "שביל ירושלים", Description = "שביל הליכה בירושלים העתיקה", TypeId = sevilHalechiya.Id, RegionId = jerusalem.Id, Accessibility = Accessibility.Partial, Difficulty = Difficulty.EasyMedium, LengthKm = 5, DurationMinutes = 120, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)), HasCommonWeather = true },
                new Route { Name = "שביל אופניים גליל", Description = "שביל אופניים בגליל העליון", TypeId = sevilOfnayim.Id, RegionId = galilElyon.Id, Accessibility = Accessibility.WheelchairAccessible, Difficulty = Difficulty.Medium, LengthKm = 25, DurationMinutes = 180, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-8)), HasCommonWeather = true },
                new Route { Name = "שביל מים ברמה", Description = "שביל מים בנחלי הגליל", TypeId = sevilMayim.Id, RegionId = galilTachton.Id, Accessibility = Accessibility.Low, Difficulty = Difficulty.MediumHard, LengthKm = 6, DurationMinutes = 120, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-6)), HasCommonWeather = true },
                new Route { Name = "שביל מצדה", Description = "שביל עולה למצדה", TypeId = sevilHalechiya.Id, RegionId = yamm.Id, Accessibility = Accessibility.Low, Difficulty = Difficulty.Hard, LengthKm = 4, DurationMinutes = 120, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-4)), HasCommonWeather = true },
            };
            context.Routes.AddRange(routes);
            await context.save();
        }

        // ==================== DAY TRIPS ====================
        if (!await context.DayTrips.AnyAsync())
        {
            var galilElyon = await context.Regions.FirstAsync(r => r.RegionName == "הגליל העליון");
            var galilTachton = await context.Regions.FirstAsync(r => r.RegionName == "הגליל התחתון");
            var kineret = await context.Regions.FirstAsync(r => r.RegionName == "הכנרת והסביבה");
            var golan = await context.Regions.FirstAsync(r => r.RegionName == "רמת הגולן");
            var carmel = await context.Regions.FirstAsync(r => r.RegionName == "הכרמל");
            var jerusalem = await context.Regions.FirstAsync(r => r.RegionName == "ירושלים והסביבה");
            var yamm = await context.Regions.FirstAsync(r => r.RegionName == "ים המלח והסביבה");
            var negev = await context.Regions.FirstAsync(r => r.RegionName == "הנגב");
            var eilat = await context.Regions.FirstAsync(r => r.RegionName == "אילת והסביבה");
            var sharon = await context.Regions.FirstAsync(r => r.RegionName == "השרון");
            var central = await context.Regions.FirstAsync(r => r.RegionName == "השפלה");
            var harHanegev = await context.Regions.FirstAsync(r => r.RegionName == "הר הנגב");

            var tevaVenofim = await context.Types.FirstAsync(t => t.TypeName == "טבע ונופים");
            var history = await context.Types.FirstAsync(t => t.TypeName == "היסטוריה ותרבות");
            var sport = await context.Types.FirstAsync(t => t.TypeName == "פעילות ספורט");
            var kolineria = await context.Types.FirstAsync(t => t.TypeName == "קולינריה");
            var family = await context.Types.FirstAsync(t => t.TypeName == "משפחה");

            var dayTrips = new List<DayTrip>
            {
                new DayTrip { Name = "יום בגליל העליון", Description = "טיול יום מלא בגליל העליון עם תצפיות וטבע", ImageUrl = "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800", TotalDurationHours = 8, TotalLengthKM = 50, TypeId = tevaVenofim.Id, RegionId = galilElyon.Id, Accessibility = Accessibility.Low, Difficulty = Difficulty.EasyMedium, Price = 0, StartTime = new TimeOnly(7, 0), EndTime = new TimeOnly(15, 0), HasCommonWeather = true, AverageRating = 4.7, RatingsCount = 234, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-30)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-25)), TripHash = "galil-north-001" },
                new DayTrip { Name = "מסלול הכנרת", Description = "טיול סביב הכנרת עם עצירות במקומות קדושים", ImageUrl = "https://images.unsplash.com/photo-1544735716-392fe2489ffa?w=800", TotalDurationHours = 6, TotalLengthKM = 40, TypeId = history.Id, RegionId = kineret.Id, Accessibility = Accessibility.WheelchairAccessible, Difficulty = Difficulty.Easy, Price = 0, StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(14, 0), HasCommonWeather = true, AverageRating = 4.8, RatingsCount = 456, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-25)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-20)), TripHash = "kineret-001" },
                new DayTrip { Name = "שביל הכרמל", Description = "טיול הליכה ביערות הכרמל", ImageUrl = "https://images.unsplash.com/photo-1441974231531-c6227db76b6e?w=800", TotalDurationHours = 5, TotalLengthKM = 12, TypeId = sport.Id, RegionId = carmel.Id, Accessibility = Accessibility.Low, Difficulty = Difficulty.Medium, Price = 0, StartTime = new TimeOnly(7, 30), EndTime = new TimeOnly(12, 30), HasCommonWeather = true, AverageRating = 4.5, RatingsCount = 178, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-20)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-15)), TripHash = "carmel-001" },
                new DayTrip { Name = "גולן ותצפיות", Description = "טיול ברמת הגולן עם תצפיות פנורמיות", ImageUrl = "https://images.unsplash.com/photo-1469854523086-cc02fe5d8800?w=800", TotalDurationHours = 7, TotalLengthKM = 80, TypeId = tevaVenofim.Id, RegionId = golan.Id, Accessibility = Accessibility.WheelchairAccessible, Difficulty = Difficulty.Easy, Price = 0, StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(15, 0), HasCommonWeather = true, AverageRating = 4.9, RatingsCount = 567, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-18)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-13)), TripHash = "golan-001" },
                new DayTrip { Name = "טעמים מהגליל", Description = "טיול קולינרי בגליל עם ביקור ביקבים ומטעים", ImageUrl = "https://images.unsplash.com/photo-1504674900247-0877df9cc836?w=800", TotalDurationHours = 6, TotalLengthKM = 60, TypeId = kolineria.Id, RegionId = galilTachton.Id, Accessibility = Accessibility.FullyAccessible, Difficulty = Difficulty.Easy, Price = 150, StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(15, 0), HasCommonWeather = true, AverageRating = 4.6, RatingsCount = 234, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-15)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)), TripHash = "galil-food-001" },
                new DayTrip { Name = "קיסריה והיסטוריה", Description = "טיול היסטורי בקיסריה", ImageUrl = "https://images.unsplash.com/photo-1552832230-c0197dd311b5?w=800", TotalDurationHours = 5, TotalLengthKM = 10, TypeId = history.Id, RegionId = central.Id, Accessibility = Accessibility.FullyAccessible, Difficulty = Difficulty.Easy, Price = 50, StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(14, 0), HasCommonWeather = true, AverageRating = 4.5, RatingsCount = 345, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-22)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-17)), TripHash = "caesarea-001" },
                new DayTrip { Name = "טבע בשרון", Description = "טיול טבע בשרון עם נחלים", ImageUrl = "https://images.unsplash.com/photo-1433086966358-54859d0ed716?w=800", TotalDurationHours = 4, TotalLengthKM = 8, TypeId = tevaVenofim.Id, RegionId = sharon.Id, Accessibility = Accessibility.WheelchairAccessible, Difficulty = Difficulty.Easy, Price = 0, StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(12, 0), HasCommonWeather = true, AverageRating = 4.3, RatingsCount = 234, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-12)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-7)), TripHash = "sharon-001" },
                new DayTrip { Name = "יום משפחתי בפארק", Description = "טיול משפחתי עם פעילויות לילדים", ImageUrl = "https://images.unsplash.com/photo-1518173946687-a4c036bc4f5e?w=800", TotalDurationHours = 6, TotalLengthKM = 5, TypeId = family.Id, RegionId = central.Id, Accessibility = Accessibility.FullyAccessible, Difficulty = Difficulty.Easy, Price = 80, StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(15, 0), HasCommonWeather = true, AverageRating = 4.4, RatingsCount = 567, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-5)), TripHash = "family-park-001" },
                new DayTrip { Name = "ירושלים העתיקה", Description = "טיול בירושלים העתיקה והסביבה", ImageUrl = "https://images.unsplash.com/photo-1547190994-4e494a1b0e93?w=800", TotalDurationHours = 6, TotalLengthKM = 6, TypeId = history.Id, RegionId = jerusalem.Id, Accessibility = Accessibility.Partial, Difficulty = Difficulty.EasyMedium, Price = 40, StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(14, 0), HasCommonWeather = true, AverageRating = 4.8, RatingsCount = 890, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-28)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-23)), TripHash = "jerusalem-001" },
                new DayTrip { Name = "מדבר יהודה", Description = "טיול במדבר יהודה ונאותות", ImageUrl = "https://images.unsplash.com/photo-1509316785289-025f5b846b35?w=800", TotalDurationHours = 5, TotalLengthKM = 15, TypeId = tevaVenofim.Id, RegionId = yamm.Id, Accessibility = Accessibility.Low, Difficulty = Difficulty.Medium, Price = 30, StartTime = new TimeOnly(7, 0), EndTime = new TimeOnly(12, 0), HasCommonWeather = true, AverageRating = 4.7, RatingsCount = 456, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-16)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-11)), TripHash = "mideast-001" },
                new DayTrip { Name = "מצדה שחרית", Description = "טיול בוקר למצדה עם זריחה", ImageUrl = "https://images.unsplash.com/photo-1552074284-5e88ef1aef18?w=800", TotalDurationHours = 4, TotalLengthKM = 4, TypeId = history.Id, RegionId = yamm.Id, Accessibility = Accessibility.Low, Difficulty = Difficulty.Hard, Price = 50, StartTime = new TimeOnly(4, 0), EndTime = new TimeOnly(8, 0), HasCommonWeather = true, AverageRating = 4.9, RatingsCount = 678, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-14)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-9)), TripHash = "masada-sunrise-001" },
                new DayTrip { Name = "מכתש רמון וסביבה", Description = "טיול במכתש רמון והסביבה", ImageUrl = "https://images.unsplash.com/photo-1469474968028-56623f02e42e?w=800", TotalDurationHours = 6, TotalLengthKM = 40, TypeId = tevaVenofim.Id, RegionId = negev.Id, Accessibility = Accessibility.WheelchairAccessible, Difficulty = Difficulty.Easy, Price = 0, StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(14, 0), HasCommonWeather = true, AverageRating = 4.8, RatingsCount = 567, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-20)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-15)), TripHash = "mitzpe-ramon-001" },
                new DayTrip { Name = "הר הנגב", Description = "טיול בהר הנגב עם נופים מרהיבים", ImageUrl = "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800", TotalDurationHours = 5, TotalLengthKM = 20, TypeId = tevaVenofim.Id, RegionId = harHanegev.Id, Accessibility = Accessibility.Low, Difficulty = Difficulty.Medium, Price = 0, StartTime = new TimeOnly(6, 0), EndTime = new TimeOnly(11, 0), HasCommonWeather = true, AverageRating = 4.5, RatingsCount = 189, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-6)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-1)), TripHash = "negev-mountain-001" },
                new DayTrip { Name = "טעמי הנגב", Description = "טיול קולינרי בנגב עם ביקור ביקבים", ImageUrl = "https://images.unsplash.com/photo-1504674900247-0877df9cc836?w=800", TotalDurationHours = 5, TotalLengthKM = 50, TypeId = kolineria.Id, RegionId = negev.Id, Accessibility = Accessibility.FullyAccessible, Difficulty = Difficulty.Easy, Price = 180, StartTime = new TimeOnly(10, 0), EndTime = new TimeOnly(15, 0), HasCommonWeather = true, AverageRating = 4.7, RatingsCount = 234, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-12)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-7)), TripHash = "negev-food-001" },
                new DayTrip { Name = "שמורת רואו", Description = "שנירקלינג בשמורת רואו", ImageUrl = "https://images.unsplash.com/photo-1544551763-46a013bb70d5?w=800", TotalDurationHours = 4, TotalLengthKM = 5, TypeId = sport.Id, RegionId = eilat.Id, Accessibility = Accessibility.FullyAccessible, Difficulty = Difficulty.Easy, Price = 80, StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(13, 0), HasCommonWeather = true, AverageRating = 4.9, RatingsCount = 890, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-18)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-13)), TripHash = "rovat-001" },
                new DayTrip { Name = "אילת והסביבה", Description = "טיול באילת והר גרופית", ImageUrl = "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?w=800", TotalDurationHours = 5, TotalLengthKM = 30, TypeId = tevaVenofim.Id, RegionId = eilat.Id, Accessibility = Accessibility.WheelchairAccessible, Difficulty = Difficulty.Easy, Price = 0, StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(13, 0), HasCommonWeather = true, AverageRating = 4.6, RatingsCount = 456, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-14)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-9)), TripHash = "eilat-001" },
                new DayTrip { Name = "משפחה באילת", Description = "יום משפחתי באילת עם פעילויות", ImageUrl = "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?w=800", TotalDurationHours = 6, TotalLengthKM = 10, TypeId = family.Id, RegionId = eilat.Id, Accessibility = Accessibility.FullyAccessible, Difficulty = Difficulty.Easy, Price = 120, StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(15, 0), HasCommonWeather = true, AverageRating = 4.7, RatingsCount = 678, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-5)), TripHash = "family-eilat-001" },
                new DayTrip { Name = "עמק הירקון", Description = "טיול בעמק הירקון עם מעיינות", ImageUrl = "https://images.unsplash.com/photo-1433086966358-54859d0ed716?w=800", TotalDurationHours = 4, TotalLengthKM = 10, TypeId = tevaVenofim.Id, RegionId = galilTachton.Id, Accessibility = Accessibility.FullyAccessible, Difficulty = Difficulty.Easy, Price = 0, StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(12, 0), HasCommonWeather = true, AverageRating = 4.4, RatingsCount = 345, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-8)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-3)), TripHash = "yarkon-001" },
                new DayTrip { Name = "צפת והסביבה", Description = "טיול בצפת וסביבתה", ImageUrl = "https://images.unsplash.com/photo-1516483638261-f4dbaf036963?w=800", TotalDurationHours = 5, TotalLengthKM = 15, TypeId = history.Id, RegionId = galilTachton.Id, Accessibility = Accessibility.WheelchairAccessible, Difficulty = Difficulty.Easy, Price = 0, StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(14, 0), HasCommonWeather = true, AverageRating = 4.7, RatingsCount = 567, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-16)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-11)), TripHash = "tzfat-001" },
                new DayTrip { Name = "שמורת הכרמל", Description = "טיול בשמורת הכרמל", ImageUrl = "https://images.unsplash.com/photo-1441974231531-c6227db76b6e?w=800", TotalDurationHours = 5, TotalLengthKM = 12, TypeId = tevaVenofim.Id, RegionId = carmel.Id, Accessibility = Accessibility.WheelchairAccessible, Difficulty = Difficulty.EasyMedium, Price = 0, StartTime = new TimeOnly(7, 0), EndTime = new TimeOnly(12, 0), HasCommonWeather = true, AverageRating = 4.7, RatingsCount = 456, CreatedByUserId = adminUser.Id, CreatedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-10)), ApprovalStatus = ApprovalStatus.Approved, ApprovedAt = DateOnly.FromDateTime(DateTime.Today.AddDays(-5)), TripHash = "carmel-reserve-001" },
            };
            context.DayTrips.AddRange(dayTrips);
            await context.save();
        }

        // ==================== DAY TRIP ITEMS ====================
        if (!await context.DayTripItems.AnyAsync())
        {
            var places = await context.Places.ToListAsync();
            var routes = await context.Routes.ToListAsync();
            var dayTrips = await context.DayTrips.ToListAsync();

            if (places.Any() && dayTrips.Any())
            {
                var dayTripItems = new List<DayTripItem>();

                // Add items for first few day trips
                var dt1 = dayTrips.FirstOrDefault(d => d.TripHash == "galil-north-001");
                if (dt1 != null && places.Count >= 3)
                {
                    dayTripItems.Add(new DayTripItem { DayTripId = dt1.Id, ItemType = ItemType.Place, PlaceId = places[4].Id, OrderInTrip = 1, EstimatedDuration = 60, Mode = TravelMode.Car });
                    dayTripItems.Add(new DayTripItem { DayTripId = dt1.Id, ItemType = ItemType.Place, PlaceId = places[0].Id, OrderInTrip = 2, EstimatedDuration = 45, Mode = TravelMode.Car });
                    dayTripItems.Add(new DayTripItem { DayTripId = dt1.Id, ItemType = ItemType.Place, PlaceId = places[1].Id, OrderInTrip = 3, EstimatedDuration = 120, Mode = TravelMode.Car });
                }

                var dt2 = dayTrips.FirstOrDefault(d => d.TripHash == "kineret-001");
                if (dt2 != null)
                {
                    var kineretPlace = places.FirstOrDefault(p => p.Name.Contains("גיא בן חנן"));
                    if (kineretPlace != null)
                    {
                        var golanRoute = routes.FirstOrDefault(r => r.Name.Contains("כנרת"));
                        dayTripItems.Add(new DayTripItem { DayTripId = dt2.Id, ItemType = ItemType.Place, PlaceId = kineretPlace.Id, OrderInTrip = 1, EstimatedDuration = 180, Mode = TravelMode.Car });
                        if (golanRoute != null)
                        {
                            dayTripItems.Add(new DayTripItem { DayTripId = dt2.Id, ItemType = ItemType.Route, RouteId = golanRoute.Id, OrderInTrip = 2, EstimatedDuration = 180, Mode = TravelMode.Walking });
                        }
                    }
                }

                var dt3 = dayTrips.FirstOrDefault(d => d.TripHash == "carmel-001");
                if (dt3 != null && routes.Any())
                {
                    var carmelRoute = routes.FirstOrDefault(r => r.Name == "שביל הכרמל");
                    if (carmelRoute != null)
                    {
                        dayTripItems.Add(new DayTripItem { DayTripId = dt3.Id, ItemType = ItemType.Route, RouteId = carmelRoute.Id, OrderInTrip = 1, EstimatedDuration = 210, Mode = TravelMode.Walking });
                    }
                }

                if (dayTripItems.Any())
                {
                    context.DayTripItems.AddRange(dayTripItems);
                    await context.save();
                }
            }
        }

        // ==================== IMAGES ====================
        if (!await context.Images.AnyAsync())
        {
            var places = await context.Places.ToListAsync();
            if (places.Any())
            {
                var images = places.Take(10).Select((p, i) => new Image
                {
                    ItemType = ItemType.Place,
                    PlaceId = p.Id,
                    ImageUrl = $"https://images.unsplash.com/photo-{1500000000000 + i}?w=800",
                    IsMain = true,
                    CreatedByUserId = adminUser.Id,
                    CreatedAt = DateOnly.FromDateTime(DateTime.Today)
                }).ToList();

                context.Images.AddRange(images);
                await context.save();
            }
        }
    }
}

