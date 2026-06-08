// src/redux/slices/tripsSlice.ts
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import type { PlanDataType } from '../../../pages/TripPlannerWizard';
import type { RecommendedTrip as TransformedRecommendedTrip } from '../../../services/trips.service';
import { getRecommendedTrips } from '../../../services/trips.service';

export interface RecommendedTrip {
  trip: TransformedRecommendedTrip['trip'];
  matchPercentage: number;
}

interface TripsState {
  trips: RecommendedTrip[];
  loading: boolean;
  error?: string;
}

const initialState: TripsState = {
  trips: [],
  loading: false,
  error: undefined,
};

interface ServerRecommendedTrip {
  trip: {
    id: number;
    name: string;
    description: string;
    totalDurationHours: number;
    totalLengthKM: number;
    difficulty: { id: number; name: string };
    accessibility: { id: number; name: string };
    region: { id: number; regionName: string };
    type: { id: number; typeName: string };
    price: number;
    averageRating: number | null;
    ratingsCount: number | null;
    stopsCount: number;
    dayTripItems: Array<{
      id: number;
      itemType: string;
      route: { name: string; description: string; lengthKm: number } | null;
      place: { name: string; description: string; imageUrl: string; averageStayMinutes: number } | null;
      orderInTrip: number;
      estimatedDuration: number;
      mode: string;
    }>;
  };
  matchPercentage: number;
}

function transformServerResponse(serverTrip: ServerRecommendedTrip): RecommendedTrip {
  const { trip, matchPercentage } = serverTrip;
  
  const stops = trip.dayTripItems?.map((item, index) => {
    const isPlace = item.itemType === 'Place' || item.itemType === '0';
    const name = isPlace ? item.place?.name : item.route?.name;
    const description = isPlace ? item.place?.description : item.route?.description;
    const lengthKm = isPlace ? undefined : item.route?.lengthKm;
    
    return {
      image: isPlace && item.place?.imageUrl 
        ? item.place.imageUrl 
        : `https://images.unsplash.com/photo-${1500000000000 + index}?w=400`,
      name: name || 'תחנה',
      type: trip.type?.typeName || 'טיול',
      order: item.orderInTrip || index + 1,
      icon: getIconForType(trip.type?.typeName || ''),
      time: `${7 + index}:00`,
      duration: `${item.estimatedDuration || 60} דקות`,
      distance: lengthKm ? `${lengthKm} ק"מ` : undefined,
      description: description || '',
      tips: index === 0 ? 'מומלץ להתחיל מוקדם בבוקר' : undefined,
    };
  }) || [];

  const totalMinutes = trip.totalDurationHours * 60;
  const drivingMinutes = stops.filter(s => s.duration?.includes('דקות')).length * 15;
  const walkingMinutes = totalMinutes * 0.3;
  const restMinutes = totalMinutes - drivingMinutes - walkingMinutes;

  return {
    trip: {
      name: trip.name,
      subtitle: trip.description,
      duration: `${trip.totalDurationHours} שעות`,
      totalDistance: `${trip.totalLengthKM} ק"מ`,
      difficulty: trip.difficulty?.name || 'ללא',
      stops: stops,
      stats: {
        drivingTime: `${drivingMinutes} דקות`,
        walkingTime: `${Math.round(walkingMinutes)} דקות`,
        restTime: `${Math.round(restMinutes)} דקות`,
      },
      whyMatch: generateWhyMatch(trip, matchPercentage),
      match: matchPercentage,
      rating: trip.averageRating || 4.5,
    },
    matchPercentage,
  };
}

function getIconForType(typeName: string): string {
  const iconMap: Record<string, string> = {
    'טבע ונופים': '🌿',
    'היסטוריה ותרבות': '🏛️',
    'פעילות ספורט': '🏃',
    'קולינריה': '🍽️',
    'משפחה': '👨‍👩‍👧‍👦',
  };
  return iconMap[typeName] || '📍';
}

function generateWhyMatch(trip: ServerRecommendedTrip['trip'], matchPercentage: number): string[] {
  const reasons: string[] = [];
  
  if (matchPercentage >= 80) {
    reasons.push('מתאים מאוד להעדפות שלך');
  }
  
  if (trip.averageRating && trip.averageRating >= 4.5) {
    reasons.push(`דירוג גבוה (${trip.averageRating} ⭐)`);
  }
  
  if (trip.price === 0) {
    reasons.push('חינם!');
  } else if (trip.price <= 50) {
    reasons.push(`מחיר משתלם (${trip.price} ₪)`);
  }
  
  if (trip.totalDurationHours <= 6) {
    reasons.push('טיול קצר ואיכותי');
  }
  
  if (trip.accessibility?.name?.includes('נגיש') || (trip.accessibility?.id ?? 0) >= 2) {
    reasons.push('נגיש לכיסאות גלגלים');
  }
  
  reasons.push(`ב${trip.region?.regionName || 'אזור מועדף'}`);
  
  return reasons.slice(0, 4);
}

// thunk אסינכרוני שמשתמש בפונקציה שלך
export const fetchRecommendedTrips = createAsyncThunk<
  RecommendedTrip[],
  PlanDataType,
  { rejectValue: string }
>('trips/fetchRecommendedTrips', async (planData, { rejectWithValue }) => {
  try {
    console.log("fetchRecommendedTrips thunk called with:", planData);
    const data = await getRecommendedTrips(planData);
    console.log("Got response from server:", data);
    return (data as ServerRecommendedTrip[]).map(transformServerResponse);
  } catch (err: any) {
    console.error("Error in fetchRecommendedTrips:", err);
    return rejectWithValue(err.message || 'Error fetching recommended trips');
  }
});

const tripsSlice = createSlice({
  name: 'trips',
  initialState,
  reducers: {
    // אפשר להוסיף reducers מקומיים אם צריך, למשל לשמור trip נבחר
  },
  extraReducers: builder => {
    builder
      .addCase(fetchRecommendedTrips.pending, state => {
        state.loading = true;
        state.error = undefined;
      })
      .addCase(fetchRecommendedTrips.fulfilled, (state, action) => {
        state.loading = false;
        state.trips = action.payload;
      })
      .addCase(fetchRecommendedTrips.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload;
      });
  },
});

export default tripsSlice.reducer;