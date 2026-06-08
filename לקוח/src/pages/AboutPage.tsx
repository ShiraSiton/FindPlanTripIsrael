import { MapPin, Users, Calendar, Heart, Star, Award } from 'lucide-react';
import { useNavigate } from 'react-router-dom';

export default function AboutPage() {
    const navigate = useNavigate();
    
    return (
        <div className="min-h-screen bg-white pt-20" dir="rtl">
            {/* Hero Section */}
            <div className="bg-gradient-to-b from-[#f0fdf4] to-white py-20">
                <div className="max-w-4xl mx-auto px-6 text-center">
                    <h1 className="text-4xl md:text-5xl font-light text-[#111827] mb-6">
                        אודות טיולון
                    </h1>
                    <p className="text-xl text-[#6b7280] leading-relaxed max-w-2xl mx-auto">
                        טיולון היא פלטפורמה לתכנון טיולים חכם ומותאם אישית, שנוצרה כדי לעזור לכם לגלות את ישראל בדרך הטובה ביותר
                    </p>
                </div>
            </div>

            {/* Story Section */}
            <div className="py-20">
                <div className="max-w-6xl mx-auto px-6">
                    <div className="grid md:grid-cols-2 gap-16 items-center">
                        <div>
                            <h2 className="text-3xl font-light text-[#111827] mb-6">הסיפור שלנו</h2>
                            <p className="text-[#6b7280] leading-relaxed mb-6">
                                טיולון נולדה מתוך אהבה גדולה לטבע הישראלי ורצון לחלוק אותו עם אחרים. 
                                הבנו שתכנון טיול יכול להיות מסובך ומעייף, ולכן יצרנו כלי שיעזור לכם 
                                למצוא את הטיול המושלם בלחיצת כפתור.
                            </p>
                            <p className="text-[#6b7280] leading-relaxed">
                                האלגוריתם שלנו מנתח את ההעדפות שלכם ומציע טיולים שמתאימים בדיוק לצרכים שלכם - 
                                בין אם אתם מחפשים טבע, היסטוריה, או חוויה משפחתית.
                            </p>
                        </div>
                        <div className="grid grid-cols-2 gap-6">
                            <div className="bg-[#f9fafb] rounded-lg p-6 text-center">
                                <div className="text-4xl font-bold text-[#111827] mb-2">500+</div>
                                <div className="text-[#6b7280] text-sm">מקומות מומלצים</div>
                            </div>
                            <div className="bg-[#f9fafb] rounded-lg p-6 text-center">
                                <div className="text-4xl font-bold text-[#111827] mb-2">200+</div>
                                <div className="text-[#6b7280] text-sm">טיולים מתוכננים</div>
                            </div>
                            <div className="bg-[#f9fafb] rounded-lg p-6 text-center">
                                <div className="text-4xl font-bold text-[#111827] mb-2">10K+</div>
                                <div className="text-[#6b7280] text-sm">משתמשים מרוצים</div>
                            </div>
                            <div className="bg-[#f9fafb] rounded-lg p-6 text-center">
                                <div className="text-4xl font-bold text-[#111827] mb-2">4.8</div>
                                <div className="text-[#6b7280] text-sm">דירוג ממוצע</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            {/* Values Section */}
            <div className="py-20 bg-[#f9fafb]">
                <div className="max-w-6xl mx-auto px-6">
                    <h2 className="text-3xl font-light text-[#111827] mb-12 text-center">הערכים שלנו</h2>
                    <div className="grid md:grid-cols-4 gap-8">
                        <div className="text-center">
                            <div className="w-16 h-16 bg-white rounded-full flex items-center justify-center mx-auto mb-4 shadow-sm">
                                <MapPin className="w-8 h-8 text-[#059669]" />
                            </div>
                            <h3 className="text-lg font-medium text-[#111827] mb-2">גילוי</h3>
                            <p className="text-[#6b7280] text-sm">עוזרים לכם לגלות מקומות חדשים ומרתקים</p>
                        </div>
                        <div className="text-center">
                            <div className="w-16 h-16 bg-white rounded-full flex items-center justify-center mx-auto mb-4 shadow-sm">
                                <Star className="w-8 h-8 text-[#059669]" />
                            </div>
                            <h3 className="text-lg font-medium text-[#111827] mb-2">איכות</h3>
                            <p className="text-[#6b7280] text-sm">רק התוכן הטוב ביותר נכנס לאפליקציה</p>
                        </div>
                        <div className="text-center">
                            <div className="w-16 h-16 bg-white rounded-full flex items-center justify-center mx-auto mb-4 shadow-sm">
                                <Heart className="w-8 h-8 text-[#059669]" />
                            </div>
                            <h3 className="text-lg font-medium text-[#111827] mb-2">קהילה</h3>
                            <p className="text-[#6b7280] text-sm">בנוי על ידי מטיילים, למען מטיילים</p>
                        </div>
                        <div className="text-center">
                            <div className="w-16 h-16 bg-white rounded-full flex items-center justify-center mx-auto mb-4 shadow-sm">
                                <Award className="w-8 h-8 text-[#059669]" />
                            </div>
                            <h3 className="text-lg font-medium text-[#111827] mb-2">מצוינות</h3>
                            <p className="text-[#6b7280] text-sm">תמיד שואפים לתת לכם את הטוב ביותר</p>
                        </div>
                    </div>
                </div>
            </div>

            {/* Team Section */}
            <div className="py-20">
                <div className="max-w-6xl mx-auto px-6">
                    <h2 className="text-3xl font-light text-[#111827] mb-12 text-center">הצוות שלנו</h2>
                    <div className="grid md:grid-cols-3 gap-8">
                        <div className="text-center">
                            <div className="w-32 h-32 bg-[#f3f4f6] rounded-full mx-auto mb-4 flex items-center justify-center">
                                <Users className="w-16 h-16 text-[#9ca3af]" />
                            </div>
                            <h3 className="text-lg font-medium text-[#111827] mb-1">צוות פיתוח</h3>
                            <p className="text-[#6b7280] text-sm">אחראים על הטכנולוגיה והחדשנות</p>
                        </div>
                        <div className="text-center">
                            <div className="w-32 h-32 bg-[#f3f4f6] rounded-full mx-auto mb-4 flex items-center justify-center">
                                <Calendar className="w-16 h-16 text-[#9ca3af]" />
                            </div>
                            <h3 className="text-lg font-medium text-[#111827] mb-1">צוות תוכן</h3>
                            <p className="text-[#6b7280] text-sm">מכירים כל שביל ומסלול בארץ</p>
                        </div>
                        <div className="text-center">
                            <div className="w-32 h-32 bg-[#f3f4f6] rounded-full mx-auto mb-4 flex items-center justify-center">
                                <Heart className="w-16 h-16 text-[#9ca3af]" />
                            </div>
                            <h3 className="text-lg font-medium text-[#111827] mb-1">שירות לקוחות</h3>
                            <p className="text-[#6b7280] text-sm">תמיד כאן בשבילכם</p>
                        </div>
                    </div>
                </div>
            </div>

            {/* CTA */}
            <div className="py-20 bg-[#111827]">
                <div className="max-w-4xl mx-auto px-6 text-center">
                    <h2 className="text-3xl font-light text-white mb-6">מוכנים לצאת לדרך?</h2>
                    <p className="text-[#9ca3af] mb-8">
                        הצטרפו לאלפי מטיילים מרוצים והתחילו לתכנן את הטיול הבא שלכם היום
                    </p>
                    <button 
                        onClick={() => navigate('/register')}
                        className="bg-white text-[#111827] px-8 py-3 rounded-sm font-medium hover:bg-gray-100 transition-colors"
                    >
                        התחל עכשיו
                    </button>
                </div>
            </div>
        </div>
    );
}
