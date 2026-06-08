import { useState } from 'react';
import { MapPin, Phone, Mail, Clock, Send } from 'lucide-react';

export default function ContactPage() {
    const [formData, setFormData] = useState({
        name: '',
        email: '',
        subject: '',
        message: ''
    });

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        alert('הודעתך נשלחה בהצלחה! נחזור אליך בהקדם.');
        setFormData({ name: '', email: '', subject: '', message: '' });
    };

    return (
        <div className="min-h-screen bg-white pt-20" dir="rtl">
            {/* Hero Section */}
            <div className="bg-gradient-to-b from-[#f0fdf4] to-white py-16">
                <div className="max-w-4xl mx-auto px-6 text-center">
                    <h1 className="text-4xl md:text-5xl font-light text-[#111827] mb-6">
                        צור קשר
                    </h1>
                    <p className="text-xl text-[#6b7280]">
                        נשמח לשמוע מכם! צאו אלינו עם שאלות, הצעות או פשוט להגיד שלום
                    </p>
                </div>
            </div>

            {/* Content */}
            <div className="py-16">
                <div className="max-w-6xl mx-auto px-6">
                    <div className="grid md:grid-cols-2 gap-16">
                        {/* Contact Info */}
                        <div>
                            <h2 className="text-2xl font-light text-[#111827] mb-8">פרטי התקשרות</h2>
                            
                            <div className="space-y-6">
                                <div className="flex items-start gap-4">
                                    <div className="w-12 h-12 bg-[#f0fdf4] rounded-full flex items-center justify-center flex-shrink-0">
                                        <MapPin className="w-6 h-6 text-[#059669]" />
                                    </div>
                                    <div>
                                        <h3 className="font-medium text-[#111827] mb-1">כתובת</h3>
                                        <p className="text-[#6b7280]">רחוב הברזל 32, תל אביב</p>
                                    </div>
                                </div>

                                <div className="flex items-start gap-4">
                                    <div className="w-12 h-12 bg-[#f0fdf4] rounded-full flex items-center justify-center flex-shrink-0">
                                        <Phone className="w-6 h-6 text-[#059669]" />
                                    </div>
                                    <div>
                                        <h3 className="font-medium text-[#111827] mb-1">טלפון</h3>
                                        <p className="text-[#6b7280]">03-1234567</p>
                                    </div>
                                </div>

                                <div className="flex items-start gap-4">
                                    <div className="w-12 h-12 bg-[#f0fdf4] rounded-full flex items-center justify-center flex-shrink-0">
                                        <Mail className="w-6 h-6 text-[#059669]" />
                                    </div>
                                    <div>
                                        <h3 className="font-medium text-[#111827] mb-1">אימייל</h3>
                                        <p className="text-[#6b7280]">contact@tilulon.co.il</p>
                                    </div>
                                </div>

                                <div className="flex items-start gap-4">
                                    <div className="w-12 h-12 bg-[#f0fdf4] rounded-full flex items-center justify-center flex-shrink-0">
                                        <Clock className="w-6 h-6 text-[#059669]" />
                                    </div>
                                    <div>
                                        <h3 className="font-medium text-[#111827] mb-1">שעות פעילות</h3>
                                        <p className="text-[#6b7280]">א'-ה': 09:00-18:00</p>
                                    </div>
                                </div>
                            </div>

                            {/* Map Placeholder */}
                            <div className="mt-12 h-64 bg-[#f3f4f6] rounded-lg flex items-center justify-center">
                                <div className="text-center">
                                    <MapPin className="w-12 h-12 text-[#9ca3af] mx-auto mb-2" />
                                    <p className="text-[#6b7280]">מפה תופיע כאן</p>
                                </div>
                            </div>
                        </div>

                        {/* Contact Form */}
                        <div>
                            <h2 className="text-2xl font-light text-[#111827] mb-8">שלחו לנו הודעה</h2>
                            
                            <form onSubmit={handleSubmit} className="space-y-6">
                                <div>
                                    <label className="block text-sm font-medium text-[#4b5563] mb-2">
                                        שם מלא
                                    </label>
                                    <input
                                        type="text"
                                        value={formData.name}
                                        onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                                        className="w-full px-4 py-3 border border-[#d1d5db] rounded-sm text-[#111827] focus:outline-none focus:border-[#111827] transition-colors"
                                        placeholder="הזינו את שמכם"
                                        required
                                    />
                                </div>

                                <div>
                                    <label className="block text-sm font-medium text-[#4b5563] mb-2">
                                        אימייל
                                    </label>
                                    <input
                                        type="email"
                                        value={formData.email}
                                        onChange={(e) => setFormData({ ...formData, email: e.target.value })}
                                        className="w-full px-4 py-3 border border-[#d1d5db] rounded-sm text-[#111827] focus:outline-none focus:border-[#111827] transition-colors"
                                        placeholder="your@email.com"
                                        required
                                    />
                                </div>

                                <div>
                                    <label className="block text-sm font-medium text-[#4b5563] mb-2">
                                        נושא
                                    </label>
                                    <select
                                        value={formData.subject}
                                        onChange={(e) => setFormData({ ...formData, subject: e.target.value })}
                                        className="w-full px-4 py-3 border border-[#d1d5db] rounded-sm text-[#111827] focus:outline-none focus:border-[#111827] transition-colors bg-white"
                                        required
                                    >
                                        <option value="">בחרו נושא</option>
                                        <option value="general">שאלה כללית</option>
                                        <option value="support">תמיכה טכנית</option>
                                        <option value="feedback">משוב</option>
                                        <option value="partnership">שיתופי פעולה</option>
                                        <option value="other">אחר</option>
                                    </select>
                                </div>

                                <div>
                                    <label className="block text-sm font-medium text-[#4b5563] mb-2">
                                        הודעה
                                    </label>
                                    <textarea
                                        value={formData.message}
                                        onChange={(e) => setFormData({ ...formData, message: e.target.value })}
                                        rows={5}
                                        className="w-full px-4 py-3 border border-[#d1d5db] rounded-sm text-[#111827] focus:outline-none focus:border-[#111827] transition-colors resize-none"
                                        placeholder="כתבו את הודעתכם כאן..."
                                        required
                                    />
                                </div>

                                <button
                                    type="submit"
                                    className="w-full bg-[#111827] text-white py-3 rounded-sm font-medium hover:bg-[#1f2937] transition-colors flex items-center justify-center gap-2"
                                >
                                    <Send className="w-4 h-4" />
                                    שלח הודעה
                                </button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

            {/* FAQ Section */}
            <div className="py-16 bg-[#f9fafb]">
                <div className="max-w-4xl mx-auto px-6">
                    <h2 className="text-2xl font-light text-[#111827] mb-8 text-center">שאלות נפוצות</h2>
                    
                    <div className="space-y-4">
                        <div className="bg-white p-6 rounded-lg">
                            <h3 className="font-medium text-[#111827] mb-2">איך אני מתחיל לתכנן טיול?</h3>
                            <p className="text-[#6b7280] text-sm">פשוט לחצו על "מצא לי טיול" בדף הבית, בחרו את ההעדפות שלכם, והמערכת תמליץ על הטיולים המתאימים ביותר.</p>
                        </div>
                        
                        <div className="bg-white p-6 rounded-lg">
                            <h3 className="font-medium text-[#111827] mb-2">האם השירות בחינם?</h3>
                            <p className="text-[#6b7280] text-sm">כן! טיולון מספק את כל השירותים בחינם לכל המשתמשים.</p>
                        </div>
                        
                        <div className="bg-white p-6 rounded-lg">
                            <h3 className="font-medium text-[#111827] mb-2">איך אני יכול לשמור טיולים?</h3>
                            <p className="text-[#6b7280] text-sm">הרשמו לאתר ותוכלו לשמור טיולים מועדפים ולצפות בהם בכל עת.</p>
                        </div>
                        
                        <div className="bg-white p-6 rounded-lg">
                            <h3 className="font-medium text-[#111827] mb-2">יש לכם אפליקציה לנייד?</h3>
                            <p className="text-[#6b7280] text-sm">כרגע אנחנו פועלים כאפליקציית ווב, אך גרסה לנייד בפיתוח.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
