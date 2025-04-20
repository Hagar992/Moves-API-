using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Moves_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // بيحدد إن الدالة دي تستجيب لطلبات HTTP GET
        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            // بيجيب كل أنواع الـ Genres من قاعدة البيانات، وبيعمل ترتيب تصاعدي حسب الاسم باستخدام LINQ
            // ToListAsync() بتخلي التنفيذ غير متزامن (Asynchronous) علشان ما يوقفش الـ thread الأساسي
            var genres = await _context.Genres.OrderBy(o => o.Name).ToListAsync();

            // بيرجع النتيجة في استجابة HTTP 200 OK، ومعاها البيانات المرتبة كـ JSON
            return Ok(genres);
        }




        // تحدد إن الميثود دي بتتعامل مع طلب HTTP POST (يعني إنشاء بيانات جديدة)
        [HttpPost]

        // تعريف ميثود Async اسمها CreateAsync بتستقبل كائن dto فيه بيانات النوع (Genre)
        public async Task<IActionResult> CreateAsync(CreateGenreDto dto)
        {
            // إنشاء كائن جديد من النوع Genre وتخزين الاسم اللي جاي من dto فيه
            var genre = new Genre
            {
                Name = dto.Name // تخصيص الاسم حسب البيانات اللي جت من المستخدم
            };

            // إضافة الكائن الجديد لقاعدة البيانات باستخدام AddAsync لأنها عملية غير متزامنة (Asynchronous)
            await _context.Genres.AddAsync(genre);

            // حفظ التغييرات في قاعدة البيانات بشكل فعلي (برضو Asynchronous)
            await _context.SaveChangesAsync();

            // إرجاع رد للمستخدم فيه النوع اللي تم إنشاؤه (status code 200 ومعاه البيانات)
            return Ok(genre);
        }



        // تحديد أن هذا هو endpoint لتحديث بيانات موجودة باستخدام HTTP PUT والطريق يحتوي على ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] CreateGenreDto dto)
        {
            // البحث في قاعدة البيانات عن نوع (Genre) مطابق للـ id المُرسل
            var genre = await _context.Genres.SingleOrDefaultAsync(l => l.Id == id);

            // لو النوع مش موجود (null)، نرجع رسالة خطأ 404
            if (genre == null)
            {
                return NotFound($"No genre Was Found With ID: {id}");  // النوع غير موجود
            }

            // لو موجود، نحدث الاسم الموجود في الكائن بالاسم الجديد اللي جاي من الـ DTO
            genre.Name = dto.Name;

            // نحفظ التغييرات دي في قاعدة البيانات
            await _context.SaveChangesAsync();

            // نرجع النوع بعد ما تم تحديثه بنجاح
            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            // البحث عن النوع باستخدام الـ ID
            var genre = await _context.Genres.SingleOrDefaultAsync(l => l.Id == id);
            // لو النوع مش موجود، نرجع رسالة خطأ 404
            if (genre == null)
            {
                return NotFound($"No genre Was Found With ID: {id}");  // النوع غير موجود
            }
            // لو موجود، نحذفه من قاعدة البيانات
            _context.Genres.Remove(genre);
            // نحفظ التغييرات في قاعدة البيانات
            await _context.SaveChangesAsync();
            // نرجع رسالة نجاح مع تفاصيل النوع المحذوف
            return Ok(genre);
        }



    }
}
