import { useState } from "react"
import type { DayTripType } from "../../types/dayTrip.type"
import { ChevronLeft, ChevronRight } from "lucide-react"

function getImageSrc(image: string | null | undefined, isUrl: boolean = false): string {
    if (!image) return '';
    if (isUrl || image.startsWith('http')) return image;
    return `data:image/jpeg;base64,${image}`;
}

function collectImages(trip: DayTripType) {
    const images: { src: string; isUrl: boolean }[] = []

    trip.dayTripItems.forEach(item => {
        item.place?.images?.forEach(img => {
            if (img.imageUrl) {
                images.push({ src: img.imageUrl, isUrl: true });
            } else if (img.image) {
                images.push({ src: img.image, isUrl: false });
            }
        })
        item.route?.images?.forEach(img => {
            if (img.imageUrl) {
                images.push({ src: img.imageUrl, isUrl: true });
            } else if (img.image) {
                images.push({ src: img.image, isUrl: false });
            }
        })
    })

    return images.map(img => getImageSrc(img.src, img.isUrl));
}

interface Props {
    trip: DayTripType
}

export default function TripGallery({ trip }: Props) {

    const images = collectImages(trip)

    const [isOpen, setIsOpen] = useState(false)
    const [currentIndex, setCurrentIndex] = useState(0)

    const visibleImages = images.slice(0, 8)
    const extraCount = images.length - 8

    const openGallery = (index: number) => {
        setCurrentIndex(index)
        setIsOpen(true)
    }

    const next = () => {
        setCurrentIndex((prev) => (prev + 1) % images.length)
    }

    const prev = () => {
        setCurrentIndex((prev) =>
            prev === 0 ? images.length - 1 : prev - 1
        )
    }

    if (images.length === 0) {
        return null;
    }

    return (
        <div className="max-w-7xl mx-auto px-4 mb-12">

            <h2 className="text-3xl font-light mb-4">
                תמונות מהטיול
            </h2>

            <div className="grid grid-cols-2 md:grid-cols-4 gap-3">
                {visibleImages.map((img, i) => (
                    <div
                        key={i}
                        className="relative cursor-pointer"
                        onClick={() => openGallery(i)}
                    >
                        <img
                            src={img}
                            className="w-full h-40 object-cover rounded"
                        />

                        {i === 7 && extraCount > 0 && (
                            <div className="absolute inset-0 bg-black/60 flex items-center justify-center rounded text-white text-lg font-medium">
                                +{extraCount} תמונות נוספות
                            </div>
                        )}
                    </div>
                ))}
            </div>

            {/* Lightbox */}
            {isOpen && images.length > 0 && (
                <div
                    className="fixed inset-0 bg-black/80 flex items-center justify-center z-50"
                    onClick={() => setIsOpen(false)}
                >
                    <div
                        className="relative max-w-4xl w-full px-4"
                        onClick={(e) => e.stopPropagation()}
                    >
                        <img
                            src={images[currentIndex]}
                            className="w-full max-h-[80vh] object-contain rounded"
                        />

                        {/* כפתורי ניווט */}
                        <button
                            onClick={prev}
                            className="absolute right-4 top-1/2 -translate-y-1/2
                            bg-black/40 hover:bg-black/60
                            text-white text-xl
                            w-11 h-11
                            rounded-full
                            flex items-center justify-center
                            backdrop-blur-sm
                            shadow-lg
                            transition"
                        >
                            <ChevronRight size={28} className="text-white" />
                        </button>

                        <button
                            onClick={next}
                            className="absolute left-4 top-1/2 -translate-y-1/2
                            bg-black/40 hover:bg-black/60
                            text-white text-xl
                            w-11 h-11
                            rounded-full
                            flex items-center justify-center
                            backdrop-blur-sm
                            shadow-lg
                            transition"
                        >
                            <ChevronLeft size={28} className="text-white" />
                        </button>

                        {/* כפתור סגירה */}
                        <button
                            onClick={() => setIsOpen(false)}
                            className="absolute top-0 right-4
                            bg-black/40 hover:bg-black/60
                            text-white text-xl
                            w-10 h-10
                            rounded-full
                            flex items-center justify-center
                            backdrop-blur-sm
                            shadow-lg
                            transition"
                        >
                            ✕
                        </button>
                    </div>
                </div>
            )}
        </div>
    )
}