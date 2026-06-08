import type { DayTripType } from "../types/dayTrip.type";
import type { TripFilterType } from "../types/tripFilter.type";
import type { PlanDataType } from "../pages/TripPlannerWizard";
import axiosInstance from "./axios";

const url = "DayTrip";

export interface TripSearchRequestDto {
    regionId: number | null;
    typeId: number | null;
    maxPrice: number | null;
    availableHours: number | null;
    difficulty: number | null;
    accessibility: number | null;
    isRainyDay: boolean | null;
    count: number;
}

export interface RecommendedTrip {
    trip: {
        name: string;
        subtitle: string;
        duration: string;
        totalDistance: string;
        difficulty: string;
        stops: Array<{
            image: string;
            name: string;
            type: string;
            order: number;
            icon: string;
            time: string;
            duration: string;
            distance?: string;
            description: string;
            tips?: string;
        }>;
        stats: {
            drivingTime: string;
            walkingTime: string;
            restTime: string;
        };
        whyMatch: string[];
        match: number;
        rating: number;
    };
    matchPercentage: number;
}

function transformPlanDataToRequest(planData: PlanDataType): TripSearchRequestDto {
    return {
        regionId: planData.region,
        typeId: planData.tripType,
        maxPrice: planData.preferences.maxPrice,
        availableHours: planData.preferences.availableHours,
        difficulty: planData.difficulty,
        accessibility: planData.accessibility,
        isRainyDay: planData.preferences.isRainyDay ? true : null,
        count: 5
    };
}

export async function getTopTrips(): Promise<DayTripType[]> {
    try {
        const res = await axiosInstance.get<DayTripType[]>(`${url}/top-three`);
        return res.data;
    } catch (error) {
        console.error("Error fetching top trips:", error);
        return [];
    }
}

export const getFilteredTrips = async (filter: TripFilterType): Promise<DayTripType[]> => {
    try {
        const response = await axiosInstance.post<DayTripType[]>(`${url}/filtered`, filter);
        return response.data;
    } catch (error) {
        console.error('Error fetching trips:', error);
        return [];
    }
};

export const getRecommendedTrips = async (planData: PlanDataType) => {
    const requestDto = transformPlanDataToRequest(planData);
    console.log("Sending recommend request:", requestDto);
    const response = await axiosInstance.post(`${url}/recommend`, requestDto);
    return response.data;
};

