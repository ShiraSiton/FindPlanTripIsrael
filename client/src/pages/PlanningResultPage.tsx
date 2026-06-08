import { useState } from 'react';
import { MapPin, Clock, TrendingUp, Navigation, Bookmark, RefreshCw, Edit3, Heart, Share2, Download, ChevronLeft, ChevronRight, CheckCircle2, Star } from 'lucide-react';
import { useNavigate } from 'react-router-dom';
import { useSelector } from 'react-redux';
import type { RootState } from '../redux/store';
import type { RecommendedTrip } from '../redux/slices/planner/tripsSlice';


export default function PlanningResultPage() {
  const navigate = useNavigate();

  const { trips, loading, error } = useSelector((state: RootState) => state.planner);
  
  const [currentTripIndex, setCurrentTripIndex] = useState(0);
  const [isSaved, setIsSaved] = useState(false);

  
  if (loading) return <div>טוען...</div>;
  if (error) return <div>שגיאה: {error}</div>;
  if (!trips.length) return <div>לא נמצאו טיולים</div>;


   const current: RecommendedTrip = trips[currentTripIndex];
  const trip = current.trip;
  const match = current.matchPercentage;


  const nextTrip = () => {
    if (currentTripIndex < trips.length - 1) {
      setCurrentTripIndex(prev => prev + 1);
    }
  };

  const prevTrip = () => {
    if (currentTripIndex > 0) {
      setCurrentTripIndex(prev => prev - 1);
    }
  };

  type Type = 'תצפית' | 'מים' | 'הליכה' | 'אוכל' | 'פעילות' | 'תרבות';

  const getTypeColor = (type: string) => {
    const colors = {
      'תצפית': 'bg-[#e0e7ff] text-[#6366f1]',
      'מים': 'bg-[#dbeafe] text-[#2563eb]',
      'הליכה': 'bg-[#fef3c7] text-[#d97706]',
      'אוכל': 'bg-[#fee2e2] text-[#dc2626]',
      'פעילות': 'bg-[#fce7f3] text-[#db2777]',
      'תרבות': 'bg-[#fce7f3] text-[#db2777]'
    };
    return colors[type as Type] || 'bg-[#f3f4f6] text-[#6b7280]';
  };

  type Difficulty = 'קל' | 'קל-בינוני' | 'בינוני' | 'בינוני-קשה' | 'קשה' | 'ללא';

  const getDifficultyColor = (difficulty: string) => {
    const colors = {
      'קל': 'text-[#059669]',
      'קל-בינוני': 'text-[#059669]',
      'בינוני': 'text-[#d97706]',
      'בינוני-קשה': 'text-[#dc2626]',
      'קשה': 'text-[#dc2626]',
      'ללא': 'text-[#6b7280]'
    };
    return colors[difficulty as Difficulty] || 'text-[#6b7280]';
  };

  return (
    <div className="min-h-screen bg-[#f9fafb]" dir="rtl">
      {/* Hero Section with Image */}
      <div className="relative h-[60vh]">
        <div
          className="absolute inset-0 bg-cover bg-center"
          style={{
            backgroundImage: currentTripIndex === 0
              ? "url('https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=1920&h=800&fit=crop')"
              : "url('https://images.unsplash.com/photo-1469854523086-cc02fe5d8800?w=1920&h=800&fit=crop')"
          }}
        >
          <div className="absolute inset-0 bg-gradient-to-b from-[#000000]/50 via-[#000000]/30 to-[#000000]/70"></div>
        </div>

        {/* Action Buttons */}
        <div className="absolute top-6 left-6 flex gap-3 z-10">
          <button className="w-11 h-11 bg-[#ffffff]/90 backdrop-blur-sm hover:bg-[#ffffff] rounded-full flex items-center justify-center transition-all">
            <Share2 className="w-5 h-5 text-[#111827]" />
          </button>
          <button
            onClick={() => setIsSaved(!isSaved)}
            className={`w-11 h-11 backdrop-blur-sm rounded-full flex items-center justify-center transition-all ${isSaved ? 'bg-[#ef4444] text-[#ffffff]' : 'bg-[#ffffff]/90 hover:bg-[#ffffff] text-[#111827]'
              }`}
          >
            <Heart className={`w-5 h-5 ${isSaved ? 'fill-current' : ''}`} />
          </button>
        </div>

        {/* Content */}
        <div className="relative h-full flex flex-col justify-end">
          <div className="max-w-7xl mx-auto px-4 md:px-6 pb-12">
            {match >= 90 && (
              <div className="inline-flex items-center gap-2 bg-[#ffffff]/90 backdrop-blur-sm text-[#059669] px-4 py-2 rounded-full text-sm font-bold mb-4">
                <CheckCircle2 className="w-4 h-4" />
                התאמה מושלמת - {match}%
              </div>
            )}
            <h1 className="text-4xl md:text-6xl font-light text-[#ffffff] mb-3">
              {trip.name}
            </h1>
            <p className="text-xl text-[#ffffff]/90 max-w-2xl">
              {trip.subtitle}
            </p>
          </div>
        </div>
      </div>

      {/* Trip Navigation */}
      {trips.length > 1 && (
        <div className="bg-[#ffffff] border-b border-[#e5e7eb]">
          <div className="max-w-7xl mx-auto px-4 md:px-6 py-4">
            <div className="flex items-center justify-between bg-[#f9fafb] rounded-lg p-4">
              <button
                onClick={prevTrip}
                disabled={currentTripIndex === 0}
                className={`flex items-center gap-2 px-4 py-2 rounded-lg transition-colors ${currentTripIndex === 0
                  ? 'text-[#9ca3af] cursor-not-allowed'
                  : 'text-[#111827] hover:bg-[#ffffff]'
                  }`}
              >
                <ChevronRight className="w-4 h-4" />
                הקודם
              </button>

              <div className="text-sm text-[#6b7280]">
                אפשרות {currentTripIndex + 1} מתוך {trips.length}
              </div>

              <button
                onClick={nextTrip}
                disabled={currentTripIndex === trips.length - 1}
                className={`flex items-center gap-2 px-4 py-2 rounded-lg transition-colors ${currentTripIndex === trips.length - 1
                  ? 'text-[#9ca3af] cursor-not-allowed'
                  : 'text-[#111827] hover:bg-[#ffffff]'
                  }`}
              >
                הבא
                <ChevronLeft className="w-4 h-4" />
              </button>
            </div>
          </div>
        </div>
      )}

      {/* Main Content */}
      <div className="max-w-7xl mx-auto px-4 md:px-6 py-8">
        <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
          {/* Left Column */}
          <div className="lg:col-span-2 space-y-8">
            {/* Trip Stats */}
            <div className="bg-[#ffffff] border border-[#e5e7eb] rounded-lg p-6">
              <h2 className="text-2xl font-light text-[#111827] mb-6">סיכום הטיול</h2>
              <div className="grid grid-cols-2 md:grid-cols-4 gap-6">
                <div className="text-center">
                  <Clock className="w-6 h-6 text-[#6b7280] mx-auto mb-2" />
                  <div className="text-sm text-[#6b7280] mb-1">זמן כולל</div>
                  <div className="text-lg font-bold text-[#111827]">{trip.duration}</div>
                </div>
                <div className="text-center">
                  <TrendingUp className={`w-6 h-6 mx-auto mb-2 ${getDifficultyColor(trip.difficulty)}`} />
                  <div className="text-sm text-[#6b7280] mb-1">רמת קושי</div>
                  <div className={`text-lg font-bold ${getDifficultyColor(trip.difficulty)}`}>{trip.difficulty}</div>
                </div>
                <div className="text-center">
                  <Navigation className="w-6 h-6 text-[#6b7280] mx-auto mb-2" />
                  <div className="text-sm text-[#6b7280] mb-1">מרחק</div>
                  <div className="text-lg font-bold text-[#111827]">{trip.totalDistance.split('+')[0]}</div>
                </div>
                <div className="text-center">
                  <MapPin className="w-6 h-6 text-[#6b7280] mx-auto mb-2" />
                  <div className="text-sm text-[#6b7280] mb-1">תחנות</div>
                  <div className="text-lg font-bold text-[#111827]">{trip.stops.length}</div>
                </div>
              </div>

              {/* Progress Bars */}
              <div className="mt-6 space-y-3">
                <div>
                  <div className="flex justify-between text-sm text-[#6b7280] mb-1">
                    <span>נסיעה</span>
                    <span>{trip.stats.drivingTime}</span>
                  </div>
                  <div className="h-2 bg-[#f3f4f6] rounded-full overflow-hidden">
                    <div className="h-full bg-[#3b82f6] rounded-full" style={{ width: '30%' }}></div>
                  </div>
                </div>
                <div>
                  <div className="flex justify-between text-sm text-[#6b7280] mb-1">
                    <span>הליכה</span>
                    <span>{trip.stats.walkingTime}</span>
                  </div>
                  <div className="h-2 bg-[#f3f4f6] rounded-full overflow-hidden">
                    <div className="h-full bg-[#10b981] rounded-full" style={{ width: '25%' }}></div>
                  </div>
                </div>
                <div>
                  <div className="flex justify-between text-sm text-[#6b7280] mb-1">
                    <span>מנוחה ופעילויות</span>
                    <span>{trip.stats.restTime}</span>
                  </div>
                  <div className="h-2 bg-[#f3f4f6] rounded-full overflow-hidden">
                    <div className="h-full bg-[#f59e0b] rounded-full" style={{ width: '45%' }}></div>
                  </div>
                </div>
              </div>
            </div>

            {/* Map Placeholder */}
            <div className="bg-[#ffffff] border border-[#e5e7eb] rounded-lg p-6">
              <h2 className="text-2xl font-light text-[#111827] mb-6">מפת המסלול</h2>
              <div className="bg-[#f9fafb] border border-[#e5e7eb] rounded-lg aspect-video flex items-center justify-center">
                <div className="text-center">
                  <MapPin className="w-12 h-12 text-[#9ca3af] mx-auto mb-3" />
                  <div className="text-[#6b7280] mb-2">מפה אינטראקטיבית עם כל התחנות</div>
                  <button className="text-sm text-[#111827] hover:underline flex items-center gap-2 mx-auto">
                    <Download className="w-4 h-4" />
                    הורד מסלול GPS
                  </button>
                </div>
              </div>
            </div>

            {/* Itinerary */}
            <div className="bg-[#ffffff] border border-[#e5e7eb] rounded-lg p-6">
              <h2 className="text-2xl font-light text-[#111827] mb-6">מסלול יומי מפורט</h2>
              <div className="space-y-8">
                {trip.stops.map((stop, index) => (
                  <div key={index} className="border border-[#e5e7eb] rounded-lg overflow-hidden hover:border-[#d1d5db] transition-all">
                    <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                      {/* Image */}
                      <div className="md:col-span-1">
                        <div className="relative aspect-[4/3] md:aspect-square">
                          <img
                            src={stop.image}
                            alt={stop.name}
                            className="w-full h-full object-cover"
                          />
                          <div className="absolute top-3 right-3">
                            <span className={`px-3 py-1 text-xs font-medium rounded-full ${getTypeColor(stop.type)}`}>
                              {stop.type}
                            </span>
                          </div>
                          <div className="absolute top-3 left-3">
                            <div className="w-10 h-10 bg-[#111827] text-[#ffffff] rounded-full flex items-center justify-center font-bold">
                              {stop.order}
                            </div>
                          </div>
                        </div>
                      </div>

                      {/* Content */}
                      <div className="md:col-span-2 p-6">
                        <div className="flex items-start justify-between mb-3">
                          <div className="flex items-center gap-3">
                            <span className="text-2xl">{stop.icon}</span>
                            <h3 className="text-2xl font-medium text-[#111827]">{stop.name}</h3>
                          </div>
                        </div>

                        <div className="flex items-center gap-4 text-sm text-[#6b7280] mb-4">
                          <span className="flex items-center gap-1">
                            <Clock className="w-4 h-4" />
                            {stop.time}
                          </span>
                          <span>•</span>
                          <span>{stop.duration}</span>
                          {stop.distance && (
                            <>
                              <span>•</span>
                              <span>{stop.distance}</span>
                            </>
                          )}
                        </div>

                        <p className="text-[#4b5563] leading-relaxed mb-4">
                          {stop.description}
                        </p>

                        {stop.tips && (
                          <div className="bg-[#fffbeb] border border-[#fde68a] rounded-sm p-3 text-sm text-[#78350f]">
                            <strong>💡 טיפ:</strong> {stop.tips}
                          </div>
                        )}
                      </div>
                    </div>
                  </div>
                ))}
              </div>
            </div>
          </div>

          {/* Right Column - Sidebar */}
          <div className="space-y-6">
            {/* Why This Trip */}
            <div className="bg-[#f0fdf4] border border-[#86efac] rounded-lg p-6 sticky top-6">
              <h3 className="text-xl font-bold text-[#111827] mb-4 flex items-center gap-2">
                <CheckCircle2 className="w-5 h-5 text-[#059669]" />
                למה זה מתאים לך?
              </h3>
              <div className="space-y-3">
                {trip.whyMatch.map((reason, index) => (
                  <div key={index} className="flex items-start gap-3">
                    <div className="w-5 h-5 rounded-full bg-[#059669] flex items-center justify-center flex-shrink-0 mt-0.5">
                      <CheckCircle2 className="w-3 h-3 text-[#ffffff]" />
                    </div>
                    <span className="text-sm text-[#047857]">{reason}</span>
                  </div>
                ))}
              </div>

              <div className="mt-6 pt-6 border-t border-[#86efac]">
                <div className="flex items-center justify-between mb-2">
                  <span className="text-sm text-[#047857]">ציון התאמה</span>
                  <span className="text-2xl font-bold text-[#059669]">{trip.match}%</span>
                </div>
                <div className="h-2 bg-[#d1fae5] rounded-full overflow-hidden">
                  <div
                    className="h-full bg-[#059669] rounded-full transition-all duration-1000"
                    style={{ width: `${trip.match}%` }}
                  ></div>
                </div>
              </div>
            </div>

            {/* Action Buttons */}
            <div className="bg-[#ffffff] border border-[#e5e7eb] rounded-lg p-6 space-y-3">
              <button className="w-full bg-[#111827] text-[#ffffff] py-3.5 rounded-lg font-bold hover:bg-[#1f2937] transition-colors flex items-center justify-center gap-2">
                <Bookmark className="w-4 h-4" />
                שמור אצלי
              </button>

              <button onClick={() => navigate('/tripPlan')} className="w-full border-2 border-[#111827] text-[#111827] py-3.5 rounded-lg font-bold hover:bg-[#f9fafb] transition-colors flex items-center justify-center gap-2">
                <Edit3 className="w-4 h-4" />
                התחל מחדש
              </button>

              <button onClick={() => navigate('/')} className="w-full border-2 border-[#d1d5db] text-[#6b7280] py-3.5 rounded-lg font-bold hover:bg-[#f9fafb] transition-colors flex items-center justify-center gap-2">
                <RefreshCw className="w-4 h-4" />
                חזרה לדף הבית
              </button>
            </div>

            {/* Trip Rating */}
            <div className="bg-[#ffffff] border border-[#e5e7eb] rounded-lg p-6">
              <div className="flex items-center justify-between mb-4">
                <h3 className="text-lg font-bold text-[#111827]">דירוג הטיול</h3>
                <div className="flex items-center gap-1">
                  <Star className="w-5 h-5 fill-[#f59e0b] text-[#f59e0b]" />
                  <span className="font-bold text-[#111827]">{trip.rating}</span>
                </div>
              </div>
              <p className="text-sm text-[#6b7280]">
                מבוסס על {trip.rating >= 4.5 ? '200+' : '150+'} ביקורות של מטיילים
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}