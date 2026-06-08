import { Heart, Share2 } from "lucide-react"
import { useState } from "react"
import type { DayTripType } from "../../types/dayTrip.type"

interface Props {
  trip: DayTripType
}

export default function TripHero({ trip }: Props) {

  const [saved, setSaved] = useState(false)

  const imageSrc = trip.imageUrl || (trip.image ? `data:image/jpeg;base64,${trip.image}` : null);

  return (
    <>
      {/* Hero Section */}
      <div className="relative h-[70vh] md:h-[80vh]">
        {imageSrc ? (
          <div
            className="absolute inset-0 bg-cover bg-center"
            style={{ backgroundImage: `url('${imageSrc}')` }}
          >
            <div className="absolute inset-0 bg-gradient-to-b from-[#000000]/40 via-[#000000]/20 to-[#000000]/60"></div>
          </div>
        ) : (
          <div className="absolute inset-0 bg-gradient-to-b from-[#f3f4f6] to-[#e5e7eb] flex items-center justify-center">
            <span className="text-[#9ca3af] text-lg">אין תמונה</span>
          </div>
        )}

        {/* Action Buttons */}
        <div className="absolute top-6 left-6 flex gap-3 z-10">
          <button className="w-11 h-11 bg-[#ffffff]/90 backdrop-blur-sm hover:bg-[#ffffff] rounded-full flex items-center justify-center transition-all">
            <Share2 className="w-5 h-5 text-[#111827]" />
          </button>
          <button
            onClick={() => setSaved(!saved)}
            className={`w-11 h-11 backdrop-blur-sm rounded-full flex items-center justify-center transition-all ${saved ? 'bg-[#ffffff]/90 text-[#ef4444]' : 'bg-[#ffffff]/90 hover:bg-[#ffffff] text-[#111827]'
              }`}
          >
            <Heart className={`w-5 h-5 ${saved ? 'fill-current' : ''}`} />
          </button>
        </div>

        {/* Content */}
        <div className="relative h-full flex flex-col justify-end left-20">
          <div className="max-w-7xl mx-auto px-4 md:px-6 pb-12 md:pb-16">
            <div className="flex flex-wrap gap-2 mb-4">
              <span className="px-3 py-1 bg-[#ffffff]/90 backdrop-blur-sm text-[#111827] text-sm font-medium rounded-full">
                {trip.region.regionName}
              </span>
              <span className="px-3 py-1 bg-[#ffffff]/90 backdrop-blur-sm text-[#111827] text-sm font-medium rounded-full">
                {trip.difficulty.name}
              </span>
              <span className="px-3 py-1 bg-[#ffffff]/90 backdrop-blur-sm text-[#111827] text-sm font-medium rounded-full">
                {trip.stopsCount} תחנות
              </span>
            </div>
            <h1 className="text-4xl md:text-6xl font-light text-[#ffffff] mb-4">
              {trip.name}
            </h1>
            <p className="text-xl text-[#ffffff]/90 max-w-2xl">
              {trip.description.slice(0, 48)}
            </p>
          </div>
        </div>
      </div>
    </>
  )
}