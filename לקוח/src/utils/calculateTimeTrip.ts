import type { DayTripType } from "../types/dayTrip.type"

function getDistanceKm(lat1: number, lon1: number, lat2: number, lon2: number) {
  const R = 6371

  const dLat = (lat2 - lat1) * Math.PI / 180
  const dLon = (lon2 - lon1) * Math.PI / 180

  const a =
    Math.sin(dLat / 2) * Math.sin(dLat / 2) +
    Math.cos(lat1 * Math.PI / 180) *
    Math.cos(lat2 * Math.PI / 180) *
    Math.sin(dLon / 2) * Math.sin(dLon / 2)

  const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a))

  return R * c
}

function getTravelMinutes(distanceKm: number, mode: number) {

  const speeds: Record<number, number> = {
    0: 5,
    1: 15,
    2: 60
  }

  const speed = speeds[mode] ?? 5

  const hours = distanceKm / speed

  return hours * 60
}

function getStopLocation(stop: any) {

  if (stop.place) {
    return {
      lat: stop.place.latitude,
      lng: stop.place.longitude
    }
  }

  if (stop.route) {
    return {
      lat: stop.route.startLatitude,
      lng: stop.route.startLongitude
    }
  }

}

//פונקציה לעיגול שעה
function roundToHalfHour(date: Date) {
  const minutes = date.getMinutes()

  if (minutes < 15) {
    date.setMinutes(0)
  } else if (minutes < 45) {
    date.setMinutes(30)
  } else {
    date.setHours(date.getHours() + 1)
    date.setMinutes(0)
  }

  date.setSeconds(0)
  return date
}

//פורמט השעה
function formatTime(date: Date) {
  return date.toLocaleTimeString("he-IL", {
    hour: "2-digit",
    minute: "2-digit"
  })
}

//פורמט משך זמן
export function formatDuration(minutes: number) {
  const hours = minutes / 60

  if (hours === 1) return "שעה"
  if (hours === 2) return "שעתיים"
  if (Number.isInteger(hours)) return `${hours} שעות`

  return `${hours.toFixed(1)} שעות`
}

export function calculateStopsTimes(trip: DayTripType) {

  const stops = [...trip.dayTripItems]
    .sort((a, b) => a.orderInTrip - b.orderInTrip)

  let currentTime = new Date(`2000-01-01T${trip.startTime}`)

  const result: string[] = []

  for (let i = 0; i < stops.length; i++) {

    const stop = stops[i]

    const roundedTime = roundToHalfHour(new Date(currentTime))

    result.push(formatTime(roundedTime))

    currentTime = new Date(
      currentTime.getTime() +
      stop.estimatedDuration * 60000
    )

    const next = stops[i + 1]

    if (next) {

      const loc1 = getStopLocation(stop)
      const loc2 = getStopLocation(next)

      if (loc1 && loc2) {
        const distance = getDistanceKm(
          loc1.lat,
          loc1.lng,
          loc2.lat,
          loc2.lng
        )

        const travelMinutes = getTravelMinutes(
          distance,
          stop.mode
        )

        currentTime = new Date(
          currentTime.getTime() +
          travelMinutes * 60000
        )
      }
    }

  }

  return result
}



//פורמט מרחק + אופן הגעה
function formatDistance(distanceKm: number, mode: number) {
  const rounded = Math.round(distanceKm * 10) / 10

  const modeText: Record<number, string> = {
    0: "הליכה",
    1: "אופניים",
    2: "נסיעה"
  }

  return `${rounded} ק"מ ${modeText[mode] ?? ""}`
}

export function calculateDistances(trip: DayTripType) {
  const stops = [...trip.dayTripItems]
    .sort((a, b) => a.orderInTrip - b.orderInTrip)

  const result: (string | null)[] = []

  for (let i = 0; i < stops.length; i++) {
    const current = stops[i]
    const next = stops[i + 1]

    if (!next) {
      result.push(null)
      continue
    }

    const loc1 = getStopLocation(current)
    const loc2 = getStopLocation(next)

    if (loc1 && loc2) {
      const distance = getDistanceKm(
        loc1.lat,
        loc1.lng,
        loc2.lat,
        loc2.lng
      )

      result.push(formatDistance(distance, current.mode))
    } else {
      result.push(null)
    }
  }

  return result
}