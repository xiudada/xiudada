sharedModule.factory('DropDownListDataService', [function () {

    var Settings = {
        WeekList: [
            { value: '0', label: 'SUNDAY' },
            { value: '1', label: 'MONDAY' },
            { value: '2', label: 'TUESDAY' },
            { value: '3', label: 'WEDNESDAY' },
            { value: '4', label: 'THURSDAY' },
            { value: '5', label: 'FRIDAY' },
            { value: '6', label: 'SATURDAY' },
        ],

        ExportToFileType: [
            { value: 'Excel', label: 'EXCEL' },
            { value: 'Pdf', label: 'PDF' },
        ],

        LeadReportPeriodType: [
            { value: 'Last24Hours', label: 'LAST_24_HOURS' },
            { value: 'Last48Hours', label: 'LAST_48_HOURS' },
            { value: 'LastWeek', label: 'LAST_WEEK' },
            { value: 'Last2Weeks', label: 'LAST_2_WEEKS' },
        ],

        ShowArchivedTransactionsPeriodType: [
            { value: 'ThreeMonths', label: 'THREE_MONTHS' },
            { value: 'SixMonths', label: 'SIX_MONTHS' },
            { value: 'NineMonths', label: 'NINE_MONTHS' },
            { value: 'OneYear', label: 'ONE_YEAR' }
        ],
    };

    var Transaction = {
        BuildingStatus: [
            { value: 'UnderConstruction', label: 'UNDER_CONSTRUCTION' },
            { value: 'ToBeDeveloped', label: 'TO_BE_DEVELOPED' },
            { value: 'Ready', label: 'READY' },
            { value: 'Demolished', label: 'DEMOLISHED' },
            { value: 'Renovation', label: 'RENOVATION' },
            { value: 'Redevelopment', label: 'REDEVELOPMENT' },
        ],

        TransactionType: [
            { value: 'Let', label: 'LET' },
            { value: 'Sale', label: 'SALE' },
            { value: 'Investment', label: 'INVESTMENT' },
            { value: 'SaleAndLeaseback', label: 'SALE_AND_LEASE_BACK' },
            { value: 'LetProlongation', label: 'LET_PROLONGATION' },
            { value: 'Redevelopment', label: 'REDEVELOPMENT' },
            { value: 'Withdraw', label: 'WITHDRAW' },
            { value: 'LetToSale', label: 'LETTOSALE' },
            { value: 'LetAndSale', label: 'LETANDSALE' },
            { value: 'Unknown', label: 'UNKNOWN' }
        ],

        PublishPartiallyType: [
            { value: 'DoNotPublishInvolvedParties', label: 'DO_NOT_PUBLISH_INVOLVED_PARTIES' },
            { value: 'DoNotPublishPrice', label: 'DO_NOT_PUBLISH_PRICE' }
        ],

        PublishExternalParties: [
            { value: 'Vastgoedjournaal', label: 'VASTGOEDJOURNAAL' },
            { value: 'Vastgoedmanagmenet', label: 'VASTGOEDMANAGMENET' },
            { value: 'PropertyNL', label: 'PROPERTY_NL' },
        ],

        PublicationType: [
            { value: 'DoNotPublish', label: 'DO_NOT_PUBLISH' },
            { value: 'PublishCompletely', label: 'PUBLISH_COMPLETELY' },
            { value: 'PublishPartially', label: 'PUBLISH_PARTIALLY' },
        ],

        TransactionArchivedType: [
            { value: 'ForSale', label: 'For Sale' },
            { value: 'ForLet', label: 'For Let' }
        ],

        InvolvedPartyType: [
            { value: 'Seller', label: 'SELLER' },
            { value: 'Buyer', label: 'BUYER' },
            { value: 'Letter', label: 'LETTER' },
            { value: 'Lesse', label: 'LESSE' },
            { value: 'Other', label: 'OTHER' }
        ],
    };


    var RealEstateObject = {
        VersionStatus: [
            { value: 'Draft', label: 'DRAFT' },
            { value: 'Submitted', label: 'SUBMITTED' }
        ],
        PublicationStatus: [
            { value: 'Unpublished', label: 'UNPUBLISHED' },
            { value: 'Published', label: 'PUBLISHED' }
        ],
        BuildingUsage: [
            { value: 'Unknown', label: 'UNKNOWN' },
            { value: 'Office', label: 'OFFICE' },
            { value: 'Industrial', label: 'INDUSTRIAL' },
            { value: 'Retail', label: 'RETAIL' },
            { value: 'HotelAndCateringIndustry', label: 'HOTEL_AND_CATERING_INDUSTRY' },
            { value: 'Leisure', label: 'LEISURE' },
            { value: 'Land', label: 'LAND' }
        ],
        BuildingStatus: [
            { value: 'UnderConstruction', label: 'UNDER_CONSTRUCTION' },
            { value: 'ToBeDeveloped', label: 'TO_BE_DEVELOPED' },
            { value: 'Ready', label: 'READY' },
            { value: 'Demolished', label: 'DEMOLISHED' },
            { value: 'Renovation', label: 'RENOVATION' },
            { value: 'Redevelopment', label: 'REDEVELOPMENT' }
        ],
        OtherOfferUsage: [
            { value: 'Office', label: 'OFFICE' },
            { value: 'Industrial', label: 'INDUSTRIAL' },
            { value: 'Retail', label: 'RETAIL' },
            { value: 'HotelAndCateringIndustry', label: 'HOTEL_AND_CATERING_INDUSTRY' },
            { value: 'Showroom', label: 'SHOWROOM' }
        ],
        OfferUsage: [
            { value: 'Unknown', label: 'UNKNOWN' },
            { value: 'Office', label: 'OFFICE' },
            { value: 'Industrial', label: 'INDUSTRIAL' },
            { value: 'Retail', label: 'RETAIL' },
            { value: 'Renovation', label: 'RENOVATION' },
            { value: 'HotelAndCateringIndustry', label: 'HOTEL_AND_CATERING_INDUSTRY' },
            { value: 'Leisure', label: 'LEISURE' },
            { value: 'Land', label: 'LAND' }
        ],
        OfferType: [
            { value: 'Sale', label: 'SALE' },
            { value: 'Let', label: 'LET' },
            { value: 'LetAndSale', label: 'LET_AND_SALE' },
            { value: 'Investment', label: 'INVESTMENT' }
        ],
        OfferAvailability: [
            { value: 'Unknown', label: 'UNKNOWN' },
            { value: 'PerDirect', label: 'PER_DIRECT' },
            { value: 'InConsultation', label: 'IN_CONSULTATION' },
            { value: 'Date', label: 'DATE' }
        ],
        OfferSalePriceType: [
            { value: 'AskingPrice', label: 'ASKING_PRICE' },
            { value: 'StartingPrice', label: 'STARTING_PRICE' },
            { value: 'Unknown', label: 'UNKNOWN' },
            // { value: 'InConsultation', label: 'IN_CONSULTATION' },
            // { value: 'Date', label: 'DATE' }
        ],
        EnergyLabel: [
            { value: 'Unknown', label: 'UNKNOWN' },
            { value: 'A', label: 'A' },
            { value: 'B', label: 'B' },
            { value: 'C', label: 'C' },
            { value: 'D', label: 'D' },
            { value: 'E', label: 'E' },
            { value: 'F', label: 'F' },
            { value: 'G', label: 'G' }
        ],

    };

    var User = {
        UserType: [
            { value: 'Customer', label: 'CUSTOMER' },
            { value: 'BrokerManager', label: 'BROKER_MANAGER' },
            { value: 'BrokerAdministrator', label: 'BROKER_ADMINISTRATOR' }
        ]
    };

    var Lead = {
        QuickDateSet: [
            { value: 'LastDay', label: 'LAST_DAY' },
            { value: 'LastWeek', label: 'LAST_WEEK' },
            { value: 'LastMonth', label: 'LAST_MONTH' },
            { value: 'Last3Month', label: 'LAST_3_MONTH' },
            { value: 'LastYear', label: 'LAST_YEAR' }
        ],
        NumberOfEmployees: [
            { value: '001', label: 'GEEN_WERKNEMER' },
            { value: '002', label: '1_WERKNEMER' },
            { value: '003', label: '2_4_WERKNEMERS' },
            { value: '004', label: '5_9_WERKNEMERS' },
            { value: '005', label: '10_19_WERKNEMERS' },
            { value: '006', label: '20_49_WERKNEMERS' },
            { value: '007', label: '50_99_WERKNEMERS' },
            { value: '008', label: '100_199_WERKNEMERS' },
            { value: '009', label: '200_299_WERKNEMERS' },
            { value: '010', label: '500_749_WERKNEMERS' },
            { value: '011', label: '750_999_WERKNEMERS' },
            { value: '012', label: '1000_EN_NEER_WERKNEMERS' }
        ]
    }

    function getSelectSource(sourceKey) {
        switch (sourceKey) {
            /*------ RealEstateObject Start ------ */
            case 'RealEstateObject.OfferType':
                return RealEstateObject.OfferType;
            case 'RealEstateObject.OfferAvailability':
                return RealEstateObject.OfferAvailability;

            case 'RealEstateObject.OfferSalePriceType':
                return RealEstateObject.OfferSalePriceType;

            case 'RealEstateObject.OfferUsage':
                return RealEstateObject.OfferUsage;

            case 'RealEstateObject.OtherOfferUsage':
                return RealEstateObject.OtherOfferUsage;

            case 'RealEstateObject.EnergyLabel':
                return RealEstateObject.EnergyLabel;

            case 'RealEstateObject.VersionStatus':
                return RealEstateObject.VersionStatus;

            case 'RealEstateObject.PublicationStatus':
                return RealEstateObject.PublicationStatus;

            case 'RealEstateObject.BuildingUsage':
                return RealEstateObject.BuildingUsage;

            case 'RealEstateObject.BuildingStatus':
                return RealEstateObject.BuildingStatus;

                /*------ Transaction Start ------ */
            case 'Transaction.BuildingStatus':
                return Transaction.BuildingStatus;

            case 'Transaction.TransactionType':
                return Transaction.TransactionType;

            case 'Transaction.PublishPartiallyType':
                return Transaction.PublishPartiallyType;

            case 'Transaction.PublishExternalParties':
                return Transaction.PublishExternalParties;

            case 'Transaction.PublicationType':
                return Transaction.PublicationType;

            case 'Transaction.TransactionArchivedType':
                return Transaction.TransactionArchivedType;

            case 'Transaction.InvolvedPartyType':
                return Transaction.InvolvedPartyType;


                /*------ Basic Setting ------ */
            case 'Settings.WeekList':
                return Settings.WeekList;

            case 'Settings.LeadReportPeriodType':
                return Settings.LeadReportPeriodType;

            case 'Settings.ExportToFileType':
                return Settings.ExportToFileType;

            case 'Settings.ShowArchivedTransactionsPeriodType':
                return Settings.ShowArchivedTransactionsPeriodType;

                /*----- Lead Setting-----*/
            case 'Lead.QuickDateSet':
                return Lead.QuickDateSet;

            case 'Lead.NumberOfEmployees':
                return Lead.NumberOfEmployees;

                /*----- User Setting-----*/
            case 'User.UserType':
                return User.UserType;

            default:
                return null;
        }
    }

    return {
        getSelectSource: function (sourceKey) {
            return getSelectSource(sourceKey);
        },
    }
}]);