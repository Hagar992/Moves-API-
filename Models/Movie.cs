namespace Moves_API_.Models
{
    // تعريف كلاس Movie الذي يمثل كيان الفيلم في قاعدة البيانات
    public class Movie
    {
        // المعرف الأساسي للفيلم (Primary Key)
        public int Id { get; set; }

        // عنوان الفيلم مع تحديد الحد الأقصى للطول بـ 250 حرف
        [MaxLength(250)]
        public string Title { get; set; }

        // سنة إصدار الفيلم
        public int Year { get; set; }

        // تقييم الفيلم (مثلاً: 7.5)
        public double Rate { get; set; }

        // ملخص قصة الفيلم مع تحديد الحد الأقصى للطول بـ 2500 حرف
        [MaxLength(2500)]
        public string StoryLine { get; set; }

        // صورة البوستر للفيلم مخزنة كمصفوفة من البايتات
        public byte[] Poster { get; set; }

        // معرف النوع (Genre) المرتبط بالفيلم (مفتاح أجنبي)
        public byte GenreId { get; set; }

        // 🔹 دي Navigation Property لربط كيان الفيلم بكائن النوع (Genre).
        //🔹 من خلالها ممكن توصل لاسم النوع المرتبط بالفيلم (مثلاً: Action, Comedy...).
        public Genre Genre { get; set; }
    }

}
