﻿namespace ResidentialCommunityAssistant.Data.Common
{
    public static class GlobalConstants
    {
        //City
        public const int CityNameMinLength = 2;
        public const int CityNameMaxLength = 85;
        public const int CityPostCodeMinLength = 2;
        public const int CityPostCodeMaxLength = 10;

        //Address
        public const int AddressNameMinLength = 2;
        public const int AddressNameMaxLength = 100;
        public const int AddressNumberMinLength = 1;
        public const int AddressNumberMaxLength = 10;

        //LocationType
        public const int LocationTypeNameMinLength = 2;
        public const int LocationTypeNameMaxLength = 16;

        //LocalityType
        public const int LocalityTypeNameMinLength = 2;
        public const int LocalityTypeNameMaxLength = 16;

        //CommunityTopic
        public const int CommunityTopicTitleMinLength = 4;
        public const int CommunityTopicTitleMaxLength = 256;
        public const int CommunityTopicDescriptionMinLength = 4;
        public const int CommunityTopicDescriptionMaxLength = 1024;

        //Apartament
        public const int ApartamentSignatureMinLength = 1;
        public const int ApartamentSignatureMaxLength = 10;
        public const int ApartamentRangeMinLength = 1;
        public const int ApartamentRangeMaxLength = 10000;

        //ExtendedUser
        public const int ExtendedUserFirstNameMinLength = 1;
        public const int ExtendedUserFirstNameMaxLength = 24;
        public const int ExtendedUserLastNameMinLength = 1;
        public const int ExtendedUserLastNameMaxLength = 24;

        //Product
        public const int ProductNameMinLength = 2;
        public const int ProductNameMaxLength = 64;
        public const int ProductDescriptionMinLength = 4;
        public const int ProductDescriptionMaxLength = 128;
        public const int ProductImgURLMinLength = 8;
        public const int ProductImgURLMaxLength = 2048;
        public const int ProductQuantityMinRange = 0;
        public const int ProductQuantityMaxRange = 5000;
        public const string ProductPriceRangeMinRange = "0.01";
        public const string ProductPriceRangeMaxRange = "10000.00";


        //OrderCache
        public const int OrderCacheMinValue = 1;
        public const int OrderCacheMaxValue = 20;
    }
}
