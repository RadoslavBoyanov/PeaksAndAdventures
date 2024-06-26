﻿namespace PeaksAndAdventures.Common
{
    /// <summary>
    /// Constants for entity models and view models
    /// </summary>
    public static class EntityValidations
    {
        /// <summary>
        /// Constants for entity model Mountain
        /// </summary>
        public static class MountainValidation
        {
            /// <summary>
            /// Constants for name of the mountain
            /// </summary>
            public const int NameMaxLength = 70;
            public const int NameMinLength = 2;

            /// <summary>
            /// Constants for mountain location
            /// </summary>
            public const int LocationMaxLength = 2500;
            public const int LocationMinLength = 50;

            /// <summary>
            /// Constant for mountain climate
            /// </summary>
            public const int ClimateMaxLength = 3000;
            public const int ClimateMinLength = 70;

            /// <summary>
            /// Constants for mountain waters
            /// </summary>
            public const int WatersMaxLength = 10_000;
            public const int WatersMinLength = 80;

            /// <summary>
            /// Constant for mountain flora
            /// </summary>
            public const int FloraMaxLength = 4000;
            public const int FloraMinLength = 100;

            /// <summary>
            /// Constants for mountain fauna
            /// </summary>
            public const int FaunaMaxLength = 3500;
            public const int FaunaMinLength = 100;
        }

        /// <summary>
        /// Constants for entity model Peak
        /// </summary>
        public static class PeakValidation
        {
            /// <summary>
            /// Constants for peak name
            /// </summary>
            public const int NameMaxLength = 40;
            public const int NameMinLength = 2;

            /// <summary>
            /// Constant for peak description
            /// </summary>
            public const int DescriptionMaxLength = 5000;

            /// <summary>
            /// Constants for peak altitude
            /// </summary>
            public const int HighestAltitude = 10_000;
            public const int LowestAltitude = 40;

            /// <summary>
            /// Constant for partition 
            /// </summary>
            public const int PartitionMaxLength = 70;

            /// <summary>
            /// Constant for specific location on the peak
            /// </summary>
            public const int SpecificLocationMaxLength = 80;
        }

        /// <summary>
        /// Constants for entity model Lake
        /// </summary>
        public static class LakeValidation
        {
            /// <summary>
            /// Constants for lake name
            /// </summary>
            public const int NameMaxLength = 35;
            public const int NameMinLength = 2;

            /// <summary>
            /// Constant for lake description
            /// </summary>
            public const int DescriptionMaxLength = 2000;
        }

        /// <summary>
        /// Constants for entity model Waterfall
        /// </summary>
        public static class WaterfallValidation
        {
            /// <summary>
            /// Constants for waterfall name
            /// </summary>
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;

            /// <summary>
            /// Constant for waterfall description
            /// </summary>
            public const int DescriptionMaxLength = 1500;
        }

        /// <summary>
        /// Constants for entity model Hut
        /// </summary>
        public static class HutValidation
        {
            /// <summary>
            /// Constants for hut name
            /// </summary>
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;

            /// <summary>
            /// Constants for hut description
            /// </summary>
            public const int DescriptionMaxLength = 2000;
            public const int DescriptionMinLength = 50;


            /// <summary>
            /// Constant for phone
            /// </summary>
            public const int PhoneNumberMaxLength = 10;
            public const int PhoneNumberMinLength = 8;
        }

        /// <summary>
        /// Constants for entity model Route
        /// </summary>
        public static class RouteValidation
        {
            /// <summary>
            /// Constant for name of route - destination points
            /// </summary>
            public const int NameMaxLength = 100;
            public const int NameMinLength = 5;


            /// <summary>
            /// Constant for route starting point
            /// </summary>
            public const int StartingPointMaxLength = 60;
            public const int StartingPointMinLength = 5;

            /// <summary>
            /// Constants for route displacement positive
            /// </summary>
            public const int DisplacementPositiveMin = 0;
            public const int DisplacementPositiveMax = 7000;

            /// <summary>
            /// Constants for route displacement negative
            /// </summary>
            public const int DisplacementNegativeMin = 0;
            public const int DisplacementNegativeMax = 7000;

			/// <summary>
			/// Constants for route description
			/// </summary>
			public const int DescriptionMaxLength = 7000;
            public const int DescriptionMinLength = 100;


            /// <summary>
            /// Constant for route duration
            /// </summary>
            public const int DurationMaxLength = 10;
        }

        /// <summary>
        /// Constants for entity model MountainGuide
        /// </summary>
        public static class MountainGuideValidation
        {
            /// <summary>
            /// Constants for mountain guide first name and last name
            /// </summary>
            public const int NameMaxLength = 30;
            public const int NameMinLength = 2;

            /// <summary>
            /// Constants for mountain guide age
            /// </summary>
            public const int AgeMax = 65;
            public const int AgeMin = 21;

            /// <summary>
            /// Constants and regex for mountain guide phone
            /// </summary>
            public const int PhoneNumberMaxLength = 15;
            public const int PhoneNumberMinLength = 8;
            public const string PhoneNumberRegex = "@\"^[0-9\\(\\)\\+\\-]*$\"";

            /// <summary>
            /// Constants and regex for mountain guide regex
            /// </summary>
            public const int EmailMaxLength = 30;
            public const int EmailMinLength = 7;
            public const string EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            /// <summary>
            /// Constants for mountain guide experience
            /// </summary>
            public const int ExperienceMaxYears = 70;
            public const int ExperienceMinYears = 1;
        }

        /// <summary>
        /// Constants for entity model TourAgency
        /// </summary>
        public static class TourAgencyValidation
        {
            /// <summary>
            /// Constants for tour agency name
            /// </summary>
            public const int NameMaxLength = 80;
            public const int NameMinLength = 4;

            /// <summary>
            /// Constants for tour agency description
            /// </summary>
            public const int DescriptionMaxLength = 3000;
            public const int DescriptionMinLength = 30;

            /// <summary>
            /// Constants for tour agency email
            /// </summary>
            public const int EmailMaxLength = 60;
            public const int EmailMinLength = 10;

            /// <summary>
            /// Constants for tour agency phone number
            /// </summary>
            public const int PhoneNumberMaxLength = 15;
            public const int PhoneNumberMinLength = 8;
        }

        /// <summary>
        /// Constants for entity model Expedition
        /// </summary>
        public static class ExpeditionValidation
        {
            /// <summary>
            /// Date time format for start date and end date
            /// </summary>
            public const string DateTimeFormat = "dd/MM/yyyy HH:mm";

            /// <summary>
            /// Constants for name of expedition
            /// </summary>
            public const int NameMaxLength = 100;
            public const int NameMinLength = 5;

            /// <summary>
            /// Constants for expedition days
            /// </summary>
            public const int DaysMax = 120;
            public const int DaysMin = 1;

            /// <summary>
            /// Constants for enrolments for expeditions
            /// </summary>
            public const int EnrolmentsMaxCount = 100;
            public const int EnrollmentsMinCount = 1;

            /// <summary>
            /// Constants for expedition days
            /// </summary>
            public const double PriceMax = 1_000_000.00;
            public const double PriceMin = 50.00;


            /// <summary>
            /// Constants for expedition program
            /// </summary>
            public const int ProgramMaxLength = 8000;
            public const int ProgramMinLength = 100;

            /// <summary>
            /// Constants for expedition includes
            /// </summary>
            public const int IncludesMaxLength = 2000;
            public const int IncludesMinLength = 50;


            /// <summary>
            /// Constants for expedition excludes
            /// </summary>
            public const int ExcludesMaxLength = 2000;
            public const int ExcludesMinLength = 50;

            /// <summary>
            /// Constant for expedition extras
            /// </summary>
            public const int ExtrasMaxLength = 3000;
        }

        /// <summary>
        /// Constants for entity model Article
        /// </summary>
        public static class ArticleValidation
        {
            /// <summary>
            /// Constants for article title
            /// </summary>
            public const int TitleMaxLength = 170;
            public const int TitleMinLength = 10;

            /// <summary>
            /// Constants for article content
            /// </summary>
            public const int ContentMaxLength = 8000;
            public const int ContentMinLength = 300;

            /// <summary>
            /// Date time format for date published
            /// </summary>
            public const string DateTimeFormat = "dd/MM/yyyy HH:mm";
        }

        /// <summary>
        /// Validation for ratings in all entity models who have a rating
        /// </summary>
        public static class RatingValidation
        {
            /// <summary>
            /// Constants for rating
            /// </summary>
            public const int MaxRating = 10;
            public const int MinRating = 1;
        }

    }
}
