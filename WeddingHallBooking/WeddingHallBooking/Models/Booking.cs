using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingHallBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم القاعة مطلوب")]
        public string HallName { get; set; } = "";

        [Required(ErrorMessage = "تاريخ الحجز مطلوب")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "عدد الحضور مطلوب")]
        [Range(1, 1000, ErrorMessage = "العدد يجب أن يكون بين 1 و 1000")]
        public int GuestsCount { get; set; }

        public string? Extras { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "المبلغ يجب أن يكون رقماً صحيحاً")]
        public int TotalAmount { get; set; }
    }
}
