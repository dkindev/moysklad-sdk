using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an tracking type.
    /// See also: https://dev.moysklad.ru/doc/api/remap/1.2/dictionaries/#suschnosti-towar-towary-atributy-suschnosti-tip-markiruemoj-produkcii
    /// </summary>
    public enum TrackingType
    {
        /// <summary>
        /// Not tracked.
        /// </summary>
        [EnumMember(Value = "NOT_TRACKED")]
        NotTracked,

        /// <summary>
        /// Tobacco tracking type.
        /// </summary>
        [EnumMember(Value = "TOBACCO")]
        Tobacco,

        /// <summary>
        /// Shoes tracking type.
        /// </summary>
        [EnumMember(Value = "SHOES")]
        Shoes,

        /// <summary>
        /// Clothes tracking type.
        /// </summary>
        [EnumMember(Value = "LP_CLOTHES")]
        Clothes,

        /// <summary>
        /// Linens tracking type.
        /// </summary>
        [EnumMember(Value = "LP_LINENS")]
        Linens,

        /// <summary>
        /// Perfumery tracking type.
        /// </summary>
        [EnumMember(Value = "PERFUMERY")]
        Perfumery,

        /// <summary>
        /// Electronics tracking type.
        /// </summary>
        [EnumMember(Value = "ELECTRONICS")]
        Electronics,

        /// <summary>
        /// Tires tracking type.
        /// </summary>
        [EnumMember(Value = "TIRES")]
        Tires,

        /// <summary>
        /// Tracking type for other tobacco products.
        /// </summary>
        [EnumMember(Value = "OTP")]
        OTP,

        /// <summary>
        /// Tracking type for beer and low-alcohol products.
        /// </summary>
        [EnumMember(Value = "BEER_ALCOHOL")]
        BeerAlcohol,

        /// <summary>
        /// Tracking type for bicycles.
        /// </summary>
        [EnumMember(Value = "BICYCLE")]
        Bicycle,

        /// <summary>
        /// Tracking type for food supplements.
        /// </summary>
        [EnumMember(Value = "FOOD_SUPPLEMENT")]
        FoodSupplement,

        /// <summary>
        /// Tracking type for medical devices.
        /// </summary>
        [EnumMember(Value = "MEDICAL_DEVICES")]
        MedicalDevices,

        /// <summary>
        /// Tracking type for milk products.
        /// </summary>
        [EnumMember(Value = "MILK")]
        Milk,

        /// <summary>
        /// Tracking type for nabeer.
        /// </summary>
        [EnumMember(Value = "NABEER")]
        Nabeer,

        /// <summary>
        /// Tracking type for nicotine containing products.
        /// </summary>
        [EnumMember(Value = "NCP")]
        NCP,

        /// <summary>
        /// Tracking type for pet food.
        /// </summary>
        [EnumMember(Value = "PET_FOOD")]
        PetFood,

        /// <summary>
        /// Tracking type for sanitizers.
        /// </summary>
        [EnumMember(Value = "SANITIZER")]
        Sanitizer,

        /// <summary>
        /// Tracking type for sea food.
        /// </summary>
        [EnumMember(Value = "SEAFOOD")]
        SeaFood,

        /// <summary>
        /// Tracking type for soft drinks.
        /// </summary>
        [EnumMember(Value = "SOFT_DRINKS")]
        SoftDrinks,

        /// <summary>
        /// Tracking type for vegetable oils.
        /// </summary>
        [EnumMember(Value = "VEGETABLE_OIL")]
        VegetableOil,

        /// <summary>
        /// Tracking type for veterinary drugs.
        /// </summary>
        [EnumMember(Value = "VETPHARMA")]
        VetPharma,

        /// <summary>
        /// Tracking type for packaged water.
        /// </summary>
        [EnumMember(Value = "WATER")]
        Water,
    }
}