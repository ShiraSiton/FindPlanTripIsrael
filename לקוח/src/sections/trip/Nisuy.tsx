import { useMemo } from "react"
import type { DayTripType } from "../../types/dayTrip.type"
import { Clock, Download, MapPin } from "lucide-react"
import { Link } from "react-router-dom"
import { calculateDistances, calculateStopsTimes, formatDuration } from "../../utils/calculateTimeTrip"

interface Props {
    trip: DayTripType
}

function getImageSrc(image: string | null | undefined): string {
    if (!image) return '';
    if (image.startsWith('http')) return image;
    return `data:image/jpeg;base64,${image}`;
}

export default function Nisuy({ trip }: Props) {

    const getLink = (stop: any) => {
        if (stop.itemType === 'Route') {
            return `/trailDetails`;
        }
        return `/placeDetails`;
    };

    const stopTimes = useMemo(
        () => calculateStopsTimes(trip),
        [trip]
    )

    const distances = useMemo(
        () => calculateDistances(trip),
        [trip]
    )

    return (
        <>
            {/* Main Content */}
            < div className="max-w-7xl mx-auto px-4 md:px-6 pb-24" >
                <div className="grid grid-cols-1 lg:grid-cols-3 gap-12">
                    {/* Left Column */}
                    <div className="lg:col-span-2 space-y-12">
                        {/* Itinerary */}
                        <section>
                            <h2 className="text-3xl font-light text-[#111827] mb-4">מסלול יומי מפורט</h2>
                            <div className="space-y-8">
                                {trip.dayTripItems.map((stop, index) => {
                                    const item = stop.place ?? stop.route

                                    const image =
                                        item?.images?.find(i => i.isMain)?.image ||
                                        item?.images?.[0]?.image

                                    return (
                                        < Link
                                            key={index}
                                            to={getLink(stop)}
                                            className="block"
                                        >
                                            <div key={index} className="border border-[#e5e7eb] rounded-sm overflow-hidden hover:border-[#d1d5db] transition-all">
                                                <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                                                    {/* Image */}
                                                    <div className="md:col-span-1">
                                                        <div className="relative aspect-[4/3] md:aspect-square">
                                                            <img
                                                                src={getImageSrc(image)}
                                                                alt={item?.name}
                                                                className="w-full h-full object-cover"
                                                            />
                                                            <div className="absolute top-3 right-3">
                                                                <span className={`px-3 py-1 text-xs font-medium rounded-full `}>
                                                                    {typeof item?.type === 'string' ? item.type : ''}
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    {/* Content */}
                                                    <div className="md:col-span-2 p-6">
                                                        <div className="flex items-start justify-between mb-3">
                                                            <div>
                                                                <div className="flex items-center gap-3 mb-2">
                                                                    <span className="text-2xl font-bold text-[#111827]">{index + 1}.</span>
                                                                    <h3 className="text-2xl font-medium text-[#111827]">{item?.name}</h3>
                                                                </div>
                                                                <div className="flex items-center gap-4 text-sm text-[#6b7280]">
                                                                    {/* שעת הגעה */}
                                                                    <span className="flex items-center gap-1">
                                                                        <Clock className="w-4 h-4" />
                                                                        {stopTimes[index]}
                                                                    </span>
                                                                    {/* זמן שהייה */}
                                                                    <span>•</span>
                                                                    <span>{formatDuration(stop.estimatedDuration)}</span>
                                                                    {/* מרחק + אופן הגעה */}
                                                                    {distances[index] && (
                                                                        <>
                                                                            <span>•</span>
                                                                            <span>{distances[index]}</span>
                                                                        </>
                                                                    )}
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <p className="text-[#4b5563] leading-relaxed mb-4 line-clamp-4">
                                                            {item.description}
                                                        </p>

                                                    </div>
                                                </div>
                                            </div>
                                        </Link>
                                    )
                                })}
                            </div>
                        </section>

                        {/* Map Placeholder */}
                        <section>
                            <h2 className="text-3xl font-light text-[#111827] mb-6">מפת הטיול</h2>
                            <div className="bg-[#f9fafb] border border-[#e5e7eb] rounded-sm aspect-video flex items-center justify-center">
                                <div className="text-center">
                                    <MapPin className="w-12 h-12 text-[#9ca3af] mx-auto mb-3" />
                                    <div className="text-[#6b7280] mb-2">מפה אינטראקטיבית של כל התחנות</div>
                                    <button className="mt-3 text-sm text-[#111827] hover:underline flex items-center gap-2 mx-auto">
                                        <Download className="w-4 h-4" />
                                        הורד מסלול GPS
                                    </button>
                                </div>
                            </div>
                        </section>
                    </div>
                </div >
            </div >
        </>
    )
}