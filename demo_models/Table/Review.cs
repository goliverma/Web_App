using System;

namespace demo_models.Table
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public float rating { get; set; }
        public int movId { get; set; }
        public DateTime datepost { get; set; }
        public int accountid { get; set; }
        public Movies movie { get; set; }
        public Account account { get; set; }
    }
}