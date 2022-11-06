using System;
namespace GreenSharing.API.Models
{
    public class ProductType
    {
        public static readonly Guid Vegetable = new Guid("C5A7D3A5-365D-4CBA-A48E-1BBF6F39FDAD");
        public static readonly Guid Animal    = new Guid("B57F1520-9F64-4442-8414-A2B2DFDB8D13");
        public static readonly Guid Other     = new Guid("37183EBB-9C7F-41E8-8B55-3BF292A37C25");

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
