namespace DeliveryChargeAPI.Models
{
    public class DeliveryCharge
    {
      
        public int? ChargeID {  get; set; }

        public float Distance { get; set; }
        public string? EffectiveDate  { get; set; }
        public float DeliveryType { get; set; }
        public float ChargeAmount { get; set; }

        public float Charge { get; set; }

    }
}
