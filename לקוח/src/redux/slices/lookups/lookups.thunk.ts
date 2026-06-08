import { getLookups } from "../../../services/lookups.service";
import type { AppDispatch, RootState } from "../../store";
import { setLookups } from "./lookups.slice";

export const fetchLookups = () => async (dispatch: AppDispatch, getState: () => RootState) => {
    const state = getState();

    // 🧠 לא לטעון פעמיים
    if (state.lookups.isLoaded) return;

    try {
        const data = await getLookups();
        console.log("Lookups data received:", data);
        dispatch(setLookups(data));
    } catch (error) {
        console.error("Error fetching lookups:", error);
    }
};