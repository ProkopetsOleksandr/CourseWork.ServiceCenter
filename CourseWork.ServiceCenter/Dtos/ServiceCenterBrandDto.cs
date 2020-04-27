namespace CourseWork.ServiceCenter.Dtos
{
    public class ServiceCenterBrandDto
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        public int ServiceCenterId { get; set; }

        public BrandDto Brand { get; set; }

        public ServiceCenterDto ServiceCenter { get; set; }
    }
}