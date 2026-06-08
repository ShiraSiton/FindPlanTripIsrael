import axiosInstance from "./axios";

const url = "DayTrip";

export const getTripById = async (id: number) => {
  const response = await axiosInstance.get(`${url}/${id}`)
  return response.data 
}